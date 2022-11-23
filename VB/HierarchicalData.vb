Imports System.Collections.Generic

Namespace RepTreeListHierarchicalDataRelationships

    Public Class Employee

        Private idField As Integer

        Public Property Id As Integer
            Get
                Return idField
            End Get

            Set(ByVal value As Integer)
                idField = value
            End Set
        End Property

        Private parentIdField As Integer

        Public Property ParentId As Integer
            Get
                Return parentIdField
            End Get

            Set(ByVal value As Integer)
                parentIdField = value
            End Set
        End Property

        Private nameField As String

        Public Property Name As String
            Get
                Return nameField
            End Get

            Set(ByVal value As String)
                nameField = value
            End Set
        End Property

        Private salaryField As Decimal

        Public Property Salary As Decimal
            Get
                Return salaryField
            End Get

            Set(ByVal value As Decimal)
                salaryField = value
            End Set
        End Property

        Public Sub New(ByVal id As Integer, ByVal parentId As Integer, ByVal name As String, ByVal salary As Decimal)
            Me.Id = id
            Me.ParentId = parentId
            Me.Name = name
            Me.Salary = salary
        End Sub

        Public Shared Function GenerateSeveralEmployes() As List(Of Employee)
            Dim employees As List(Of Employee) = New List(Of Employee)()
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
