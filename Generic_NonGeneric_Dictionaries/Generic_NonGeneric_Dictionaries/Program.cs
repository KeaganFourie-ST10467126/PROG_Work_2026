using System.Collections;

namespace Generic_NonGeneric_Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Generic and non generic collections
             * Generic Lists - lists or collection that can hold a specific type of data. They provide type safety and better performance.
             * Non-Generic Lists - lists or collection that can hold any type of data. They do not provide type safety and may require casting when retrieving data. */

            //Non-Generic collection
            ArrayList list = new ArrayList();
            list.Add("Programming");
            list.Add(21);
            list.Add(true);

            //Generic collection
            //The following list can only hold integers
            List<int> numbers = new List<int>();

            /* Dictionaries - Generic collection 
             * Storing Country and its capital city
             * ISBN Number and books
             * Student number and student name
             * Dictionaries store key-value pairs
             * Key values are unique and cannot be duplicated
             */

            Dictionary<string, string> countries = new Dictionary<string, string>();
            countries.Add("South Africa", "Pretoria");
            countries.Add("Japan", "Tokyo");
            countries.Add("France", "Paris");

            foreach(var c in countries)
            {
                Console.WriteLine("Country: " + c.Key + "\nCapital: " + c.Value + "\n");
                
            }

            // How to make sure key duplication does not occur in a dictionary

            Console.WriteLine("Enter the name of the Country");
            string inputCountry = Console.ReadLine();

            Console.WriteLine("Enter the name of the Capital City");
            string inputCity = Console.ReadLine();

            if (!countries.ContainsKey(inputCountry))
            {
                //Only go and add the key and value if the key does not exist in the dictionary
                countries.Add(inputCountry, inputCity);
            }
            else
            {
                // Dont add the key if it exists and display a message to the user
                Console.WriteLine("The country already exists in the dictionary");
            }

            Console.WriteLine("\n==========================");
            Console.WriteLine("= Updated Countries List =");
            Console.WriteLine("==========================");

            foreach (var c in countries)
            {
                Console.WriteLine("Country: " + c.Key + "\nCapital: " + c.Value + "\n");

            }
        }
    }
}
