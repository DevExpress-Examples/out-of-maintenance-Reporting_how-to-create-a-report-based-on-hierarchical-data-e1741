Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace RepTreeListHierarchicalDataRelationships

	Public Class Employee
		Private id_Renamed As Integer

		Public Property Id() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property
		Private parentId_Renamed As Integer

		Public Property ParentId() As Integer
			Get
				Return parentId_Renamed
			End Get
			Set(ByVal value As Integer)
				parentId_Renamed = value
			End Set
		End Property
		Private name_Renamed As String

		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		Private salary_Renamed As Decimal

		Public Property Salary() As Decimal
			Get
				Return salary_Renamed
			End Get
			Set(ByVal value As Decimal)
				salary_Renamed = value
			End Set
		End Property

		Public Sub New(ByVal id As Integer, ByVal parentId As Integer, ByVal name As String, ByVal salary As Decimal)
			Me.Id = id
			Me.ParentId = parentId
			Me.Name = name
			Me.Salary = salary
		End Sub

		Public Shared Function GenerateSeveralEmployes() As List(Of Employee)
			Dim employees As New List(Of Employee)()

			employees.Add(New Employee(1, 0, "Andrew Fuller", 90000.00D))
			employees.Add(New Employee(2, 1, "Steven Buchanan", 50000.00D))
			employees.Add(New Employee(3, 2, "Nancy Davolio", 40000.00D))
			employees.Add(New Employee(4, 2, "Janet Leverling", 33000.00D))
			employees.Add(New Employee(5, 2, "Margaret Peacock", 35000.00D))
			employees.Add(New Employee(6, 2, "Michael Suyama", 30000.00D))

			employees.Add(New Employee(7, 2, "Robert King", 37000.00D))
			employees.Add(New Employee(8, 2, "Laura Callahan", 45000.00D))
			employees.Add(New Employee(9, 2, "Anne Dodsworth", 35000.00D))

			employees.Add(New Employee(10, 1, "Albert Hellstern", 60000.00D))
			employees.Add(New Employee(11, 10, "Tim Smith", 18000.00D))
			employees.Add(New Employee(12, 10, "Caroline Patterson", 25000.00D))

			employees.Add(New Employee(13, 1, "Justin Brid", 75000.00D))
			employees.Add(New Employee(14, 13, "Xavier Martin", 50000.00D))
			employees.Add(New Employee(15, 13, "Laurent Pereira", 45000.00D))

			Return employees
		End Function
	End Class

End Namespace
