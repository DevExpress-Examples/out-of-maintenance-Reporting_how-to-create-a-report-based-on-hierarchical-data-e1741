Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Drawing
Imports DevExpress.XtraReports.UI

Namespace RepTreeListHierarchicalDataRelationships
	Partial Public Class Form1
		Inherits Form
		Private report As XtraReport
		Private dataSet As DataSet
		Private indent As Integer = 0

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim employes As List(Of Employee) = Employee.GenerateSeveralEmployes()

			dataSet = DataSetHelper.HierarchicalListToDataSet(employes, "Id", "ParentId")

			DataSetHelper2.FillTreeView(treeView1, dataSet)
			treeView1.CollapseAll()
			button2.Enabled = True
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			GenerateReport()
			CType(New ReportPrintTool(report), ReportPrintTool).ShowPreviewDialog()
		End Sub

		Private Sub GenerateReport()
			Dim headerBand As New ReportHeaderBand()
			Dim detailBand As New DetailBand()
			Dim title As New XRLabel()
			Dim dataPath As String = dataSet.Tables(0).TableName

			report = New XtraReport()
			report.DataMember = dataPath

			headerBand.Height = 50
			detailBand.Height = 25
			title.SizeF = New SizeF(report.PageWidth - report.Margins.Left - report.Margins.Right - 1, 50)
			title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
			title.Font = New DXFont(title.Font.Name, 20)
			title.Text = "Hierarchical Data Report"

			headerBand.Controls.Add(title)
			report.Bands.Add(headerBand)
			report.Bands.Add(detailBand)

			AddDataFieldsToBand(dataSet.Tables(0), detailBand, dataPath, False)

			Dim nextReport As XtraReportBase = report

			For i As Integer = 0 To dataSet.Relations.Count - 1
				Dim dataRelation As DataRelation = dataSet.Relations(i)

				dataPath &= "." & dataRelation.RelationName
				nextReport = CreateReportForTable(nextReport, dataRelation.ChildTable, dataPath)
			Next i

			report.DataSource = dataSet
		End Sub

		Private Sub AddDataFieldsToBand(ByVal dataTable As DataTable, ByVal band As DetailBand, ByVal dataPath As String, ByVal addKeyFields As Boolean)
			Dim table As XRTable = XRTable.CreateTable(New RectangleF(indent, 0, report.PageWidth - report.Margins.Left - report.Margins.Right - indent - 1, 25), 1, dataTable.Columns.Count - (If(addKeyFields, 0, 2)))
			Dim cellIndex As Integer = 0

			For i As Integer = 0 To dataTable.Columns.Count - 1
				Dim dataColumn As DataColumn = dataTable.Columns(i)

				If addKeyFields OrElse ((Not addKeyFields) AndAlso (Not dataColumn.ColumnName.ToUpper().Contains("ID"))) Then
					table.Rows(0).Cells(cellIndex).DataBindings.Add("Text", Nothing, dataPath & "." & dataColumn.ColumnName)
					cellIndex += 1
				End If
			Next i

			table.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
			band.Controls.Add(table)
			indent += 50
		End Sub

		Private Function CreateReportForTable(ByVal parentReport As XtraReportBase, ByVal dataTable As DataTable, ByVal dataPath As String) As XtraReportBase
			Dim detailReport As New DetailReportBand()
			Dim detailBand As New DetailBand()

			detailBand.Height = 25
			detailReport.Bands.Add(detailBand)
			parentReport.Bands.Add(detailReport)
			AddDataFieldsToBand(dataTable, detailBand, dataPath, False)
			detailReport.DataMember = dataPath

			Return detailReport
		End Function

	End Class

End Namespace