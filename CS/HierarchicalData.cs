using System;
using System.Collections.Generic;
using System.Text;

namespace RepTreeListHierarchicalDataRelationships {

    public class Employee {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        private int parentId;

        public int ParentId {
            get { return parentId; }
            set { parentId = value; }
        }
        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }
        private decimal salary;

        public decimal Salary {
            get { return salary; }
            set { salary = value; }
        }

        public Employee(int id, int parentId, string name, decimal salary) {
            this.Id = id;
            this.ParentId = parentId;
            this.Name = name;
            this.Salary = salary;
        }

        public static List<Employee> GenerateSeveralEmployes()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee(1, 0, "Andrew Fuller", 90000.00m));
            employees.Add(new Employee(2, 1, "Steven Buchanan", 50000.00m));
            employees.Add(new Employee(3, 2, "Nancy Davolio", 40000.00m));
            employees.Add(new Employee(4, 2, "Janet Leverling", 33000.00m));
            employees.Add(new Employee(5, 2, "Margaret Peacock", 35000.00m));
            employees.Add(new Employee(6, 2, "Michael Suyama", 30000.00m));

            employees.Add(new Employee(7, 2, "Robert King", 37000.00m));
            employees.Add(new Employee(8, 2, "Laura Callahan", 45000.00m));
            employees.Add(new Employee(9, 2, "Anne Dodsworth", 35000.00m));

            employees.Add(new Employee(10, 1, "Albert Hellstern", 60000.00m));
            employees.Add(new Employee(11, 10, "Tim Smith", 18000.00m));
            employees.Add(new Employee(12, 10, "Caroline Patterson", 25000.00m));

            employees.Add(new Employee(13, 1, "Justin Brid", 75000.00m));
            employees.Add(new Employee(14, 13, "Xavier Martin", 50000.00m));
            employees.Add(new Employee(15, 13, "Laurent Pereira", 45000.00m));
            
            return employees;
        }
    }

}
