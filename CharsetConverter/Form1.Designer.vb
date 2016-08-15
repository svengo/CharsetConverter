<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lvFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ilSymbols = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnDelAll = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.cbBackup = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDirectory = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbInput = New System.Windows.Forms.ComboBox()
        Me.cbOutput = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.file = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lvFiles)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.cbBackup)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 290)
        Me.Panel1.TabIndex = 0
        '
        'lvFiles
        '
        Me.lvFiles.AllowDrop = True
        Me.lvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvFiles.FullRowSelect = True
        Me.lvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvFiles.Location = New System.Drawing.Point(9, 12)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.ShowGroups = False
        Me.lvFiles.ShowItemToolTips = True
        Me.lvFiles.Size = New System.Drawing.Size(605, 186)
        Me.lvFiles.SmallImageList = Me.ilSymbols
        Me.lvFiles.TabIndex = 23
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'ilSymbols
        '
        Me.ilSymbols.ImageStream = CType(resources.GetObject("ilSymbols.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilSymbols.TransparentColor = System.Drawing.Color.Transparent
        Me.ilSymbols.Images.SetKeyName(0, "1336143717_gtk-cancel.ico")
        Me.ilSymbols.Images.SetKeyName(1, "1336143656_gtk-apply.ico")
        Me.ilSymbols.Images.SetKeyName(2, "1345825147_gtk-configure.ico")
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnDelAll)
        Me.GroupBox3.Controls.Add(Me.btnDel)
        Me.GroupBox3.Location = New System.Drawing.Point(623, 98)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(88, 77)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Löschen"
        '
        'btnDelAll
        '
        Me.btnDelAll.Location = New System.Drawing.Point(7, 48)
        Me.btnDelAll.Name = "btnDelAll"
        Me.btnDelAll.Size = New System.Drawing.Size(75, 23)
        Me.btnDelAll.TabIndex = 17
        Me.btnDelAll.Text = "Liste leeren"
        Me.btnDelAll.UseCompatibleTextRendering = True
        Me.btnDelAll.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(7, 19)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 23)
        Me.btnDel.TabIndex = 16
        Me.btnDel.Text = "Entfernen"
        Me.btnDel.UseCompatibleTextRendering = True
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'cbBackup
        '
        Me.cbBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbBackup.AutoSize = True
        Me.cbBackup.Checked = True
        Me.cbBackup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBackup.Location = New System.Drawing.Point(548, 221)
        Me.cbBackup.Name = "cbBackup"
        Me.cbBackup.Size = New System.Drawing.Size(107, 18)
        Me.cbBackup.TabIndex = 19
        Me.cbBackup.Text = "Backup erstellen"
        Me.ttMain.SetToolTip(Me.cbBackup, "Ein Backup wird DRINGEND empfolen!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Die Backups werden jeweils im Unterverzeichni" & _
        "s ""CharsetConverterBackups"" erstellt.")
        Me.cbBackup.UseCompatibleTextRendering = True
        Me.cbBackup.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnDirectory)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Location = New System.Drawing.Point(623, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 80)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hinzufügen"
        Me.GroupBox2.UseCompatibleTextRendering = True
        '
        'btnDirectory
        '
        Me.btnDirectory.Location = New System.Drawing.Point(6, 48)
        Me.btnDirectory.Name = "btnDirectory"
        Me.btnDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnDirectory.TabIndex = 13
        Me.btnDirectory.Text = "Verzeichnis"
        Me.ttMain.SetToolTip(Me.btnDirectory, "Fügt alle Dateien in einem auszuwählenden Verzeichnis hinzu.")
        Me.btnDirectory.UseCompatibleTextRendering = True
        Me.btnDirectory.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 19)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Datei(en)"
        Me.ttMain.SetToolTip(Me.btnAdd, "Eine oder mehrere Dateien hinzufügen.")
        Me.btnAdd.UseCompatibleTextRendering = True
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(548, 245)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "&Beenden"
        Me.btnCancel.UseCompatibleTextRendering = True
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(629, 245)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseCompatibleTextRendering = True
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbInput)
        Me.GroupBox1.Controls.Add(Me.cbOutput)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 77)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Zeichensätze"
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'cbInput
        '
        Me.cbInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInput.Location = New System.Drawing.Point(140, 19)
        Me.cbInput.Name = "cbInput"
        Me.cbInput.Size = New System.Drawing.Size(378, 21)
        Me.cbInput.TabIndex = 5
        '
        'cbOutput
        '
        Me.cbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutput.FormattingEnabled = True
        Me.cbOutput.Location = New System.Drawing.Point(140, 46)
        Me.cbOutput.Name = "cbOutput"
        Me.cbOutput.Size = New System.Drawing.Size(378, 21)
        Me.cbOutput.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Output Encoding"
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Input Encoding"
        Me.Label1.UseCompatibleTextRendering = True
        '
        'file
        '
        Me.file.Text = "Status und Datei"
        Me.file.Width = 52
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DereferenceLinks = False
        Me.OpenFileDialog1.Filter = "Textdateien|*.csv;*.txt;*.dat|Alle Dateien|*.*"
        Me.OpenFileDialog1.Multiselect = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Bitte Verzeichnios auswählen. Es werden alle darin enthaltenen Dateien hinzugefüg" & _
    "t."
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 289)
        Me.Controls.Add(Me.Panel1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(738, 327)
        Me.Name = "Form1"
        Me.Text = "CharsetConverter"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelAll As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents ilSymbols As System.Windows.Forms.ImageList
    Friend WithEvents cbBackup As System.Windows.Forms.CheckBox
    Friend WithEvents ttMain As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDirectory As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbInput As System.Windows.Forms.ComboBox
    Friend WithEvents cbOutput As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents file As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lvFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

End Class
