using System;
using System.Collections.Generic;
using BusinessLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    class Program
    {
        static void Main()
        {
            EmployeeService service = new EmployeeService();

            while (true)
            {
                Console.WriteLine("\n===== Employee Management System =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Employee emp = new Employee();

                        Console.Write("Enter Name: ");
                        emp.Name = Console.ReadLine();

                        Console.Write("Enter Age: ");
                        emp.Age = GetValidIntInput();

                        Console.Write("Enter Department: ");
                        emp.Department = Console.ReadLine();

                        Console.Write("Enter Date of Joining (yyyy-MM-dd): ");
                        emp.DateOfJoining = GetValidDateInput();

                        Console.Write("Enter Email: ");
                        emp.Email = Console.ReadLine();

                        Console.Write("Enter Phone Number: ");
                        emp.PhoneNumber = Console.ReadLine();

                        service.AddEmployee(emp);
                        Console.WriteLine("✅ Employee added successfully!");
                        break;

                    case 2:
                        List<Employee> employees = service.GetAllEmployees();
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("\nNo employees found.");
                        }
                        else
                        {
                            Console.WriteLine("\n===== Employee List =====");
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("| ID | Name       | Age | Department  | Date of Joining | Email | Phone Number |");
                            Console.WriteLine("-------------------------------------------------------------");

                            foreach (var e in employees)
                            {
                                Console.WriteLine($"| {e.Id,-3} | {e.Name,-10} | {e.Age,-3} | {e.Department,-10} | {e.DateOfJoining:yyyy-MM-dd} | {e.Email,-15} | {e.PhoneNumber,-10} |");
                            }
                            Console.WriteLine("-------------------------------------------------------------");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Employee ID to Update: ");
                        int updateId = GetValidIntInput();

                        Employee updateEmp = new Employee { Id = updateId };

                        Console.Write("Enter New Name: ");
                        updateEmp.Name = Console.ReadLine();

                        Console.Write("Enter New Age: ");
                        updateEmp.Age = GetValidIntInput();

                        Console.Write("Enter New Department: ");
                        updateEmp.Department = Console.ReadLine();

                        Console.Write("Enter New Date of Joining (yyyy-MM-dd): ");
                        updateEmp.DateOfJoining = GetValidDateInput();

                        Console.Write("Enter New Email: ");
                        updateEmp.Email = Console.ReadLine();

                        Console.Write("Enter New Phone Number: ");
                        updateEmp.PhoneNumber = Console.ReadLine();

                        service.UpdateEmployee(updateEmp);
                        Console.WriteLine("Employee updated successfully!");
                        break;

                    case 4:
                        Console.Write("Enter Employee ID to Delete: ");
                        int deleteId = GetValidIntInput();

                        service.DeleteEmployee(deleteId);
                        Console.WriteLine("Employee deleted successfully!");
                        break;

                    case 5:
                        Console.WriteLine("Exiting Employee Management System.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Enter a number between 1 and 5.");
                        break;
                }
            }
        }

        static int GetValidIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.Write("Invalid input. Please enter a valid number: ");
            }
        }

        static DateTime GetValidDateInput()
        {
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    return date;

                Console.Write("Invalid date format. Please enter a valid date (yyyy-MM-dd): ");
            }
        }
    }
}
