Imports Microsoft.VisualBasic
Imports System
Namespace RepTreeListHierarchicalDataRelationships
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.button2 = New System.Windows.Forms.Button()
			Me.treeView1 = New System.Windows.Forms.TreeView()
			Me.button1 = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' button2
			' 
			Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button2.Enabled = False
			Me.button2.Location = New System.Drawing.Point(341, 270)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(122, 23)
			Me.button2.TabIndex = 0
			Me.button2.Text = "2. Generate Report"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click);
			' 
			' treeView1
			' 
			Me.treeView1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.treeView1.Location = New System.Drawing.Point(12, 12)
			Me.treeView1.Name = "treeView1"
			Me.treeView1.Size = New System.Drawing.Size(653, 249)
			Me.treeView1.TabIndex = 1
			' 
			' button1
			' 
			Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.button1.Location = New System.Drawing.Point(213, 270)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(122, 23)
			Me.button1.TabIndex = 2
			Me.button1.Text = "1. Generate DataSet"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(677, 302)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.treeView1)
			Me.Controls.Add(Me.button2)
			Me.Name = "Form1"
			Me.Text = "Form1"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents button2 As System.Windows.Forms.Button
		Private treeView1 As System.Windows.Forms.TreeView
		Private WithEvents button1 As System.Windows.Forms.Button
	End Class
End Namespace

