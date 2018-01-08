using System;
using System.Collections.Generic;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime thisInstant = DateTime.Now;
            Company myCompany = new Company();
            List<(string, string, DateTime)> staff = new List<(string, string, DateTime)>(); 
            myCompany.Establish("Turner Inc.", thisInstant, staff);
            myCompany.Hire("John Wick", "CEO", thisInstant);
            myCompany.Hire("John McLane", "CIO", thisInstant);
            myCompany.Hire("Master Yoda", "CFO", thisInstant);

            Console.WriteLine($"The company {myCompany.Name} was established on {myCompany.CreatedOn}.");
            myCompany.ListEmployees();
        }
    }
}

public class Company
{
    /*
        Some readonly properties
    */
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }

    // Create a property for holding a list of current employees
    public List<(string name, string title, DateTime startDate)> Employees { get; set; }


    // Create a method that allows external code to add an employee
    public void Hire(string name, string title, DateTime startDate)
    {
        Employees.Add((name, title, startDate));
    }
    // Create a method that allows external code to remove an employee
    // public void Fire(string name)
    // {
    //     string title = Employees[name];
    //     Employees.Remove((name, title, startDate));
    // }
    /*
        Create a constructor method that accepts two arguments:
            1. The name of the company
            2. The date it was created

        The constructor will set the value of the public properties
    */
    public void Establish(string name, DateTime date, List<(string, string, DateTime)> newhire)
    {
        Name = name;
        CreatedOn = date;
        Employees = newhire;
    }

    public void ListEmployees() {
            Console.WriteLine("Current Staff:");

            foreach ((string name, string title, DateTime startDate) employee in Employees) {
                Console.WriteLine($"{employee.name} - Title: {employee.title} - Start Date: {employee.startDate}");
    }
}
}

