using System;
using System.Collections.Generic;
using System.Text;

namespace List_of_Objects_Activity
{
    internal class Student
    {
        //Properties of the Student class
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public string Qualification { get; set; }
        public int Age { get; set; }

        //Constructor to initialize the properties of the Student class
        public Student(string name, string studentNumber, string qualification, int age)
        {
            Name = name;
            StudentNumber = studentNumber;
            Qualification = qualification;
            Age = age;
        }

        //Method to print student details
        public virtual void printStudent() // 'virtual' allows this method to be overridden in child classes
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Student Number: {StudentNumber}");
            Console.WriteLine($"Qualification: {Qualification}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine("-------------------------------------");


        }


    }

    //Child class inheriting from the Student class
    internal class UndergraduateStudent : Student
    {
        public List<string> ModulesList { get; set; } = new List<string>();

        public UndergraduateStudent(string name, string studentNumber, string qualification, int age, List<string> modules) 
            :base(name, studentNumber, qualification, age) //Constructor of the parent class is called to initialize the properties of the parent class
        {
            this.ModulesList = modules;
        }

        public override void printStudent() // Overriding the printStudent method to include the modules list for undergraduate students
        {
            base.printStudent(); // Call the base class method to display common student details
            Console.WriteLine("Modules Enrolled for: " + string.Join(", ", ModulesList));
        }
        
    }

    //Child class inheriting from the Student class
    internal class PostGraduateStudent : Student
    {
        public List<string> ResearchTopics { get; set; } = new List<string>();
        
        public PostGraduateStudent(string name, string studentNumber, string qualification, int age, List<string> researchTopics) 
            : base(name, studentNumber, qualification, age) //Constructor of the parent class is called to initialize the properties of the parent class
        {
            this.ResearchTopics = researchTopics;
        }

        public override void printStudent() // Overriding the printStudent method to include the research topics for postgraduate students
        {
            base.printStudent(); // Call the base class method to display common student details
            Console.WriteLine("Research Topics: " + string.Join(", ", ResearchTopics));
        }
    }
}
