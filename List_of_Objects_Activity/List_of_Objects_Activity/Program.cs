using System.Xml.Serialization;

namespace List_of_Objects_Activity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a menu system using switch case
            //1. Add Student
            //2. View Student List
            //3. Exit Application

            //Create a loop to keep the menu running until the user selects to exit the application
            bool exitApp = false;

            //Create instance of StudentManagement class
            StudentManagement studentManagement = new StudentManagement();

            while (exitApp != true)
            {
                Console.WriteLine("\n====Student Management System====");
                Console.WriteLine("Input the choice you want");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Student List");
                Console.WriteLine("3. Exit Application");
                Console.Write("Input choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Add Student
                        studentManagement.addStudent();
                        break;
                    case 2:
                        //View Student List
                        studentManagement.printStudentList();
                        break;
                    case 3:
                        //Exit App
                        Console.WriteLine("Exiting Application");
                        exitApp = true;
                        break;
                    default:
                        //Default class
                        Console.WriteLine("Please select a valid option");
                        break;

                }
            }
            

        }
    }
}
