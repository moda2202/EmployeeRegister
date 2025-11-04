namespace EmployeeRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var registry = new EmployeeRegistry();
            bool running = true;

            while (running)
            {

                // Display menu
                Console.WriteLine();
                Console.WriteLine("=== Employee Register ===");
                Console.WriteLine("1) Add employee");
                Console.WriteLine("2) Print register");
                Console.WriteLine("3) Edit employee name");
                Console.WriteLine("4) Edit employee salary");
                Console.WriteLine("5) Delete employee");
                Console.WriteLine("6) Show employee count");
                Console.WriteLine("7) Search employee by name");
                Console.WriteLine("0) Exit");
                Console.Write("Select: ");
                string choice = (Console.ReadLine() ?? string.Empty).Trim();

                // Handle user choice
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddEmployee(registry);
                        break;
                    case "2":
                        Console.Clear();
                        registry.PrintEmployees();
                        break;
                    case "3":
                        Console.Clear();
                        EditEmployeeName(registry);
                        break;
                    case "4":
                        Console.Clear();
                        EditEmployeeSalary(registry);
                        break;
                    case "5":
                        Console.Clear();
                        DeleteEmployee(registry);
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine($"Employees in register: {registry.Count}");
                        break;
                    case "7":
                        Console.Clear();
                        SearchEmployee(registry);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            Console.WriteLine("Program exiting...");
        }

        // Add a new employee
        private static void AddEmployee(EmployeeRegistry registry)
        {
            string name;
            while (true)
            {
                Console.Write("Enter name: ");
                name = (Console.ReadLine() ?? string.Empty).Trim();
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                Console.WriteLine("Name cannot be empty.");
            }

            decimal salary;
            while (true)
            {
                Console.Write("Enter salary (kr): ");
                string salaryInput = (Console.ReadLine() ?? string.Empty).Trim();
                if (decimal.TryParse(salaryInput, out salary) && salary >= 0)
                    break;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid salary. Try again (example: 25000).");
                Console.ResetColor();
            }

            bool added = registry.AddEmployee(name, salary);

            if (!added)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An employee with that name already exists.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee added!");
                Console.ResetColor();
            }
        }

        // Edit an existing employee's name
        private static void EditEmployeeName(EmployeeRegistry registry)
        {
            if (registry.Count == 0)
            {
                Console.WriteLine("No employees available to edit.");
                return;
            }

            registry.PrintEmployees();

            Console.Write("Enter the current name of the employee to change: ");
            string oldName = (Console.ReadLine() ?? string.Empty).Trim();

            var employee = registry.FindEmployeeByName(oldName);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            string newName;
            while (true)
            {
                Console.Write("Enter the new name: ");
                newName = (Console.ReadLine() ?? string.Empty).Trim();

                if (IsValidName(newName))
                    break;

                Console.WriteLine("Invalid name. It cannot contain numbers or be empty.");
            }

            employee.Name = newName;
            Console.WriteLine("Employee name updated successfully!");
        }

        // Edit an existing employee's salary
        private static void EditEmployeeSalary(EmployeeRegistry registry)
        {
            if (registry.Count == 0)
            {
                Console.WriteLine("No employees available to edit.");
                return;
            }

            registry.PrintEmployees();

            Console.Write("Enter the name of the employee whose salary you want to change: ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();

            var employee = registry.FindEmployeeByName(name);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            decimal newSalary;
            while (true)
            {
                Console.Write("Enter the new salary (kr): ");
                string salaryInput = (Console.ReadLine() ?? string.Empty).Trim();

                if (decimal.TryParse(salaryInput, out newSalary) && newSalary >= 0)
                    break;

                Console.WriteLine("Invalid salary. Please enter a valid positive number (e.g. 25000).");
            }

            employee.Salary = newSalary;
            Console.WriteLine("Salary updated successfully!");
        }

        // Validate that the name contains only letters and spaces
        private static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Name must contain only letters and spaces
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }

        private static void DeleteEmployee(EmployeeRegistry registry)
        {
            if (registry.Count == 0)
            {
                Console.WriteLine("No employees to delete.");
                return;
            }

            registry.PrintEmployees();

            Console.Write("Enter the name of the employee to delete: ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();

            bool deleted = registry.DeleteEmployee(name);
            if (deleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee not found.");
            }
            Console.ResetColor();
        }

        // Search for an employee by name
        private static void SearchEmployee(EmployeeRegistry registry)
        {
            if (registry.Count == 0)
            {
                Console.WriteLine("No employees to search.");
                return;
            }

            Console.Write("Enter the name of the employee to search for: ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();

            var employee = registry.FindEmployeeByName(name);

            if (employee == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee not found.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee found:");
            Console.ResetColor();

            Console.WriteLine(employee.ToString());

        }


    }

}