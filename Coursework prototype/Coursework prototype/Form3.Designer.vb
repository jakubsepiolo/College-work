<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.SelectMatrix = New System.Windows.Forms.ComboBox()
        Me.MatrixOutput = New System.Windows.Forms.Label()
        Me.ConfirmButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SelectMatrix
        '
        Me.SelectMatrix.FormattingEnabled = True
        Me.SelectMatrix.Items.AddRange(New Object() {"Matrix slot 1 ", "Matrix slot 2 ", "Matrix slot 3 ", "Matrix slot 4 ", "Matrix slot 5 "})
        Me.SelectMatrix.Location = New System.Drawing.Point(12, 13)
        Me.SelectMatrix.Name = "SelectMatrix"
        Me.SelectMatrix.Size = New System.Drawing.Size(229, 21)
        Me.SelectMatrix.TabIndex = 0
        '
        'MatrixOutput
        '
        Me.MatrixOutput.AutoSize = True
        Me.MatrixOutput.Location = New System.Drawing.Point(12, 54)
        Me.MatrixOutput.Name = "MatrixOutput"
        Me.MatrixOutput.Size = New System.Drawing.Size(39, 13)
        Me.MatrixOutput.TabIndex = 1
        Me.MatrixOutput.Text = "Label1"
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(12, 175)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(229, 23)
        Me.ConfirmButton.TabIndex = 2
        Me.ConfirmButton.Text = "Accept"
        Me.ConfirmButton.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(253, 210)
        Me.Controls.Add(Me.ConfirmButton)
        Me.Controls.Add(Me.MatrixOutput)
        Me.Controls.Add(Me.SelectMatrix)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelectMatrix As ComboBox
    Friend WithEvents MatrixOutput As Label
    Friend WithEvents ConfirmButton As Button
End Class
