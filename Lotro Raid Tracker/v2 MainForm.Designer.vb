<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
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
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.LabelSkirmishName = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CharacterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddCharacterMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuResetCharacter = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCharacterMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCompleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddRaidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCompleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.CharacterSelector = New System.Windows.Forms.ComboBox()
        Me.CmdNotComplete = New System.Windows.Forms.Button()
        Me.cmdComplete = New System.Windows.Forms.Button()
        Me.RaidPicker = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdDeleteCharacter = New System.Windows.Forms.Button()
        Me.cmdAddCharacter = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelSkirmishName
        '
        Me.LabelSkirmishName.AutoSize = True
        Me.LabelSkirmishName.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelSkirmishName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelSkirmishName.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.LabelSkirmishName.Location = New System.Drawing.Point(247, 117)
        Me.LabelSkirmishName.Name = "LabelSkirmishName"
        Me.LabelSkirmishName.Size = New System.Drawing.Size(205, 17)
        Me.LabelSkirmishName.TabIndex = 18
        Me.LabelSkirmishName.Text = "Skirmish Completion Status"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem, Me.cmdCompleteAll, Me.cmdReset})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(693, 24)
        Me.MenuStrip1.TabIndex = 40
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CharacterToolStripMenuItem, Me.AddRaidToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'CharacterToolStripMenuItem
        '
        Me.CharacterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddCharacterMenu, Me.menuResetCharacter, Me.DeleteCharacterMenu, Me.menuCompleteAll})
        Me.CharacterToolStripMenuItem.Name = "CharacterToolStripMenuItem"
        Me.CharacterToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.CharacterToolStripMenuItem.Text = "&Character"
        '
        'AddCharacterMenu
        '
        Me.AddCharacterMenu.Name = "AddCharacterMenu"
        Me.AddCharacterMenu.Size = New System.Drawing.Size(202, 22)
        Me.AddCharacterMenu.Text = "&Add Character"
        '
        'menuResetCharacter
        '
        Me.menuResetCharacter.Name = "menuResetCharacter"
        Me.menuResetCharacter.Size = New System.Drawing.Size(202, 22)
        Me.menuResetCharacter.Text = "&Reset Character"
        '
        'DeleteCharacterMenu
        '
        Me.DeleteCharacterMenu.Name = "DeleteCharacterMenu"
        Me.DeleteCharacterMenu.Size = New System.Drawing.Size(202, 22)
        Me.DeleteCharacterMenu.Text = "&Delete Character"
        '
        'menuCompleteAll
        '
        Me.menuCompleteAll.Name = "menuCompleteAll"
        Me.menuCompleteAll.Size = New System.Drawing.Size(202, 22)
        Me.menuCompleteAll.Text = "Complete All Skirmishes"
        '
        'AddRaidToolStripMenuItem
        '
        Me.AddRaidToolStripMenuItem.Enabled = False
        Me.AddRaidToolStripMenuItem.Name = "AddRaidToolStripMenuItem"
        Me.AddRaidToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.AddRaidToolStripMenuItem.Text = "&Add Raid"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupportToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        Me.SupportToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SupportToolStripMenuItem.Text = "&Support"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'cmdCompleteAll
        '
        Me.cmdCompleteAll.Name = "cmdCompleteAll"
        Me.cmdCompleteAll.Size = New System.Drawing.Size(147, 20)
        Me.cmdCompleteAll.Text = "Complete All Skirmishes"
        '
        'cmdReset
        '
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(106, 20)
        Me.cmdReset.Text = "Reset Skirmishes"
        '
        'CharacterSelector
        '
        Me.CharacterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CharacterSelector.FormattingEnabled = True
        Me.CharacterSelector.Location = New System.Drawing.Point(9, 52)
        Me.CharacterSelector.Name = "CharacterSelector"
        Me.CharacterSelector.Size = New System.Drawing.Size(220, 21)
        Me.CharacterSelector.Sorted = True
        Me.CharacterSelector.TabIndex = 41
        '
        'CmdNotComplete
        '
        Me.CmdNotComplete.Location = New System.Drawing.Point(597, 79)
        Me.CmdNotComplete.Name = "CmdNotComplete"
        Me.CmdNotComplete.Size = New System.Drawing.Size(86, 23)
        Me.CmdNotComplete.TabIndex = 2
        Me.CmdNotComplete.Text = "Not Completed"
        Me.CmdNotComplete.UseVisualStyleBackColor = True
        '
        'cmdComplete
        '
        Me.cmdComplete.Location = New System.Drawing.Point(463, 79)
        Me.cmdComplete.Name = "cmdComplete"
        Me.cmdComplete.Size = New System.Drawing.Size(86, 23)
        Me.cmdComplete.TabIndex = 1
        Me.cmdComplete.Text = "Completed"
        Me.cmdComplete.UseVisualStyleBackColor = True
        '
        'RaidPicker
        '
        Me.RaidPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RaidPicker.FormattingEnabled = True
        Me.RaidPicker.Location = New System.Drawing.Point(463, 52)
        Me.RaidPicker.Name = "RaidPicker"
        Me.RaidPicker.Size = New System.Drawing.Size(220, 21)
        Me.RaidPicker.Sorted = True
        Me.RaidPicker.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(77, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Character"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label2.Location = New System.Drawing.Point(514, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 17)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Select a skirmish"
        '
        'cmdDeleteCharacter
        '
        Me.cmdDeleteCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdDeleteCharacter.Location = New System.Drawing.Point(145, 79)
        Me.cmdDeleteCharacter.Name = "cmdDeleteCharacter"
        Me.cmdDeleteCharacter.Size = New System.Drawing.Size(86, 23)
        Me.cmdDeleteCharacter.TabIndex = 3
        Me.cmdDeleteCharacter.Text = "Delete"
        Me.cmdDeleteCharacter.UseVisualStyleBackColor = True
        '
        'cmdAddCharacter
        '
        Me.cmdAddCharacter.Location = New System.Drawing.Point(9, 79)
        Me.cmdAddCharacter.Name = "cmdAddCharacter"
        Me.cmdAddCharacter.Size = New System.Drawing.Size(86, 23)
        Me.cmdAddCharacter.TabIndex = 3
        Me.cmdAddCharacter.Text = "New"
        Me.cmdAddCharacter.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(13, 137)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(670, 258)
        Me.FlowLayoutPanel1.TabIndex = 53
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(693, 424)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.CmdNotComplete)
        Me.Controls.Add(Me.cmdAddCharacter)
        Me.Controls.Add(Me.cmdComplete)
        Me.Controls.Add(Me.cmdDeleteCharacter)
        Me.Controls.Add(Me.RaidPicker)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CharacterSelector)
        Me.Controls.Add(Me.LabelSkirmishName)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "LoTRO Raid Tracker"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelSkirmishName As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddRaidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CharacterSelector As System.Windows.Forms.ComboBox
	Friend WithEvents CharacterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents AddCharacterMenu As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuResetCharacter As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents DeleteCharacterMenu As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdNotComplete As System.Windows.Forms.Button
	Friend WithEvents cmdComplete As System.Windows.Forms.Button
	Friend WithEvents RaidPicker As System.Windows.Forms.ComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents cmdDeleteCharacter As System.Windows.Forms.Button
	Friend WithEvents cmdAddCharacter As System.Windows.Forms.Button
	Friend WithEvents menuCompleteAll As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents cmdCompleteAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

End Class
