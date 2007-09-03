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
		Me.menuStrip = New System.Windows.Forms.MenuStrip
		Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.statusStrip = New System.Windows.Forms.StatusStrip
		Me.menuStrip.SuspendLayout()
		Me.SuspendLayout()
		'
		'menuStrip
		'
		Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem})
		Me.menuStrip.Location = New System.Drawing.Point(0, 0)
		Me.menuStrip.Name = "menuStrip"
		Me.menuStrip.Size = New System.Drawing.Size(516, 24)
		Me.menuStrip.TabIndex = 0
		Me.menuStrip.Text = "MenuStrip1"
		'
		'HelpToolStripMenuItem
		'
		Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
		Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
		Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
		Me.HelpToolStripMenuItem.Text = "&Help"
		'
		'AboutToolStripMenuItem
		'
		Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
		Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
		Me.AboutToolStripMenuItem.Text = "&About"
		'
		'statusStrip
		'
		Me.statusStrip.Location = New System.Drawing.Point(0, 279)
		Me.statusStrip.Name = "statusStrip"
		Me.statusStrip.Size = New System.Drawing.Size(516, 22)
		Me.statusStrip.TabIndex = 1
		Me.statusStrip.Text = "StatusStrip1"
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(516, 301)
		Me.Controls.Add(Me.statusStrip)
		Me.Controls.Add(Me.menuStrip)
		Me.MainMenuStrip = Me.menuStrip
		Me.Name = "MainForm"
		Me.Text = "AForge.NET Motion Detection Sample"
		Me.menuStrip.ResumeLayout(False)
		Me.menuStrip.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
	Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
	Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
