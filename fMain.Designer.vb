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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(fMain))
        GroupBox1 = New GroupBox()
        btnRandomize = New Button()
        Label3 = New Label()
        Label2 = New Label()
        btnBrowse = New Button()
        txtFileToBePacked = New TextBox()
        txtOutputFileName = New TextBox()
        GroupBox2 = New GroupBox()
        cbInjectionMethod = New ComboBox()
        cbBinFormat = New ComboBox()
        Label5 = New Label()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        gbDebug = New GroupBox()
        btnClearLog = New Button()
        cbKeepPrintMessages = New CheckBox()
        cbKeepTmpFile = New CheckBox()
        llLinkedIn = New LinkLabel()
        llGithubLink = New LinkLabel()
        llMediumLink = New LinkLabel()
        Panel1 = New Panel()
        Label6 = New Label()
        GroupBox4 = New GroupBox()
        cbCheckSleep = New CheckBox()
        Label9 = New Label()
        numDelayExecution = New NumericUpDown()
        cbCheckUsername = New CheckBox()
        cbCheckVM = New CheckBox()
        cbCheckRAM = New CheckBox()
        Label7 = New Label()
        cbDelayExecution = New ComboBox()
        GroupBox5 = New GroupBox()
        GroupBox6 = New GroupBox()
        cbUserInput = New CheckBox()
        cbPatchETW = New CheckBox()
        cbUnhookNtDll = New CheckBox()
        Label8 = New Label()
        cbSysCall = New ComboBox()
        GroupBox7 = New GroupBox()
        cbLowEntropy = New CheckBox()
        GroupBox8 = New GroupBox()
        txtOutputLog = New TextBox()
        btnGenerateBinary = New Button()
        cbFakeSignature = New CheckBox()
        GroupBox3 = New GroupBox()
        GroupBox9 = New GroupBox()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        gbDebug.SuspendLayout()
        Panel1.SuspendLayout()
        GroupBox4.SuspendLayout()
        CType(numDelayExecution, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox6.SuspendLayout()
        GroupBox8.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnRandomize)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(btnBrowse)
        GroupBox1.Controls.Add(txtFileToBePacked)
        GroupBox1.Controls.Add(txtOutputFileName)
        GroupBox1.ForeColor = SystemColors.Control
        GroupBox1.Location = New Point(14, 285)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(405, 145)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Payload"
        ' 
        ' btnRandomize
        ' 
        btnRandomize.BackColor = SystemColors.Desktop
        btnRandomize.FlatStyle = FlatStyle.Flat
        btnRandomize.ForeColor = SystemColors.Control
        btnRandomize.Location = New Point(260, 98)
        btnRandomize.Name = "btnRandomize"
        btnRandomize.Size = New Size(131, 25)
        btnRandomize.TabIndex = 6
        btnRandomize.Text = "Randomize"
        btnRandomize.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(15, 82)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 15)
        Label3.TabIndex = 5
        Label3.Text = "Output file name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 15)
        Label2.TabIndex = 4
        Label2.Text = "File to be packed"
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
        txtOutputFileName.Location = New Point(16, 100)
        txtOutputFileName.Name = "txtOutputFileName"
        txtOutputFileName.Size = New Size(238, 23)
        txtOutputFileName.TabIndex = 3
        txtOutputFileName.Text = "something_random.exe"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(cbInjectionMethod)
        GroupBox2.Controls.Add(cbBinFormat)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.ForeColor = SystemColors.Control
        GroupBox2.Location = New Point(14, 498)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(405, 129)
        GroupBox2.TabIndex = 2
        GroupBox2.TabStop = False
        GroupBox2.Text = "Execution"
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
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(14, 75)
        Label5.Name = "Label5"
        Label5.Size = New Size(79, 15)
        Label5.TabIndex = 9
        Label5.Text = "Binary format"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(14, 19)
        Label4.Name = "Label4"
        Label4.Size = New Size(98, 15)
        Label4.TabIndex = 8
        Label4.Text = "Injection Method"
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
        gbDebug.Location = New Point(14, 436)
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
        cbKeepPrintMessages.Text = "Keep Print messages"
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
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(llLinkedIn)
        Panel1.Controls.Add(llMediumLink)
        Panel1.Controls.Add(llGithubLink)
        Panel1.Location = New Point(-1, 205)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(720, 74)
        Panel1.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ForeColor = Color.Cyan
        Label6.Location = New Point(13, 33)
        Label6.Name = "Label6"
        Label6.Size = New Size(638, 30)
        Label6.TabIndex = 8
        Label6.Text = "This tool is intended for educational purposes only. " & vbCrLf & "The author is not responsible for any damages, unauthorized access, or illegal activities that may arise from this content."
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(cbCheckSleep)
        GroupBox4.Controls.Add(Label9)
        GroupBox4.Controls.Add(numDelayExecution)
        GroupBox4.Controls.Add(cbCheckUsername)
        GroupBox4.Controls.Add(cbCheckVM)
        GroupBox4.Controls.Add(cbCheckRAM)
        GroupBox4.Controls.Add(Label7)
        GroupBox4.Controls.Add(cbDelayExecution)
        GroupBox4.Controls.Add(GroupBox5)
        GroupBox4.ForeColor = SystemColors.Control
        GroupBox4.Location = New Point(13, 713)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(693, 88)
        GroupBox4.TabIndex = 9
        GroupBox4.TabStop = False
        GroupBox4.Text = "Evasion - Sandbox"
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
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(466, 24)
        Label9.Name = "Label9"
        Label9.Size = New Size(121, 15)
        Label9.TabIndex = 17
        Label9.Text = "Min. delay in seconds"
        ' 
        ' numDelayExecution
        ' 
        numDelayExecution.BackColor = Color.Cyan
        numDelayExecution.Increment = New [Decimal](New Integer() {5, 0, 0, 0})
        numDelayExecution.Location = New Point(593, 22)
        numDelayExecution.Maximum = New [Decimal](New Integer() {99999, 0, 0, 0})
        numDelayExecution.Name = "numDelayExecution"
        numDelayExecution.Size = New Size(83, 23)
        numDelayExecution.TabIndex = 16
        numDelayExecution.Value = New [Decimal](New Integer() {6, 0, 0, 0})
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
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(12, 25)
        Label7.Name = "Label7"
        Label7.Size = New Size(91, 15)
        Label7.TabIndex = 13
        Label7.Text = "Delay Execution"
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
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(cbUserInput)
        GroupBox6.Controls.Add(cbPatchETW)
        GroupBox6.Controls.Add(cbUnhookNtDll)
        GroupBox6.Controls.Add(Label8)
        GroupBox6.Controls.Add(cbSysCall)
        GroupBox6.Controls.Add(GroupBox7)
        GroupBox6.ForeColor = SystemColors.Control
        GroupBox6.Location = New Point(13, 807)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(693, 88)
        GroupBox6.TabIndex = 16
        GroupBox6.TabStop = False
        GroupBox6.Text = "Evasion - EDR"
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
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(12, 25)
        Label8.Name = "Label8"
        Label8.Size = New Size(108, 15)
        Label8.TabIndex = 13
        Label8.Text = "Syscall obfuscation"
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
        ' GroupBox8
        ' 
        GroupBox8.Controls.Add(txtOutputLog)
        GroupBox8.ForeColor = SystemColors.Control
        GroupBox8.Location = New Point(425, 285)
        GroupBox8.Name = "GroupBox8"
        GroupBox8.Size = New Size(282, 342)
        GroupBox8.TabIndex = 17
        GroupBox8.TabStop = False
        GroupBox8.Text = "Output log"
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
        txtOutputLog.Size = New Size(263, 311)
        txtOutputLog.TabIndex = 0
        ' 
        ' btnGenerateBinary
        ' 
        btnGenerateBinary.BackColor = Color.Gold
        btnGenerateBinary.FlatStyle = FlatStyle.Popup
        btnGenerateBinary.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        btnGenerateBinary.ForeColor = SystemColors.Desktop
        btnGenerateBinary.Location = New Point(12, 907)
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
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(cbFakeSignature)
        GroupBox3.Controls.Add(GroupBox9)
        GroupBox3.Controls.Add(cbLowEntropy)
        GroupBox3.ForeColor = SystemColors.Control
        GroupBox3.Location = New Point(13, 649)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(693, 58)
        GroupBox3.TabIndex = 19
        GroupBox3.TabStop = False
        GroupBox3.Text = "Evasion - Static"
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
        ' fMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Desktop
        ClientSize = New Size(719, 965)
        Controls.Add(GroupBox3)
        Controls.Add(btnGenerateBinary)
        Controls.Add(GroupBox8)
        Controls.Add(GroupBox6)
        Controls.Add(GroupBox4)
        Controls.Add(Panel1)
        Controls.Add(gbDebug)
        Controls.Add(PictureBox1)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        ForeColor = SystemColors.Control
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "fMain"
        Text = "farsidePackerGUI"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        gbDebug.ResumeLayout(False)
        gbDebug.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        CType(numDelayExecution, ComponentModel.ISupportInitialize).EndInit()
        GroupBox6.ResumeLayout(False)
        GroupBox6.PerformLayout()
        GroupBox8.ResumeLayout(False)
        GroupBox8.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFileToBePacked As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnRandomize As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbInjectionTarget As ComboBox
    Friend WithEvents cbInjectionMethod As ComboBox
    Friend WithEvents cbBinFormat As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents gbDebug As GroupBox
    Friend WithEvents llLinkedIn As LinkLabel
    Friend WithEvents llGithubLink As LinkLabel
    Friend WithEvents llMediumLink As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cbCheckUsername As CheckBox
    Friend WithEvents cbCheckVM As CheckBox
    Friend WithEvents cbCheckRAM As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbDelayExecution As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cbPatchETW As CheckBox
    Friend WithEvents cbUnhookNtDll As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbSysCall As ComboBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents txtOutputLog As TextBox
    Friend WithEvents btnGenerateBinary As Button
    Friend WithEvents txtOutputFileName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents numDelayExecution As NumericUpDown
    Friend WithEvents cbCheckSleep As CheckBox
    Friend WithEvents cbKeepTmpFile As CheckBox
    Friend WithEvents cbUserInput As CheckBox
    Friend WithEvents cbLowEntropy As CheckBox
    Friend WithEvents cbKeepPrintMessages As CheckBox
    Friend WithEvents cbFakeSignature As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents btnClearLog As Button
End Class
