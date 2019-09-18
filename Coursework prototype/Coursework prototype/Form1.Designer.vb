<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.InputComplex1 = New System.Windows.Forms.TextBox()
        Me.InputComplex2 = New System.Windows.Forms.TextBox()
        Me.AddComplex = New System.Windows.Forms.Button()
        Me.OutputComplex = New System.Windows.Forms.TextBox()
        Me.SubtractComplex = New System.Windows.Forms.Button()
        Me.MultiplyComplex = New System.Windows.Forms.Button()
        Me.DivideComplex = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenMatrix = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'InputComplex1
        '
        Me.InputComplex1.Location = New System.Drawing.Point(47, 71)
        Me.InputComplex1.Name = "InputComplex1"
        Me.InputComplex1.Size = New System.Drawing.Size(162, 20)
        Me.InputComplex1.TabIndex = 0
        '
        'InputComplex2
        '
        Me.InputComplex2.Location = New System.Drawing.Point(47, 118)
        Me.InputComplex2.Name = "InputComplex2"
        Me.InputComplex2.Size = New System.Drawing.Size(162, 20)
        Me.InputComplex2.TabIndex = 1
        '
        'AddComplex
        '
        Me.AddComplex.Location = New System.Drawing.Point(277, 50)
        Me.AddComplex.Name = "AddComplex"
        Me.AddComplex.Size = New System.Drawing.Size(75, 23)
        Me.AddComplex.TabIndex = 2
        Me.AddComplex.Text = "Add"
        Me.AddComplex.UseVisualStyleBackColor = True
        '
        'OutputComplex
        '
        Me.OutputComplex.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OutputComplex.Location = New System.Drawing.Point(458, 101)
        Me.OutputComplex.Name = "OutputComplex"
        Me.OutputComplex.Size = New System.Drawing.Size(258, 20)
        Me.OutputComplex.TabIndex = 3
        '
        'SubtractComplex
        '
        Me.SubtractComplex.Location = New System.Drawing.Point(277, 79)
        Me.SubtractComplex.Name = "SubtractComplex"
        Me.SubtractComplex.Size = New System.Drawing.Size(75, 23)
        Me.SubtractComplex.TabIndex = 5
        Me.SubtractComplex.Text = "Subtract"
        Me.SubtractComplex.UseVisualStyleBackColor = True
        '
        'MultiplyComplex
        '
        Me.MultiplyComplex.Location = New System.Drawing.Point(277, 108)
        Me.MultiplyComplex.Name = "MultiplyComplex"
        Me.MultiplyComplex.Size = New System.Drawing.Size(75, 23)
        Me.MultiplyComplex.TabIndex = 6
        Me.MultiplyComplex.Text = "Multiply"
        Me.MultiplyComplex.UseVisualStyleBackColor = True
        '
        'DivideComplex
        '
        Me.DivideComplex.Location = New System.Drawing.Point(277, 137)
        Me.DivideComplex.Name = "DivideComplex"
        Me.DivideComplex.Size = New System.Drawing.Size(75, 23)
        Me.DivideComplex.TabIndex = 7
        Me.DivideComplex.Text = "Divide"
        Me.DivideComplex.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 26)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Input complex number here" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "In form a+bi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(400, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Result: "
        '
        'OpenMatrix
        '
        Me.OpenMatrix.Location = New System.Drawing.Point(561, 354)
        Me.OpenMatrix.Name = "OpenMatrix"
        Me.OpenMatrix.Size = New System.Drawing.Size(75, 23)
        Me.OpenMatrix.TabIndex = 10
        Me.OpenMatrix.Text = "Matrix stuff"
        Me.OpenMatrix.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(561, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OpenMatrix)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DivideComplex)
        Me.Controls.Add(Me.MultiplyComplex)
        Me.Controls.Add(Me.SubtractComplex)
        Me.Controls.Add(Me.OutputComplex)
        Me.Controls.Add(Me.AddComplex)
        Me.Controls.Add(Me.InputComplex2)
        Me.Controls.Add(Me.InputComplex1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InputComplex1 As TextBox
    Friend WithEvents InputComplex2 As TextBox
    Friend WithEvents AddComplex As Button
    Friend WithEvents OutputComplex As TextBox
    Friend WithEvents SubtractComplex As Button
    Friend WithEvents MultiplyComplex As Button
    Friend WithEvents DivideComplex As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents OpenMatrix As Button
    Friend WithEvents Button1 As Button
End Class
