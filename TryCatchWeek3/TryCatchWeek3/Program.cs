namespace TryCatchWeek3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Try Catch for our program
            try
            {
                Console.WriteLine("Enter student name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter number of modules");
                int modules = int.Parse(Console.ReadLine());

                if (modules <= 0)
                {
                    throw new ArgumentException("Number of modules cannot be negative or zero");
                }

                int count = 0;
                int totalMarks = 0;
                Console.WriteLine("Enter marks for each module (1 - 100)");
                while (count < modules)
                {
                    Console.WriteLine($"Module {count + 1}:");
                    int mark = int.Parse(Console.ReadLine());

                    if (mark < 0 || mark > 100)
                    {
                        throw new ArgumentException("Marks must be between 0 - 100");
                    }
                    else
                    {
                        totalMarks += mark;
                        count++;
                    }
                }
                double avg = (double)totalMarks / modules;

                Console.WriteLine($"Student Name: {name}");
                Console.WriteLine($"Average Grade: {avg}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a valid number");
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("An arithmetic error occurred");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
