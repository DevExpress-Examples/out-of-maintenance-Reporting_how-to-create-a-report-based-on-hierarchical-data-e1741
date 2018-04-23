Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Data
Imports System.Reflection

Namespace RepTreeListHierarchicalDataRelationships

	Public Class DataSetHelper

		Private Shared itemType As Type

		Public Shared Function HierarchicalListToDataSet(Of T)(ByVal hlist As List(Of T), ByVal keyFieldName As String, ByVal parentFieldName As String) As DataSet
			DataSetHelper.itemType = GetType(T)
			Dim dataSet As New DataSet()
			Dim currentLevelIds As New List(Of Integer)(New Integer() { 0 })
			Dim nextLevelIds As New List(Of Integer)()
			Dim count As Integer = 0

			Do
				Dim dataTable As DataTable = GetNewTable(DataSetHelper.itemType.Name + Iif(count = 0, "RootTable", "Table" & count.ToString()), keyFieldName)

				For i As Integer = 0 To hlist.Count - 1
					For j As Integer = 0 To currentLevelIds.Count - 1

						If Convert.ToInt32(DataSetHelper.itemType.GetProperty(parentFieldName).GetValue(hlist(i), Nothing)) = currentLevelIds(j) Then
							AddItemToTable(dataTable, hlist(i))
							nextLevelIds.Add(Convert.ToInt32(DataSetHelper.itemType.GetProperty(keyFieldName).GetValue(hlist(i), Nothing)))
						End If

					Next j
				Next i

				If nextLevelIds.Count > 0 Then
					dataSet.Tables.Add(dataTable)
					If count > 0 Then ' Not a root table
						dataSet.Relations.Add(String.Format("{0}Level{1}Relation", DataSetHelper.itemType.Name, count), dataSet.Tables(count - 1).Columns(keyFieldName), dataTable.Columns(parentFieldName))
					End If
				End If

				currentLevelIds.Clear()
				currentLevelIds.AddRange(nextLevelIds)
				nextLevelIds.Clear()
				count += 1

			Loop While currentLevelIds.Count > 0

			Return dataSet
		End Function

		Private Shared Function GetNewTable(ByVal tableName As String, ByVal keyFieldName As String) As DataTable
			Dim dt As New DataTable(tableName)
			Dim properties() As PropertyInfo = DataSetHelper.itemType.GetProperties()

			For Each [property] As PropertyInfo In properties
				dt.Columns.Add([property].Name, [property].PropertyType)
			Next [property]

			dt.Constraints.Add("IDPK", dt.Columns(keyFieldName), True)

			Return dt
		End Function

		Private Shared Sub AddItemToTable(ByVal dataTable As DataTable, ByVal item As Object)
			Dim dataRow As DataRow = dataTable.NewRow()
			Dim properties() As PropertyInfo = DataSetHelper.itemType.GetProperties()

			For Each [property] As PropertyInfo In properties
				dataRow([property].Name) = [property].GetValue(item, Nothing)
			Next [property]

			dataTable.Rows.Add(dataRow)
		End Sub

	End Class


	Public Class DataSetHelper2

		Public Shared Sub FillTreeView(ByVal treeView As TreeView, ByVal dataSet As DataSet)
			treeView.BeginUpdate()
			treeView.Nodes.Clear()

			For i As Integer = 0 To dataSet.Tables.Count - 1
				treeView.Nodes.Add(dataSet.Tables(i).TableName)
				AddColumnsAndRelations(treeView.Nodes(i), dataSet.Tables(i))
			Next i

			treeView.ExpandAll()
			treeView.EndUpdate()
		End Sub

		Private Shared Sub AddColumnsAndRelations(ByVal dataTableTreeNode As TreeNode, ByVal dataTable As DataTable)
			Dim dataSet As DataSet = dataTable.DataSet

			For i As Integer = 0 To dataTable.Columns.Count - 1
				dataTableTreeNode.Nodes.Add(dataTable.Columns(i).ColumnName)
			Next i

			For i As Integer = 0 To dataSet.Relations.Count - 1
				If dataSet.Relations(i).ParentTable Is dataTable Then
					Dim relationNode As TreeNode = dataTableTreeNode.Nodes.Add(dataSet.Relations(i).RelationName)

					AddColumnsAndRelations(relationNode, dataSet.Relations(i).ChildTable)
				End If
			Next i
		End Sub

	End Class

End Namespace
