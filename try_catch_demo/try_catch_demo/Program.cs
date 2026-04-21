namespace try_catch_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example: Mini Online shopping checkout
            //In built exception handling

            try
            {
                Console.WriteLine("Enter number of items");
                int items = int.Parse(Console.ReadLine());
                
                //Can leave both in this try catch because they are both related to user input and can throw the same exception
                Console.WriteLine("Enter total cost of items");
                double totalCost = double.Parse(Console.ReadLine());

                //Manual Exception handling - where WE tell the program that something is not right
                //Example: Range check for rating out of 5
                Console.WriteLine("Please enter a rating between 0 and 5");
                int rating = int.Parse(Console.ReadLine());

                if (rating < 1 || rating > 5)
                {
                    throw new ArgumentException("Rating must be between 1 and 5.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
