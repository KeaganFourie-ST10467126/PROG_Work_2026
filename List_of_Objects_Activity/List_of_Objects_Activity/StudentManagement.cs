using System;
using System.Collections.Generic;
using System.Text;

namespace List_of_Objects_Activity
{
    //Class represents the system that 'manages many students'
    internal class StudentManagement
    {
        //This class needs access to the list of students that are created only on the Student class template
        //Will only hold Student class objects
        private List<Student> studentList = new List<Student>();

        //1. Method to add a student to the list of students
        public void addStudent()
        {
            //Follow the template of the student class ask for name, student number, qualification and age
            Console.WriteLine("Input student name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Input student number: ");
            string studentNumber = Console.ReadLine();

            Console.WriteLine("Input qualification: ");
            string qualification = Console.ReadLine();

            Console.WriteLine("Input student age: ");
            int age = int.Parse(Console.ReadLine());

            //Ask if they are post Grad or under Grad
            Console.WriteLine("Is the student post graduate or undergraduate? (Input 'PG' for post graduate, 'UG' for under graduate)");
            int choice = Console.ReadLine().ToUpper() == "PG" ? 1 : 2;
            //Create new student object using the student class template and add it to the list of students
            Student student = new Student(name, studentNumber, qualification, age);
            studentList.Add(student);

            Console.WriteLine("Student added successfully!");
        }

        //2. Method to print all students in the list of students
        public void printStudentList()
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("No students in the list.");
                return;
            }
            Console.WriteLine("\n====Student List====");
            foreach (Student student in studentList)
            {
                student.printStudent();
            }

        }
    }
}

