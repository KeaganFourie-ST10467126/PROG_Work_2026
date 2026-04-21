using System.Numerics;

namespace Delegates_Intro
{
    internal class Program
    {
        //Basic add method that takes two numbers and returns their sum.
        /* static int Add(int num1, int num2)
        {
            return num1 + num2;
        } */

        //Make a method that decides if the numbers must be added, multiplied, subtracted or divided.
        static void calculate(int num1, int num2, string operation)
        {
            try
            {
                switch (operation)
                {
                    case "add":
                        Console.WriteLine(num1 + num2);
                        break;
                    case "subtract":
                        Console.WriteLine(num1 - num2);
                        break;
                    case "divide":
                        Console.WriteLine(num1 / num2);
                        break;
                    case "multiply":
                        Console.WriteLine(num1 * num2);
                        break;
                    default:
                        throw new Exception("Invalid operation");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        /*If we want the method to do different behaviors, we would pass the choice through the parameters which becomes messy and hard to maintain.
             *If we want to add more operations, we would have to modify the method which is not good for reusability. 
             *This is where delegates come in handy, they allow us to pass methods as parameters and decide the behavior at 
             *runtime without modifying the method itself. */

        /*Instead of passing choices and changing the methods behavior like above, we can declare a delegate (advanced form of code reuseability)

        /*1. Delegates are used the pass methods to other methods as parameters
         *2. It can store a method like a variable. */

        //Step 1: Declare the delegate
        //This delegate can store any method that takes:
        //- two integers
        //- returns an integer.
        public delegate int MathOperation(int a, int b);

        //Step 2: Create methods that match the delegate signature
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }

        //Step 3: Pass this delegate as a parameter
        //This method does not care which function it recieves from the delegate, it just executes the methods stored inside the delegate
        static void Process(MathOperation operation, int input1, int input2)
        {
            Console.WriteLine("Result: " + operation(input1, input2));
        }
        static void Main(string[] args)
        {
            // Part 1: Reusablity with normal parameters [Variables]
            //Add(1, 2);
            //Add(3, 2);
            //Add(5, 6);
            //Add(7, 9);
            //Add(3, 5);

            //calculate(1, 2, "add");
            //calculate(3, 2, "subtract");
            //calculate(5, 6, "divide");
            //calculate(7, 9, "multiply");

            //Part 2: Changing behavior using a delegate
            //Step 4: Call the method using the delegate
            Console.WriteLine("Enter num 1:");
            int userInput1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num 2:");
            int userInput2 = int.Parse(Console.ReadLine()); 

            //Approach 1 of using delegates: Pass the method as a parameter
            Process(Add, userInput1, userInput2); //This will call the Add method through the delegate
            Process(Multiply, userInput1, userInput2); //This will call the Multiply method through the delegate

            //Approach 2 of using delegates: Store the method in a variable and pass the variable as a parameter
            MathOperation operation = Add;
            Process(operation, 3, 5);

            operation = Multiply;
            Process(operation, 3, 5);


        }
    }
}
