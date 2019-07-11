<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.MatrixGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MatrixGrid.Location = New System.Drawing.Point(21, 12)
        Me.MatrixGrid.Name = "MatrixGrid"
        Me.MatrixGrid.Size = New System.Drawing.Size(525, 353)
        Me.MatrixGrid.TabIndex = 0
        '
        'AddRow
        '
        Me.AddRow.Location = New System.Drawing.Point(577, 30)
        Me.AddRow.Name = "AddRow"
        Me.AddRow.Size = New System.Drawing.Size(192, 23)
        Me.AddRow.TabIndex = 1
        Me.AddRow.Text = "Add row"
        Me.AddRow.UseVisualStyleBackColor = True
        '
        'AddColumn
        '
        Me.AddColumn.Location = New System.Drawing.Point(577, 68)
        Me.AddColumn.Name = "AddColumn"
        Me.AddColumn.Size = New System.Drawing.Size(192, 23)
        Me.AddColumn.TabIndex = 2
        Me.AddColumn.Text = "Add column"
        Me.AddColumn.UseVisualStyleBackColor = True
        '
        'InvertMatrix
        '
        Me.InvertMatrix.Location = New System.Drawing.Point(577, 253)
        Me.InvertMatrix.Name = "InvertMatrix"
        Me.InvertMatrix.Size = New System.Drawing.Size(191, 23)
        Me.InvertMatrix.TabIndex = 4
        Me.InvertMatrix.Text = "Invert matrix"
        Me.InvertMatrix.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(618, 312)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 5
        '
        'RemoveRow
        '
        Me.RemoveRow.Location = New System.Drawing.Point(577, 114)
        Me.RemoveRow.Name = "RemoveRow"
        Me.RemoveRow.Size = New System.Drawing.Size(191, 23)
        Me.RemoveRow.TabIndex = 6
        Me.RemoveRow.Text = "Remove row"
        Me.RemoveRow.UseVisualStyleBackColor = True
        '
        'RemoveColumn
        '
        Me.RemoveColumn.Location = New System.Drawing.Point(577, 157)
        Me.RemoveColumn.Name = "RemoveColumn"
        Me.RemoveColumn.Size = New System.Drawing.Size(191, 23)
        Me.RemoveColumn.TabIndex = 7
        Me.RemoveColumn.Text = "Remove column"
        Me.RemoveColumn.UseVisualStyleBackColor = True
        '
        'SaveMatrix
        '
        Me.SaveMatrix.Location = New System.Drawing.Point(21, 415)
        Me.SaveMatrix.Name = "SaveMatrix"
        Me.SaveMatrix.Size = New System.Drawing.Size(75, 23)
        Me.SaveMatrix.TabIndex = 9
        Me.SaveMatrix.Text = "Save"
        Me.SaveMatrix.UseVisualStyleBackColor = True
        '
        'LoadMatrix
        '
        Me.LoadMatrix.Location = New System.Drawing.Point(102, 415)
        Me.LoadMatrix.Name = "LoadMatrix"
        Me.LoadMatrix.Size = New System.Drawing.Size(75, 23)
        Me.LoadMatrix.TabIndex = 10
        Me.LoadMatrix.Text = "Load"
        Me.LoadMatrix.UseVisualStyleBackColor = True
        '
        'SelectMatrix1
        '
        Me.SelectMatrix1.FormattingEnabled = True
        Me.SelectMatrix1.Items.AddRange(New Object() {"Matrix slot 1 ", "Matrix slot 2 ", "Matrix slot 3 ", "Matrix slot 4 ", "Matrix slot 5 "})
        Me.SelectMatrix1.Location = New System.Drawing.Point(331, 391)
        Me.SelectMatrix1.Name = "SelectMatrix1"
        Me.SelectMatrix1.Size = New System.Drawing.Size(117, 21)
        Me.SelectMatrix1.TabIndex = 0
        '
        'SelectMatrix2
        '
        Me.SelectMatrix2.FormattingEnabled = True
        Me.SelectMatrix2.Items.AddRange(New Object() {"Matrix slot 1 ", "Matrix slot 2 ", "Matrix slot 3 ", "Matrix slot 4 ", "Matrix slot 5 "})
        Me.SelectMatrix2.Location = New System.Drawing.Point(469, 391)
        Me.SelectMatrix2.Name = "SelectMatrix2"
        Me.SelectMatrix2.Size = New System.Drawing.Size(119, 21)
        Me.SelectMatrix2.TabIndex = 0
        '
        'AddMatrix
        '
        Me.AddMatrix.Location = New System.Drawing.Point(331, 418)
        Me.AddMatrix.Name = "AddMatrix"
        Me.AddMatrix.Size = New System.Drawing.Size(75, 23)
        Me.AddMatrix.TabIndex = 13
        Me.AddMatrix.Text = "Add"
        Me.AddMatrix.UseVisualStyleBackColor = True
        '
        'SubtractMatrix
        '
        Me.SubtractMatrix.Location = New System.Drawing.Point(423, 418)
        Me.SubtractMatrix.Name = "SubtractMatrix"
        Me.SubtractMatrix.Size = New System.Drawing.Size(75, 23)
        Me.SubtractMatrix.TabIndex = 14
        Me.SubtractMatrix.Text = "Subtract"
        Me.SubtractMatrix.UseVisualStyleBackColor = True
        '
        'MultiplyMatrix
        '
        Me.MultiplyMatrix.Location = New System.Drawing.Point(513, 418)
        Me.MultiplyMatrix.Name = "MultiplyMatrix"
        Me.MultiplyMatrix.Size = New System.Drawing.Size(75, 23)
        Me.MultiplyMatrix.TabIndex = 15
        Me.MultiplyMatrix.Text = "Multiply"
        Me.MultiplyMatrix.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
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
