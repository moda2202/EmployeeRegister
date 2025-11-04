using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegister
{
    public class EmployeeRegistry
    {
        // list to store employee objects
        private List<Employee> employees = new List<Employee>();


        public int Count => employees.Count;

        // method to add a new employee to the registry
        public bool AddEmployee(string name, decimal salary)
        {
            if (FindEmployeeByName(name) != null)
                return false; // name already exists

            var employee = new Employee(name.Trim(), salary);
            employees.Add(employee);
            return true;
        }

        // method to print all employees in the registry
        public void PrintEmployees()
        {

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees registered.");
                return;
            }

            Console.WriteLine("=== Employee Register ===");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }


        }

        // method to find an employee by name and return null if not found
        public Employee? FindEmployeeByName(string name)
        {
            string cleaned = name.Trim();

            foreach (var employee in employees)
            {
                if (employee.Name != null &&
                    employee.Name.Trim().Equals(cleaned, StringComparison.OrdinalIgnoreCase))
                {
                    return employee;
                }
            }
            return null;
        }

        // method to delete an employee by name, returns true if deleted, false if not found
        public bool DeleteEmployee(string name)
        {
            var employee = FindEmployeeByName(name);
            if (employee == null) return false;

            return employees.Remove(employee);
        }

    }
}
