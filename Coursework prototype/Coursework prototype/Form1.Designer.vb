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
        Me.OutputComplex = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenMatrix = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AddButton = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProductButton = New System.Windows.Forms.PictureBox()
        Me.SubtractButton = New System.Windows.Forms.PictureBox()
        Me.DivideButton = New System.Windows.Forms.PictureBox()
        CType(Me.AddButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubtractButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivideButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InputComplex1
        '
        Me.InputComplex1.BackColor = System.Drawing.Color.White
        Me.InputComplex1.ForeColor = System.Drawing.Color.Black
        Me.InputComplex1.Location = New System.Drawing.Point(134, 35)
        Me.InputComplex1.Name = "InputComplex1"
        Me.InputComplex1.Size = New System.Drawing.Size(89, 20)
        Me.InputComplex1.TabIndex = 0
        '
        'InputComplex2
        '
        Me.InputComplex2.BackColor = System.Drawing.Color.White
        Me.InputComplex2.ForeColor = System.Drawing.Color.Black
        Me.InputComplex2.Location = New System.Drawing.Point(134, 60)
        Me.InputComplex2.Name = "InputComplex2"
        Me.InputComplex2.Size = New System.Drawing.Size(89, 20)
        Me.InputComplex2.TabIndex = 1
        '
        'OutputComplex
        '
        Me.OutputComplex.BackColor = System.Drawing.Color.White
        Me.OutputComplex.ForeColor = System.Drawing.Color.Black
        Me.OutputComplex.Location = New System.Drawing.Point(134, 101)
        Me.OutputComplex.Name = "OutputComplex"
        Me.OutputComplex.Size = New System.Drawing.Size(89, 20)
        Me.OutputComplex.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 26)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Input complex number here in form a+bi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Result: "
        '
        'OpenMatrix
        '
        Me.OpenMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.OpenMatrix.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenMatrix.ForeColor = System.Drawing.Color.White
        Me.OpenMatrix.Location = New System.Drawing.Point(3, 205)
        Me.OpenMatrix.Name = "OpenMatrix"
        Me.OpenMatrix.Size = New System.Drawing.Size(95, 90)
        Me.OpenMatrix.TabIndex = 10
        Me.OpenMatrix.Text = "Matricies"
        Me.OpenMatrix.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(104, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 90)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Graph"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'AddButton
        '
        Me.AddButton.Image = Global.Coursework_prototype.My.Resources.Resources.add_128
        Me.AddButton.Location = New System.Drawing.Point(238, 29)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(20, 19)
        Me.AddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AddButton.TabIndex = 12
        Me.AddButton.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Complex number 1: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Complex number 2:"
        '
        'ProductButton
        '
        Me.ProductButton.Image = Global.Coursework_prototype.My.Resources.Resources.cross_solid
        Me.ProductButton.Location = New System.Drawing.Point(238, 79)
        Me.ProductButton.Name = "ProductButton"
        Me.ProductButton.Size = New System.Drawing.Size(20, 19)
        Me.ProductButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ProductButton.TabIndex = 15
        Me.ProductButton.TabStop = False
        '
        'SubtractButton
        '
        Me.SubtractButton.Image = Global.Coursework_prototype.My.Resources.Resources.minus_128
        Me.SubtractButton.Location = New System.Drawing.Point(238, 54)
        Me.SubtractButton.Name = "SubtractButton"
        Me.SubtractButton.Size = New System.Drawing.Size(20, 19)
        Me.SubtractButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SubtractButton.TabIndex = 16
        Me.SubtractButton.TabStop = False
        '
        'DivideButton
        '
        Me.DivideButton.Image = Global.Coursework_prototype.My.Resources.Resources.divide_59_884586
        Me.DivideButton.Location = New System.Drawing.Point(238, 104)
        Me.DivideButton.Name = "DivideButton"
        Me.DivideButton.Size = New System.Drawing.Size(20, 19)
        Me.DivideButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DivideButton.TabIndex = 17
        Me.DivideButton.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(261, 299)
        Me.Controls.Add(Me.DivideButton)
        Me.Controls.Add(Me.SubtractButton)
        Me.Controls.Add(Me.ProductButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OpenMatrix)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OutputComplex)
        Me.Controls.Add(Me.InputComplex2)
        Me.Controls.Add(Me.InputComplex1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Complex Numbers"
        CType(Me.AddButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubtractButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivideButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InputComplex1 As TextBox
    Friend WithEvents InputComplex2 As TextBox
    Friend WithEvents OutputComplex As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents OpenMatrix As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents AddButton As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ProductButton As PictureBox
    Friend WithEvents SubtractButton As PictureBox
    Friend WithEvents DivideButton As PictureBox
End Class
