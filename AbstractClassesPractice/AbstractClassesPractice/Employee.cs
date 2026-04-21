using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesPractice
{
    /* Abstract class is a template for all its child classes
     * Ensures every child class has certain methods used
     * Abstract class is a parent class which we don't want to exist on its own
     * We don't want a generic employee
     * We want to force different types of child employee classes to follow a special template */
    public abstract class Employee
    {
        //Create get and set methods for the following properties: Name and ID.
        public string Name { get; set; }
        public string ID { get; set; }

        //Constructors
        public Employee(string name, string id) 
        {
            Name = name;
            ID = id;
        }

        //Print Employee Details
        public virtual void printEmployee()
        {
            Console.WriteLine("===Employee Details===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            

        }

        //Calculate Pay: To be overridden
        public virtual double calculatePay()
        {
            return 0;
        }


    }

    
}
