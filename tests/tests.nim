import ../src/farsidePacker
import ../src/tempStub 
import unittest
import winim
import ptr_math
import strutils



suite "load PE to memory":
    test "test_loadPeToMem":
        # copy data from memory to veriable
        var lpBuffer = loadPeToMem(".\\a.exe")
        var size = 2
        var lpResult = alloc0(size)
        copyMem(addr lpResult, lpBuffer, size)
        # get first 4 bytes of memory
        var result = (repr lpResult)[len(repr lpResult) - 4] &
            (repr lpResult)[len(repr lpResult) - 3] &
            (repr lpResult)[len(repr lpResult) - 2] & 
            (repr lpResult)[len(repr lpResult) - 1]
        # Check the first bytes of mem buffer
        check(result == "5A4D")


suite "parse PE headers":
    test "test_getDosHeader":
        # copy data from memory to veriable
        var lpBuffer = loadPeToMem(".\\a.exe")
        # check for e_magic
        check(getDosHeader(lpBuffer).e_magic == 0x5A4D)

    test "test_getNtHeader":
        # copy data from memory to veriable
        var lpBuffer = loadPeToMem(".\\a.exe")
        # check signature
        check(getNtHeader(lpBuffer).Signature == IMAGE_NT_SIGNATURE)


suite "file validation tests":  
    test "test_isPE":
        var lpBuffer = loadPeToMem(".\\a.exe")
        var dosHeader = getDosHeader(lpBuffer)
        check(isPE(dosHeader) == true)

    test "test_is64":
        var lpBuffer = loadPeToMem(".\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        check(is64(ntHeaders) == true)

    test "test_isDll":
        var lpBuffer = loadPeToMem(".\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        check(isDll(ntHeaders) == false)

    test "test_isNET":
        var lpBuffer = loadPeToMem(".\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        check(isNET(ntHeaders) == false)

suite "Load PE tests": 
    test "test_allocateMemory":
        var lpBuffer = loadPeToMem(".\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        check(allocateMemory(ntHeaders) != nil)
        # free memory
        echo "[+] Freeing memory"
        VirtualFreeEx(GetCurrentProcess(), cast[LPVOID](ntHeaders.OptionalHeader.ImageBase),
            ntHeaders.OptionalHeader.SizeOfImage, MEM_RELEASE)

    test "test_checkPreferedAddress":
        #TODO: check for error here
        var lpBuffer = loadPeToMem("..\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        var pImageBase: ptr BYTE = allocateMemory(ntHeaders)
        var performBaseReloc = checkPreferedAddress(ntHeaders, pImageBase)
        check(performBaseReloc == true)

    test "test_getRelocAddr":
        var lpBuffer = loadPeToMem("..\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        var pImageBase: ptr BYTE
        var res = getRelocAddr(ntHeaders, pImageBase)
        check(res == cast[LPVOID](0x26000))

    test "test_calcRelocDelta":
        var lpBuffer = loadPeToMem("..\\a.exe")
        var ntHeaders = getNtHeader(lpBuffer)
        var res = calcRelocDelta(ntHeaders, cast[ptr BYTE](0x140000000))
        check(res == cast[LPVOID](0x0))

suite "Encryption tests": 
    test "test_encryptData_and_decryptData":
        var testString = "testString"
        var encData = encryptData(testString)
        var decData = decryptData(encData)
        check((toString(decData)).contains(testString) == true)
import os
suite "Stub creation tests": 
    test "test_embedPayload":
        var payload = "@@easyToFind@@"
        var filePath = "..\\src\\farsideStub.nim"
        var tempFilePath = embedPayload(filePath, payload)
        var searchFile = readFile(tempFilePath)    
        check(searchFile.contains(payload) == true)
        # cleanup
        var status = tryRemoveFile(tempFilePath)
        if status:
            echo "\t|-> Cleanup successful"
    
    test "test_compileStub":
        var inFilePath = "..\\src\\farsideStubTDD.nim"
        var outFilePath = "..\\src\\farsideStubTDD_temp.exe"
        var result = compileStub(inFilePath, outFilePath)
        check(result.contains("[SuccessX]") == true)
        # cleanup
        var status = tryRemoveFile(outFilePath)
        if status:
            echo "\t|-> Cleanup successful"
