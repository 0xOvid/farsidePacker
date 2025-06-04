<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMain))
        gbPayload = New GroupBox()
        cbAsDll = New CheckBox()
        btnRandomize = New Button()
        lOutputFileName = New Label()
        lFileToBePacked = New Label()
        btnBrowse = New Button()
        txtFileToBePacked = New TextBox()
        txtOutputFileName = New TextBox()
        gbExecution = New GroupBox()
        cbInjectionMethod = New ComboBox()
        cbBinFormat = New ComboBox()
        lBinaryFormat = New Label()
        lInjectionMethod = New Label()
        pbChineese = New PictureBox()
        PictureBox1 = New PictureBox()
        gbDebug = New GroupBox()
        btnClearLog = New Button()
        cbKeepPrintMessages = New CheckBox()
        cbKeepTmpFile = New CheckBox()
        llLinkedIn = New LinkLabel()
        llGithubLink = New LinkLabel()
        llMediumLink = New LinkLabel()
        Panel1 = New Panel()
        cbLanguage = New ComboBox()
        lIntro = New Label()
        gbSandbox = New GroupBox()
        cbCheckSleep = New CheckBox()
        lDelay = New Label()
        numDelayExecution = New NumericUpDown()
        cbCheckUsername = New CheckBox()
        cbCheckVM = New CheckBox()
        cbCheckRAM = New CheckBox()
        lDelayExecution = New Label()
        cbDelayExecution = New ComboBox()
        GroupBox5 = New GroupBox()
        gbEDR = New GroupBox()
        cbUserInput = New CheckBox()
        cbPatchETW = New CheckBox()
        cbUnhookNtDll = New CheckBox()
        lSyscallObf = New Label()
        cbSysCall = New ComboBox()
        GroupBox7 = New GroupBox()
        cbLowEntropy = New CheckBox()
        gbOutputLog = New GroupBox()
        txtOutputLog = New TextBox()
        btnGenerateBinary = New Button()
        cbFakeSignature = New CheckBox()
        gbStatic = New GroupBox()
        GroupBox9 = New GroupBox()
        PictureBox2 = New PictureBox()
        gbPayload.SuspendLayout()
        gbExecution.SuspendLayout()
        CType(pbChineese, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        gbDebug.SuspendLayout()
        Panel1.SuspendLayout()
        gbSandbox.SuspendLayout()
        CType(numDelayExecution, ComponentModel.ISupportInitialize).BeginInit()
        gbEDR.SuspendLayout()
        gbOutputLog.SuspendLayout()
        gbStatic.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gbPayload
        ' 
        gbPayload.Controls.Add(cbAsDll)
        gbPayload.Controls.Add(btnRandomize)
        gbPayload.Controls.Add(lOutputFileName)
        gbPayload.Controls.Add(lFileToBePacked)
        gbPayload.Controls.Add(btnBrowse)
        gbPayload.Controls.Add(txtFileToBePacked)
        gbPayload.Controls.Add(txtOutputFileName)
        gbPayload.ForeColor = SystemColors.Control
        gbPayload.Location = New Point(14, 285)
        gbPayload.Name = "gbPayload"
        gbPayload.Size = New Size(405, 169)
        gbPayload.TabIndex = 1
        gbPayload.TabStop = False
        gbPayload.Text = "Payload"
        ' 
        ' cbAsDll
        ' 
        cbAsDll.AutoSize = True
        cbAsDll.ForeColor = Color.Lime
        cbAsDll.Location = New Point(17, 85)
        cbAsDll.Name = "cbAsDll"
        cbAsDll.Size = New Size(193, 19)
        cbAsDll.TabIndex = 20
        cbAsDll.Text = "Compile as .DLL - func: DllMain"
        cbAsDll.UseVisualStyleBackColor = True
        ' 
        ' btnRandomize
        ' 
        btnRandomize.BackColor = SystemColors.Desktop
        btnRandomize.FlatStyle = FlatStyle.Flat
        btnRandomize.ForeColor = SystemColors.Control
        btnRandomize.Location = New Point(261, 126)
        btnRandomize.Name = "btnRandomize"
        btnRandomize.Size = New Size(131, 25)
        btnRandomize.TabIndex = 6
        btnRandomize.Text = "Randomize"
        btnRandomize.UseVisualStyleBackColor = False
        ' 
        ' lOutputFileName
        ' 
        lOutputFileName.AutoSize = True
        lOutputFileName.Location = New Point(17, 110)
        lOutputFileName.Name = "lOutputFileName"
        lOutputFileName.Size = New Size(97, 15)
        lOutputFileName.TabIndex = 5
        lOutputFileName.Text = "Output file name"
        ' 
        ' lFileToBePacked
        ' 
        lFileToBePacked.AutoSize = True
        lFileToBePacked.Location = New Point(15, 28)
        lFileToBePacked.Name = "lFileToBePacked"
        lFileToBePacked.Size = New Size(96, 15)
        lFileToBePacked.TabIndex = 4
        lFileToBePacked.Text = "File to be packed"
        ' 
        ' btnBrowse
        ' 
        btnBrowse.BackColor = SystemColors.Desktop
        btnBrowse.FlatStyle = FlatStyle.Flat
        btnBrowse.ForeColor = SystemColors.Control
        btnBrowse.Location = New Point(260, 44)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.Size = New Size(131, 25)
        btnBrowse.TabIndex = 0
        btnBrowse.Text = "Browse"
        btnBrowse.UseVisualStyleBackColor = False
        ' 
        ' txtFileToBePacked
        ' 
        txtFileToBePacked.BackColor = SystemColors.InfoText
        txtFileToBePacked.ForeColor = Color.Lime
        txtFileToBePacked.Location = New Point(16, 46)
        txtFileToBePacked.Name = "txtFileToBePacked"
        txtFileToBePacked.Size = New Size(238, 23)
        txtFileToBePacked.TabIndex = 2
        txtFileToBePacked.Text = "C:\windows\system32\calc.exe"
        ' 
        ' txtOutputFileName
        ' 
        txtOutputFileName.BackColor = SystemColors.InfoText
        txtOutputFileName.ForeColor = Color.Lime
        txtOutputFileName.Location = New Point(17, 128)
        txtOutputFileName.Name = "txtOutputFileName"
        txtOutputFileName.Size = New Size(238, 23)
        txtOutputFileName.TabIndex = 3
        txtOutputFileName.Text = "something_random.exe"
        ' 
        ' gbExecution
        ' 
        gbExecution.Controls.Add(cbInjectionMethod)
        gbExecution.Controls.Add(cbBinFormat)
        gbExecution.Controls.Add(lBinaryFormat)
        gbExecution.Controls.Add(lInjectionMethod)
        gbExecution.ForeColor = SystemColors.Control
        gbExecution.Location = New Point(13, 537)
        gbExecution.Name = "gbExecution"
        gbExecution.Size = New Size(405, 129)
        gbExecution.TabIndex = 2
        gbExecution.TabStop = False
        gbExecution.Text = "Execution"
        ' 
        ' cbInjectionMethod
        ' 
        cbInjectionMethod.BackColor = SystemColors.InfoText
        cbInjectionMethod.DisplayMember = "0"
        cbInjectionMethod.DropDownStyle = ComboBoxStyle.DropDownList
        cbInjectionMethod.ForeColor = SystemColors.Control
        cbInjectionMethod.FormattingEnabled = True
        cbInjectionMethod.Location = New Point(15, 37)
        cbInjectionMethod.Name = "cbInjectionMethod"
        cbInjectionMethod.Size = New Size(379, 23)
        cbInjectionMethod.TabIndex = 11
        ' 
        ' cbBinFormat
        ' 
        cbBinFormat.BackColor = SystemColors.InfoText
        cbBinFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbBinFormat.Enabled = False
        cbBinFormat.ForeColor = SystemColors.Control
        cbBinFormat.FormattingEnabled = True
        cbBinFormat.Location = New Point(15, 93)
        cbBinFormat.Name = "cbBinFormat"
        cbBinFormat.Size = New Size(379, 23)
        cbBinFormat.TabIndex = 10
        ' 
        ' lBinaryFormat
        ' 
        lBinaryFormat.AutoSize = True
        lBinaryFormat.Location = New Point(14, 75)
        lBinaryFormat.Name = "lBinaryFormat"
        lBinaryFormat.Size = New Size(79, 15)
        lBinaryFormat.TabIndex = 9
        lBinaryFormat.Text = "Binary format"
        ' 
        ' lInjectionMethod
        ' 
        lInjectionMethod.AutoSize = True
        lInjectionMethod.Location = New Point(14, 19)
        lInjectionMethod.Name = "lInjectionMethod"
        lInjectionMethod.Size = New Size(98, 15)
        lInjectionMethod.TabIndex = 8
        lInjectionMethod.Text = "Injection method"
        ' 
        ' pbChineese
        ' 
        pbChineese.Image = CType(resources.GetObject("pbChineese.Image"), Image)
        pbChineese.InitialImage = CType(resources.GetObject("pbChineese.InitialImage"), Image)
        pbChineese.Location = New Point(18, 146)
        pbChineese.Name = "pbChineese"
        pbChineese.Size = New Size(675, 378)
        pbChineese.TabIndex = 20
        pbChineese.TabStop = False
        pbChineese.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(-1, 1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(720, 198)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' gbDebug
        ' 
        gbDebug.Controls.Add(btnClearLog)
        gbDebug.Controls.Add(cbKeepPrintMessages)
        gbDebug.Controls.Add(cbKeepTmpFile)
        gbDebug.ForeColor = SystemColors.Control
        gbDebug.Location = New Point(14, 467)
        gbDebug.Name = "gbDebug"
        gbDebug.Size = New Size(406, 57)
        gbDebug.TabIndex = 4
        gbDebug.TabStop = False
        gbDebug.Text = "Debug"
        ' 
        ' btnClearLog
        ' 
        btnClearLog.BackColor = Color.Orange
        btnClearLog.FlatStyle = FlatStyle.Flat
        btnClearLog.ForeColor = SystemColors.ActiveCaptionText
        btnClearLog.Location = New Point(260, 18)
        btnClearLog.Name = "btnClearLog"
        btnClearLog.Size = New Size(131, 25)
        btnClearLog.TabIndex = 7
        btnClearLog.Text = "Clear Log"
        btnClearLog.UseVisualStyleBackColor = False
        ' 
        ' cbKeepPrintMessages
        ' 
        cbKeepPrintMessages.AutoSize = True
        cbKeepPrintMessages.ForeColor = Color.Orange
        cbKeepPrintMessages.Location = New Point(114, 22)
        cbKeepPrintMessages.Name = "cbKeepPrintMessages"
        cbKeepPrintMessages.Size = New Size(134, 19)
        cbKeepPrintMessages.TabIndex = 18
        cbKeepPrintMessages.Text = "Keep print messages"
        cbKeepPrintMessages.UseVisualStyleBackColor = True
        ' 
        ' cbKeepTmpFile
        ' 
        cbKeepTmpFile.AutoSize = True
        cbKeepTmpFile.ForeColor = Color.Orange
        cbKeepTmpFile.Location = New Point(12, 22)
        cbKeepTmpFile.Name = "cbKeepTmpFile"
        cbKeepTmpFile.Size = New Size(96, 19)
        cbKeepTmpFile.TabIndex = 19
        cbKeepTmpFile.Text = "Keep tmp file"
        cbKeepTmpFile.UseVisualStyleBackColor = True
        ' 
        ' llLinkedIn
        ' 
        llLinkedIn.AutoSize = True
        llLinkedIn.LinkColor = Color.Lime
        llLinkedIn.Location = New Point(13, 9)
        llLinkedIn.Name = "llLinkedIn"
        llLinkedIn.Size = New Size(76, 15)
        llLinkedIn.TabIndex = 5
        llLinkedIn.TabStop = True
        llLinkedIn.Text = ".:: LinkedIn ::."
        ' 
        ' llGithubLink
        ' 
        llGithubLink.AutoSize = True
        llGithubLink.LinkColor = Color.Lime
        llGithubLink.Location = New Point(95, 9)
        llGithubLink.Name = "llGithubLink"
        llGithubLink.Size = New Size(69, 15)
        llGithubLink.TabIndex = 6
        llGithubLink.TabStop = True
        llGithubLink.Text = ".:: GitHub ::."
        ' 
        ' llMediumLink
        ' 
        llMediumLink.AccessibleDescription = "https://medium.com/@0x0vid"
        llMediumLink.AccessibleName = "https://medium.com/@0x0vid"
        llMediumLink.AccessibleRole = AccessibleRole.Application
        llMediumLink.AutoSize = True
        llMediumLink.LinkColor = Color.Lime
        llMediumLink.Location = New Point(170, 9)
        llMediumLink.Name = "llMediumLink"
        llMediumLink.Size = New Size(76, 15)
        llMediumLink.TabIndex = 7
        llMediumLink.TabStop = True
        llMediumLink.Tag = "https://medium.com/@0x0vid"
        llMediumLink.Text = ".:: Medium ::."
        ' 
        ' Panel1
        ' 
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(cbLanguage)
        Panel1.Controls.Add(lIntro)
        Panel1.Controls.Add(llLinkedIn)
        Panel1.Controls.Add(llMediumLink)
        Panel1.Controls.Add(llGithubLink)
        Panel1.Location = New Point(-1, 205)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(720, 74)
        Panel1.TabIndex = 8
        ' 
        ' cbLanguage
        ' 
        cbLanguage.BackColor = SystemColors.Control
        cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList
        cbLanguage.FormattingEnabled = True
        cbLanguage.Location = New Point(662, 3)
        cbLanguage.Name = "cbLanguage"
        cbLanguage.Size = New Size(53, 23)
        cbLanguage.TabIndex = 9
        ' 
        ' lIntro
        ' 
        lIntro.AutoSize = True
        lIntro.ForeColor = Color.Cyan
        lIntro.Location = New Point(13, 33)
        lIntro.Name = "lIntro"
        lIntro.Size = New Size(638, 30)
        lIntro.TabIndex = 8
        lIntro.Text = "This tool is intended for educational purposes only. " & vbCrLf & "The author is not responsible for any damages, unauthorized access, or illegal activities that may arise from this content."
        ' 
        ' gbSandbox
        ' 
        gbSandbox.Controls.Add(cbCheckSleep)
        gbSandbox.Controls.Add(lDelay)
        gbSandbox.Controls.Add(numDelayExecution)
        gbSandbox.Controls.Add(cbCheckUsername)
        gbSandbox.Controls.Add(cbCheckVM)
        gbSandbox.Controls.Add(cbCheckRAM)
        gbSandbox.Controls.Add(lDelayExecution)
        gbSandbox.Controls.Add(cbDelayExecution)
        gbSandbox.Controls.Add(GroupBox5)
        gbSandbox.ForeColor = SystemColors.Control
        gbSandbox.Location = New Point(10, 773)
        gbSandbox.Name = "gbSandbox"
        gbSandbox.Size = New Size(693, 88)
        gbSandbox.TabIndex = 9
        gbSandbox.TabStop = False
        gbSandbox.Text = "Evasion - Sandbox"
        ' 
        ' cbCheckSleep
        ' 
        cbCheckSleep.AutoSize = True
        cbCheckSleep.ForeColor = Color.Magenta
        cbCheckSleep.Location = New Point(360, 50)
        cbCheckSleep.Name = "cbCheckSleep"
        cbCheckSleep.Size = New Size(89, 19)
        cbCheckSleep.TabIndex = 18
        cbCheckSleep.Text = "Check sleep"
        cbCheckSleep.UseVisualStyleBackColor = True
        ' 
        ' lDelay
        ' 
        lDelay.AutoSize = True
        lDelay.Location = New Point(466, 24)
        lDelay.Name = "lDelay"
        lDelay.Size = New Size(121, 15)
        lDelay.TabIndex = 17
        lDelay.Text = "Min. delay in seconds"
        ' 
        ' numDelayExecution
        ' 
        numDelayExecution.BackColor = Color.Cyan
        numDelayExecution.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        numDelayExecution.Location = New Point(593, 22)
        numDelayExecution.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        numDelayExecution.Name = "numDelayExecution"
        numDelayExecution.Size = New Size(83, 23)
        numDelayExecution.TabIndex = 16
        numDelayExecution.Value = New Decimal(New Integer() {6, 0, 0, 0})
        ' 
        ' cbCheckUsername
        ' 
        cbCheckUsername.AutoSize = True
        cbCheckUsername.ForeColor = Color.Magenta
        cbCheckUsername.Location = New Point(240, 51)
        cbCheckUsername.Name = "cbCheckUsername"
        cbCheckUsername.Size = New Size(114, 19)
        cbCheckUsername.TabIndex = 15
        cbCheckUsername.Text = "Check username"
        cbCheckUsername.UseVisualStyleBackColor = True
        ' 
        ' cbCheckVM
        ' 
        cbCheckVM.AutoSize = True
        cbCheckVM.ForeColor = Color.Magenta
        cbCheckVM.Location = New Point(136, 51)
        cbCheckVM.Name = "cbCheckVM"
        cbCheckVM.Size = New Size(98, 19)
        cbCheckVM.TabIndex = 14
        cbCheckVM.Text = "Check for VM"
        cbCheckVM.UseVisualStyleBackColor = True
        ' 
        ' cbCheckRAM
        ' 
        cbCheckRAM.AutoSize = True
        cbCheckRAM.ForeColor = Color.Magenta
        cbCheckRAM.Location = New Point(12, 51)
        cbCheckRAM.Name = "cbCheckRAM"
        cbCheckRAM.Size = New Size(114, 19)
        cbCheckRAM.TabIndex = 3
        cbCheckRAM.Text = "Check host RAM"
        cbCheckRAM.UseVisualStyleBackColor = True
        ' 
        ' lDelayExecution
        ' 
        lDelayExecution.AutoSize = True
        lDelayExecution.Location = New Point(12, 25)
        lDelayExecution.Name = "lDelayExecution"
        lDelayExecution.Size = New Size(91, 15)
        lDelayExecution.TabIndex = 13
        lDelayExecution.Text = "Delay Execution"
        ' 
        ' cbDelayExecution
        ' 
        cbDelayExecution.BackColor = SystemColors.InfoText
        cbDelayExecution.DropDownStyle = ComboBoxStyle.DropDownList
        cbDelayExecution.ForeColor = SystemColors.Control
        cbDelayExecution.FormattingEnabled = True
        cbDelayExecution.Location = New Point(109, 21)
        cbDelayExecution.Name = "cbDelayExecution"
        cbDelayExecution.Size = New Size(335, 23)
        cbDelayExecution.TabIndex = 13
        ' 
        ' GroupBox5
        ' 
        GroupBox5.ForeColor = SystemColors.Control
        GroupBox5.Location = New Point(0, 109)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(689, 89)
        GroupBox5.TabIndex = 10
        GroupBox5.TabStop = False
        GroupBox5.Text = "Evasion - EDR"
        ' 
        ' gbEDR
        ' 
        gbEDR.Controls.Add(cbUserInput)
        gbEDR.Controls.Add(cbPatchETW)
        gbEDR.Controls.Add(cbUnhookNtDll)
        gbEDR.Controls.Add(lSyscallObf)
        gbEDR.Controls.Add(cbSysCall)
        gbEDR.Controls.Add(GroupBox7)
        gbEDR.ForeColor = SystemColors.Control
        gbEDR.Location = New Point(10, 867)
        gbEDR.Name = "gbEDR"
        gbEDR.Size = New Size(693, 88)
        gbEDR.TabIndex = 16
        gbEDR.TabStop = False
        gbEDR.Text = "Evasion - EDR"
        ' 
        ' cbUserInput
        ' 
        cbUserInput.AutoSize = True
        cbUserInput.ForeColor = Color.Magenta
        cbUserInput.Location = New Point(224, 51)
        cbUserInput.Name = "cbUserInput"
        cbUserInput.Size = New Size(124, 19)
        cbUserInput.TabIndex = 15
        cbUserInput.Text = "Wait for user input"
        cbUserInput.UseVisualStyleBackColor = True
        ' 
        ' cbPatchETW
        ' 
        cbPatchETW.AutoSize = True
        cbPatchETW.ForeColor = Color.Magenta
        cbPatchETW.Location = New Point(136, 51)
        cbPatchETW.Name = "cbPatchETW"
        cbPatchETW.Size = New Size(82, 19)
        cbPatchETW.TabIndex = 14
        cbPatchETW.Text = "Patch ETW"
        cbPatchETW.UseVisualStyleBackColor = True
        ' 
        ' cbUnhookNtDll
        ' 
        cbUnhookNtDll.AutoSize = True
        cbUnhookNtDll.ForeColor = Color.Magenta
        cbUnhookNtDll.Location = New Point(16, 51)
        cbUnhookNtDll.Name = "cbUnhookNtDll"
        cbUnhookNtDll.Size = New Size(98, 19)
        cbUnhookNtDll.TabIndex = 3
        cbUnhookNtDll.Text = "Unhook NtDll"
        cbUnhookNtDll.UseVisualStyleBackColor = True
        ' 
        ' lSyscallObf
        ' 
        lSyscallObf.AutoSize = True
        lSyscallObf.Location = New Point(12, 25)
        lSyscallObf.Name = "lSyscallObf"
        lSyscallObf.Size = New Size(108, 15)
        lSyscallObf.TabIndex = 13
        lSyscallObf.Text = "Syscall obfuscation"
        ' 
        ' cbSysCall
        ' 
        cbSysCall.BackColor = SystemColors.InfoText
        cbSysCall.DropDownStyle = ComboBoxStyle.DropDownList
        cbSysCall.ForeColor = SystemColors.Control
        cbSysCall.FormattingEnabled = True
        cbSysCall.Location = New Point(126, 22)
        cbSysCall.Name = "cbSysCall"
        cbSysCall.Size = New Size(550, 23)
        cbSysCall.TabIndex = 13
        ' 
        ' GroupBox7
        ' 
        GroupBox7.ForeColor = SystemColors.Control
        GroupBox7.Location = New Point(0, 109)
        GroupBox7.Name = "GroupBox7"
        GroupBox7.Size = New Size(689, 89)
        GroupBox7.TabIndex = 10
        GroupBox7.TabStop = False
        GroupBox7.Text = "Evasion - EDR"
        ' 
        ' cbLowEntropy
        ' 
        cbLowEntropy.AutoSize = True
        cbLowEntropy.ForeColor = Color.Magenta
        cbLowEntropy.Location = New Point(15, 22)
        cbLowEntropy.Name = "cbLowEntropy"
        cbLowEntropy.Size = New Size(92, 19)
        cbLowEntropy.TabIndex = 16
        cbLowEntropy.Text = "Low Entropy"
        cbLowEntropy.UseVisualStyleBackColor = True
        ' 
        ' gbOutputLog
        ' 
        gbOutputLog.Controls.Add(txtOutputLog)
        gbOutputLog.ForeColor = SystemColors.Control
        gbOutputLog.Location = New Point(425, 285)
        gbOutputLog.Name = "gbOutputLog"
        gbOutputLog.Size = New Size(282, 418)
        gbOutputLog.TabIndex = 17
        gbOutputLog.TabStop = False
        gbOutputLog.Text = "Output log"
        ' 
        ' txtOutputLog
        ' 
        txtOutputLog.BackColor = Color.FromArgb(CByte(20), CByte(19), CByte(21))
        txtOutputLog.BorderStyle = BorderStyle.FixedSingle
        txtOutputLog.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtOutputLog.ForeColor = Color.Lime
        txtOutputLog.Location = New Point(9, 23)
        txtOutputLog.MinimumSize = New Size(263, 23)
        txtOutputLog.Multiline = True
        txtOutputLog.Name = "txtOutputLog"
        txtOutputLog.ScrollBars = ScrollBars.Vertical
        txtOutputLog.Size = New Size(263, 382)
        txtOutputLog.TabIndex = 0
        ' 
        ' btnGenerateBinary
        ' 
        btnGenerateBinary.BackColor = Color.Gold
        btnGenerateBinary.FlatStyle = FlatStyle.Popup
        btnGenerateBinary.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        btnGenerateBinary.ForeColor = SystemColors.Desktop
        btnGenerateBinary.Location = New Point(10, 971)
        btnGenerateBinary.Name = "btnGenerateBinary"
        btnGenerateBinary.Size = New Size(693, 46)
        btnGenerateBinary.TabIndex = 7
        btnGenerateBinary.Text = "=-----=[ Generate ]=-----="
        btnGenerateBinary.UseVisualStyleBackColor = False
        ' 
        ' cbFakeSignature
        ' 
        cbFakeSignature.AutoSize = True
        cbFakeSignature.ForeColor = Color.Magenta
        cbFakeSignature.Location = New Point(110, 22)
        cbFakeSignature.Name = "cbFakeSignature"
        cbFakeSignature.Size = New Size(103, 19)
        cbFakeSignature.TabIndex = 17
        cbFakeSignature.Text = "Fake Signature"
        cbFakeSignature.UseVisualStyleBackColor = True
        ' 
        ' gbStatic
        ' 
        gbStatic.Controls.Add(cbFakeSignature)
        gbStatic.Controls.Add(GroupBox9)
        gbStatic.Controls.Add(cbLowEntropy)
        gbStatic.ForeColor = SystemColors.Control
        gbStatic.Location = New Point(10, 709)
        gbStatic.Name = "gbStatic"
        gbStatic.Size = New Size(693, 58)
        gbStatic.TabIndex = 19
        gbStatic.TabStop = False
        gbStatic.Text = "Evasion - Static"
        ' 
        ' GroupBox9
        ' 
        GroupBox9.ForeColor = SystemColors.Control
        GroupBox9.Location = New Point(0, 109)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(689, 89)
        GroupBox9.TabIndex = 10
        GroupBox9.TabStop = False
        GroupBox9.Text = "Evasion - EDR"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(10, 131)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(697, 400)
        PictureBox2.TabIndex = 21
        PictureBox2.TabStop = False
        ' 
        ' fMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Desktop
        ClientSize = New Size(719, 1029)
        Controls.Add(gbStatic)
        Controls.Add(btnGenerateBinary)
        Controls.Add(gbOutputLog)
        Controls.Add(gbEDR)
        Controls.Add(gbSandbox)
        Controls.Add(Panel1)
        Controls.Add(gbDebug)
        Controls.Add(PictureBox1)
        Controls.Add(gbExecution)
        Controls.Add(gbPayload)
        Controls.Add(PictureBox2)
        Controls.Add(pbChineese)
        ForeColor = SystemColors.Control
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "fMain"
        Text = "farsidePackerGUI"
        gbPayload.ResumeLayout(False)
        gbPayload.PerformLayout()
        gbExecution.ResumeLayout(False)
        gbExecution.PerformLayout()
        CType(pbChineese, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        gbDebug.ResumeLayout(False)
        gbDebug.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        gbSandbox.ResumeLayout(False)
        gbSandbox.PerformLayout()
        CType(numDelayExecution, ComponentModel.ISupportInitialize).EndInit()
        gbEDR.ResumeLayout(False)
        gbEDR.PerformLayout()
        gbOutputLog.ResumeLayout(False)
        gbOutputLog.PerformLayout()
        gbStatic.ResumeLayout(False)
        gbStatic.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents gbPayload As GroupBox
    Friend WithEvents txtFileToBePacked As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents gbExecution As GroupBox
    Friend WithEvents lFileToBePacked As Label
    Friend WithEvents btnRandomize As Button
    Friend WithEvents lOutputFileName As Label
    Friend WithEvents cbInjectionTarget As ComboBox
    Friend WithEvents cbInjectionMethod As ComboBox
    Friend WithEvents cbBinFormat As ComboBox
    Friend WithEvents lBinaryFormat As Label
    Friend WithEvents lInjectionMethod As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents gbDebug As GroupBox
    Friend WithEvents llLinkedIn As LinkLabel
    Friend WithEvents llGithubLink As LinkLabel
    Friend WithEvents llMediumLink As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lIntro As Label
    Friend WithEvents gbSandbox As GroupBox
    Friend WithEvents cbCheckUsername As CheckBox
    Friend WithEvents cbCheckVM As CheckBox
    Friend WithEvents cbCheckRAM As CheckBox
    Friend WithEvents lDelayExecution As Label
    Friend WithEvents cbDelayExecution As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents gbEDR As GroupBox
    Friend WithEvents cbPatchETW As CheckBox
    Friend WithEvents cbUnhookNtDll As CheckBox
    Friend WithEvents lSyscallObf As Label
    Friend WithEvents cbSysCall As ComboBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents gbOutputLog As GroupBox
    Friend WithEvents txtOutputLog As TextBox
    Friend WithEvents btnGenerateBinary As Button
    Friend WithEvents txtOutputFileName As TextBox
    Friend WithEvents lDelay As Label
    Friend WithEvents numDelayExecution As NumericUpDown
    Friend WithEvents cbCheckSleep As CheckBox
    Friend WithEvents cbKeepTmpFile As CheckBox
    Friend WithEvents cbUserInput As CheckBox
    Friend WithEvents cbLowEntropy As CheckBox
    Friend WithEvents cbKeepPrintMessages As CheckBox
    Friend WithEvents cbFakeSignature As CheckBox
    Friend WithEvents gbStatic As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents btnClearLog As Button
    Friend WithEvents cbLanguage As ComboBox
    Friend WithEvents pbChineese As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents pbRussian As PictureBox
    Friend WithEvents cbAsDll As CheckBox
End Class
