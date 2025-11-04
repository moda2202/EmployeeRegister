using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegister
{
    // This class represents an employee with a name and salary.
    // and used to create employee objects for the EmployeeRegistry.
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        // returns a string representation of the employee.
        public override string ToString()
        {
            return $"Name: {Name}, Salary: {Salary} kr";
        }
    }
}
