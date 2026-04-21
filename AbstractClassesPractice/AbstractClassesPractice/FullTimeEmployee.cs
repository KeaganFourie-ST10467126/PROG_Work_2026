using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesPractice
{
    internal class FullTimeEmployee : Employee, IPayable
    {
        //Create get and set methods for the following properties: Salary and TaxDeduction.
        public int Salary { get; set; }
        public int TaxDeduction { get; set; }
        public FullTimeEmployee(string name, string id, int salary, int taxdeduction)
            : base(name, id) //Constructor of the parent class is called to initialize the properties of the parent class
        {
            this.Salary = salary;
            this.TaxDeduction = taxdeduction;
        }

        //Override calculatePay
        public override double calculatePay() // Overriding the calculatePay method to calculate the pay for full-time employees
        {
            return Salary - TaxDeduction; // Calculate the net pay by subtracting tax deduction from salary
        }

        public override void printEmployee() // Overriding the printStudent method to include the modules list for undergraduate students
        {
            base.printEmployee(); // Call the base class method to display common student details
            double payment = calculatePay(); // Calculate the pay using the overridden method
            Console.WriteLine("Employment Type: Full Time");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Tax Deduction: {TaxDeduction}");
            Console.WriteLine($"Salary after taxes: {payment}");
            Console.WriteLine("====================");
        }

    }
}
