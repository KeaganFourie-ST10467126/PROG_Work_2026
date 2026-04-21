using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesPractice
{
    internal class PartTimeEmployee: Employee, IPayable
    {
        //Create get and set methods for the following properties: Salary and TaxDeduction.
        public int Hours { get; set; }
        public double HourlyRate { get; set; }
        public PartTimeEmployee(string name, string id, int hours, double hourlyRate)
            : base(name, id) //Constructor of the parent class is called to initialize the properties of the parent class
        {
            this.Hours = hours;
            this.HourlyRate = hourlyRate;
        }

        //Override calculatePay
        public override double calculatePay() // Overriding the calculatePay method to calculate the pay for full-time employees
        {
            return Hours * HourlyRate; // Calculate the net pay by subtracting tax deduction from salary
        }

        public override void printEmployee() // Overriding the printStudent method to include the modules list for undergraduate students
        {
            base.printEmployee(); // Call the base class method to display common student details
            double payment = calculatePay(); // Calculate the pay using the overridden method
            Console.WriteLine("Employment Type: Part Time");
            Console.WriteLine($"Hours Worked: {Hours}");
            Console.WriteLine($"Hourly Rate: {HourlyRate}");
            Console.WriteLine($"Payment: {payment}");
            Console.WriteLine("====================");
        }
    }
}
