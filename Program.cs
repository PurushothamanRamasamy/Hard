using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePromotionHard
{
    class Program
    {
        static List<Employee> employees = new List<Employee>();
        static void Main()
        {

            DisplayMenu();

        
        }
        public static void DisplayMenu()
        {
            int getMenuFromUser;

            try
            {
                Console.WriteLine("Please enter the option \n 1.Add an employee \n 2.Modify an employee detail \n 3.Print all employee's details \n 4.Print an employee detail \n 5.Exit");
                Console.WriteLine(employees.Count);
                getMenuFromUser = Convert.ToInt32(Console.ReadLine());
                switch (getMenuFromUser)
                {
                    case 1: AddEmployee(); break;
                    case 2: UpdateEmployee(); break;
                    case 3: SortAndPrintEmployees(); break;
                    case 4:PrintEmployee();break;
                    case 5: break;
                    default:
                        throw new InvalidOperationException("!!!!!!!!!!!Menu must be in range 1 to 5");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void AddEmployee()
        {
            int AddEmployeeMenu;
            do
            {
                Employee employee = new Employee();
                employee.GetEmployeeDetailsFromUser();
                employees.Add(employee);
                Console.WriteLine("\nTo continue entering employee details enter 1, to exit enter 0");
                AddEmployeeMenu = Convert.ToInt32(Console.ReadLine());
            } while (AddEmployeeMenu == 1);
            DisplayMenu();
        }
        public static void UpdateEmployee()
        {
            Console.WriteLine("Please enter the employee ID");
            int empId = Convert.ToInt32(Console.ReadLine());
            var searchedEmployee = from emp in employees where emp.Id.Equals(empId) select emp;
            foreach (var emp in searchedEmployee)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.WriteLine("\nPlease enter the updated employee details");
             employees.Where(
                emp => emp.Id == empId
                ).Select(
                updatedDetails => 
                {
                    Console.WriteLine("Please enter the employee name");
                    updatedDetails.Name = Console.ReadLine();
                    Console.WriteLine("Please enter the employee age");
                    updatedDetails.Age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the employee salary");
                    updatedDetails.Salary = Convert.ToInt32(Console.ReadLine());
                    return updatedDetails; 
                } ).ToList();
            DisplayMenu();
        }
        public static void SortAndPrintEmployees()
        {
            /*employees.Sort();*/
            Console.WriteLine("The employee list"+employees.Count);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
                Console.WriteLine("-----------------------");
            }
            DisplayMenu();
        }
        public static void PrintEmployee()
        {
            Console.WriteLine("Please enter the employee ID");
            int empId;
            try
            {
                empId = Convert.ToInt32(Console.ReadLine());

                var searchedEmployee = from emp in employees where emp.Id.Equals(empId) select emp;

                if (searchedEmployee.Count() != 0)
                {
                    foreach (var emp in searchedEmployee)
                    {
                        Console.WriteLine(emp.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter an Valid Employee Id \n");
                    PrintEmployee();
                }
            }
            catch(Exception e)
            {
                if (e.Message.Contains("Input string was not in a correct format."))
                {
                    Console.WriteLine(e.Message+"Employee id must be String");
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }
            DisplayMenu();
        }
    }
}
