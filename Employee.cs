using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePromotionHard
{
    class Employee 
    {
        int id, age;
        string name;
        double salary;

        public void GetEmployeeDetailsFromUser()
        {
            Console.WriteLine("Please enter tthe employee ID");
           
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee name");
            name = Console.ReadLine();
            Console.WriteLine("Please enter the employee age");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary");
            salary = Convert.ToDouble(Console.ReadLine());
        }
        
        public override string ToString()
        {
            return "Employee ID : " + id + "\nName : " + name + "\nAge : " + age +
           "\nSalary : " + salary;
        }
        
        public int Id { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }
    }
}
