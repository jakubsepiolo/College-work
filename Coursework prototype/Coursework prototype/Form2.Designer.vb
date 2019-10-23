<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.MatrixGrid = New System.Windows.Forms.DataGridView()
        Me.AddRow = New System.Windows.Forms.Button()
        Me.AddColumn = New System.Windows.Forms.Button()
        Me.InvertMatrix = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RemoveRow = New System.Windows.Forms.Button()
        Me.RemoveColumn = New System.Windows.Forms.Button()
        Me.SaveMatrix = New System.Windows.Forms.Button()
        Me.LoadMatrix = New System.Windows.Forms.Button()
        Me.SelectMatrix1 = New System.Windows.Forms.ComboBox()
        Me.SelectMatrix2 = New System.Windows.Forms.ComboBox()
        Me.AddMatrix = New System.Windows.Forms.Button()
        Me.SubtractMatrix = New System.Windows.Forms.Button()
        Me.MultiplyMatrix = New System.Windows.Forms.Button()
        CType(Me.MatrixGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MatrixGrid
        '
        Me.MatrixGrid.BackgroundColor = System.Drawing.Color.White
        Me.MatrixGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MatrixGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MatrixGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MatrixGrid.GridColor = System.Drawing.Color.Gray
        Me.MatrixGrid.Location = New System.Drawing.Point(21, 12)
        Me.MatrixGrid.Name = "MatrixGrid"
        Me.MatrixGrid.Size = New System.Drawing.Size(501, 168)
        Me.MatrixGrid.TabIndex = 0
        '
        'AddRow
        '
        Me.AddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.AddRow.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddRow.ForeColor = System.Drawing.Color.White
        Me.AddRow.Location = New System.Drawing.Point(621, 12)
        Me.AddRow.Name = "AddRow"
        Me.AddRow.Size = New System.Drawing.Size(86, 61)
        Me.AddRow.TabIndex = 1
        Me.AddRow.Text = "Add row"
        Me.AddRow.UseVisualStyleBackColor = False
        '
        'AddColumn
        '
        Me.AddColumn.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.AddColumn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AddColumn.ForeColor = System.Drawing.Color.White
        Me.AddColumn.Location = New System.Drawing.Point(532, 12)
        Me.AddColumn.Name = "AddColumn"
        Me.AddColumn.Size = New System.Drawing.Size(86, 61)
        Me.AddColumn.TabIndex = 2
        Me.AddColumn.Text = "Add column"
        Me.AddColumn.UseVisualStyleBackColor = False
        '
        'InvertMatrix
        '
        Me.InvertMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.InvertMatrix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.InvertMatrix.ForeColor = System.Drawing.Color.White
        Me.InvertMatrix.Location = New System.Drawing.Point(532, 146)
        Me.InvertMatrix.Name = "InvertMatrix"
        Me.InvertMatrix.Size = New System.Drawing.Size(267, 34)
        Me.InvertMatrix.TabIndex = 4
        Me.InvertMatrix.Text = "Invert matrix"
        Me.InvertMatrix.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(529, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 16
        '
        'RemoveRow
        '
        Me.RemoveRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.RemoveRow.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RemoveRow.ForeColor = System.Drawing.Color.White
        Me.RemoveRow.Location = New System.Drawing.Point(621, 79)
        Me.RemoveRow.Name = "RemoveRow"
        Me.RemoveRow.Size = New System.Drawing.Size(86, 61)
        Me.RemoveRow.TabIndex = 6
        Me.RemoveRow.Text = "Remove row"
        Me.RemoveRow.UseVisualStyleBackColor = False
        '
        'RemoveColumn
        '
        Me.RemoveColumn.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.RemoveColumn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RemoveColumn.ForeColor = System.Drawing.Color.White
        Me.RemoveColumn.Location = New System.Drawing.Point(532, 79)
        Me.RemoveColumn.Name = "RemoveColumn"
        Me.RemoveColumn.Size = New System.Drawing.Size(83, 61)
        Me.RemoveColumn.TabIndex = 7
        Me.RemoveColumn.Text = "Remove column"
        Me.RemoveColumn.UseVisualStyleBackColor = False
        '
        'SaveMatrix
        '
        Me.SaveMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.SaveMatrix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SaveMatrix.ForeColor = System.Drawing.Color.White
        Me.SaveMatrix.Location = New System.Drawing.Point(713, 12)
        Me.SaveMatrix.Name = "SaveMatrix"
        Me.SaveMatrix.Size = New System.Drawing.Size(86, 61)
        Me.SaveMatrix.TabIndex = 9
        Me.SaveMatrix.Text = "Save"
        Me.SaveMatrix.UseVisualStyleBackColor = False
        '
        'LoadMatrix
        '
        Me.LoadMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.LoadMatrix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LoadMatrix.ForeColor = System.Drawing.Color.White
        Me.LoadMatrix.Location = New System.Drawing.Point(713, 79)
        Me.LoadMatrix.Name = "LoadMatrix"
        Me.LoadMatrix.Size = New System.Drawing.Size(86, 61)
        Me.LoadMatrix.TabIndex = 10
        Me.LoadMatrix.Text = "Load"
        Me.LoadMatrix.UseVisualStyleBackColor = False
        '
        'SelectMatrix1
        '
        Me.SelectMatrix1.FormattingEnabled = True
        Me.SelectMatrix1.Items.AddRange(New Object() {"Matrix slot 1 ", "Matrix slot 2 ", "Matrix slot 3 ", "Matrix slot 4 ", "Matrix slot 5 "})
        Me.SelectMatrix1.Location = New System.Drawing.Point(21, 196)
        Me.SelectMatrix1.Name = "SelectMatrix1"
        Me.SelectMatrix1.Size = New System.Drawing.Size(117, 21)
        Me.SelectMatrix1.TabIndex = 0
        '
        'SelectMatrix2
        '
        Me.SelectMatrix2.FormattingEnabled = True
        Me.SelectMatrix2.Items.AddRange(New Object() {"Matrix slot 1 ", "Matrix slot 2 ", "Matrix slot 3 ", "Matrix slot 4 ", "Matrix slot 5 "})
        Me.SelectMatrix2.Location = New System.Drawing.Point(161, 196)
        Me.SelectMatrix2.Name = "SelectMatrix2"
        Me.SelectMatrix2.Size = New System.Drawing.Size(119, 21)
        Me.SelectMatrix2.TabIndex = 0
        '
        'AddMatrix
        '
        Me.AddMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.AddMatrix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AddMatrix.ForeColor = System.Drawing.Color.White
        Me.AddMatrix.Location = New System.Drawing.Point(21, 223)
        Me.AddMatrix.Name = "AddMatrix"
        Me.AddMatrix.Size = New System.Drawing.Size(80, 52)
        Me.AddMatrix.TabIndex = 13
        Me.AddMatrix.Text = "Add"
        Me.AddMatrix.UseVisualStyleBackColor = False
        '
        'SubtractMatrix
        '
        Me.SubtractMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.SubtractMatrix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SubtractMatrix.ForeColor = System.Drawing.Color.White
        Me.SubtractMatrix.Location = New System.Drawing.Point(111, 223)
        Me.SubtractMatrix.Name = "SubtractMatrix"
        Me.SubtractMatrix.Size = New System.Drawing.Size(80, 52)
        Me.SubtractMatrix.TabIndex = 14
        Me.SubtractMatrix.Text = "Subtract"
        Me.SubtractMatrix.UseVisualStyleBackColor = False
        '
        'MultiplyMatrix
        '
        Me.MultiplyMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.MultiplyMatrix.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MultiplyMatrix.ForeColor = System.Drawing.Color.White
        Me.MultiplyMatrix.Location = New System.Drawing.Point(200, 223)
        Me.MultiplyMatrix.Name = "MultiplyMatrix"
        Me.MultiplyMatrix.Size = New System.Drawing.Size(80, 52)
        Me.MultiplyMatrix.TabIndex = 15
        Me.MultiplyMatrix.Text = "Multiply"
        Me.MultiplyMatrix.UseVisualStyleBackColor = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(812, 450)
        Me.Controls.Add(Me.MultiplyMatrix)
        Me.Controls.Add(Me.SubtractMatrix)
        Me.Controls.Add(Me.AddMatrix)
        Me.Controls.Add(Me.SelectMatrix2)
        Me.Controls.Add(Me.SelectMatrix1)
        Me.Controls.Add(Me.LoadMatrix)
        Me.Controls.Add(Me.SaveMatrix)
        Me.Controls.Add(Me.RemoveColumn)
        Me.Controls.Add(Me.RemoveRow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.InvertMatrix)
        Me.Controls.Add(Me.AddColumn)
        Me.Controls.Add(Me.AddRow)
        Me.Controls.Add(Me.MatrixGrid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.MatrixGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MatrixGrid As DataGridView
    Friend WithEvents AddRow As Button
    Friend WithEvents AddColumn As Button
    Friend WithEvents InvertMatrix As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents RemoveRow As Button
    Friend WithEvents RemoveColumn As Button
    Friend WithEvents SaveMatrix As Button
    Friend WithEvents LoadMatrix As Button
    Friend WithEvents SelectMatrix1 As ComboBox
    Friend WithEvents SelectMatrix2 As ComboBox
    Friend WithEvents AddMatrix As Button
    Friend WithEvents SubtractMatrix As Button
    Friend WithEvents MultiplyMatrix As Button
End Class
