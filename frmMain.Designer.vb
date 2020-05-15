<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOBLocation = New System.Windows.Forms.TextBox()
        Me.txtCurrentVersion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExeLocation = New System.Windows.Forms.Button()
        Me.chkNotUpdateEnviromentINI = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.gpSettings = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.PBar1 = New System.Windows.Forms.ProgressBar()
        Me.mnuSkipUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpSettings.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(12, 246)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(445, 45)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Check for Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(12, 76)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(445, 164)
        Me.txtLog.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "OB Location:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Current Version:"
        '
        'txtOBLocation
        '
        Me.txtOBLocation.Location = New System.Drawing.Point(100, 28)
        Me.txtOBLocation.Name = "txtOBLocation"
        Me.txtOBLocation.Size = New System.Drawing.Size(287, 20)
        Me.txtOBLocation.TabIndex = 4
        '
        'txtCurrentVersion
        '
        Me.txtCurrentVersion.Location = New System.Drawing.Point(100, 53)
        Me.txtCurrentVersion.Name = "txtCurrentVersion"
        Me.txtCurrentVersion.Size = New System.Drawing.Size(154, 20)
        Me.txtCurrentVersion.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label3.Location = New System.Drawing.Point(260, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "example:  1.2.1#648  or leave empty"
        '
        'btnExeLocation
        '
        Me.btnExeLocation.Location = New System.Drawing.Point(393, 27)
        Me.btnExeLocation.Name = "btnExeLocation"
        Me.btnExeLocation.Size = New System.Drawing.Size(41, 20)
        Me.btnExeLocation.TabIndex = 7
        Me.btnExeLocation.Text = "..."
        Me.btnExeLocation.UseVisualStyleBackColor = True
        '
        'chkNotUpdateEnviromentINI
        '
        Me.chkNotUpdateEnviromentINI.AutoSize = True
        Me.chkNotUpdateEnviromentINI.Location = New System.Drawing.Point(15, 79)
        Me.chkNotUpdateEnviromentINI.Name = "chkNotUpdateEnviromentINI"
        Me.chkNotUpdateEnviromentINI.Size = New System.Drawing.Size(188, 17)
        Me.chkNotUpdateEnviromentINI.TabIndex = 9
        Me.chkNotUpdateEnviromentINI.Text = "Don't update my ""Environment.ini"""
        Me.chkNotUpdateEnviromentINI.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label4.Location = New System.Drawing.Point(13, 294)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Beware:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label5.Location = New System.Drawing.Point(57, 294)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(214, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Update process causes OpenBullet to close"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Gray
        Me.lblStatus.Location = New System.Drawing.Point(12, 31)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(445, 33)
        Me.lblStatus.TabIndex = 12
        Me.lblStatus.Text = "-------------"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpSettings
        '
        Me.gpSettings.Controls.Add(Me.Label6)
        Me.gpSettings.Controls.Add(Me.btnSaveSettings)
        Me.gpSettings.Controls.Add(Me.txtOBLocation)
        Me.gpSettings.Controls.Add(Me.Label1)
        Me.gpSettings.Controls.Add(Me.Label2)
        Me.gpSettings.Controls.Add(Me.txtCurrentVersion)
        Me.gpSettings.Controls.Add(Me.chkNotUpdateEnviromentINI)
        Me.gpSettings.Controls.Add(Me.Label3)
        Me.gpSettings.Controls.Add(Me.btnExeLocation)
        Me.gpSettings.Enabled = False
        Me.gpSettings.Location = New System.Drawing.Point(12, 333)
        Me.gpSettings.Name = "gpSettings"
        Me.gpSettings.Size = New System.Drawing.Size(445, 141)
        Me.gpSettings.TabIndex = 13
        Me.gpSettings.TabStop = False
        Me.gpSettings.Text = " Settings "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(77, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "*"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(15, 102)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(419, 27)
        Me.btnSaveSettings.TabIndex = 10
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettings, Me.mnuSkipUpdate})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(468, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(61, 20)
        Me.mnuSettings.Text = "Settings"
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(12, 64)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(445, 10)
        Me.PBar1.TabIndex = 15
        Me.PBar1.Visible = False
        '
        'mnuSkipUpdate
        '
        Me.mnuSkipUpdate.BackColor = System.Drawing.Color.SkyBlue
        Me.mnuSkipUpdate.Enabled = False
        Me.mnuSkipUpdate.Name = "mnuSkipUpdate"
        Me.mnuSkipUpdate.Size = New System.Drawing.Size(82, 20)
        Me.mnuSkipUpdate.Text = "Skip Update"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 486)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.gpSettings)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unofficial OB Updater"
        Me.gpSettings.ResumeLayout(False)
        Me.gpSettings.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtLog As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOBLocation As TextBox
    Friend WithEvents txtCurrentVersion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnExeLocation As Button
    Friend WithEvents chkNotUpdateEnviromentINI As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents gpSettings As GroupBox
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuSettings As ToolStripMenuItem
    Friend WithEvents PBar1 As ProgressBar
    Friend WithEvents Label6 As Label
    Friend WithEvents mnuSkipUpdate As ToolStripMenuItem
End Class
