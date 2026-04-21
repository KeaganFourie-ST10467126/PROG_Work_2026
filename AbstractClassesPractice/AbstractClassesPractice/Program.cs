namespace AbstractClassesPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employees = new List<Employee>();

            //Now you can store all the payable entities in a single list and process them together
            List<IPayable> ListOfPayables = new List<IPayable>();
            ListOfPayables.Add(new FullTimeEmployee("Alice", "FT001", 50000, 10000));
            ListOfPayables.Add(new PartTimeEmployee("Bob", "PT001", 20, 15));

            //List<Vendor> vendors = new List<Vendor>();
            ListOfPayables.Add(new Vendor("Tech Supplies", 1000, 0.16, 250.00));
            ListOfPayables.Add(new Vendor("Office Essentials", 500, 0.16, 250.00));

            //Now you can store all the payable entities in a single list and process them together

            //Loop through the list of payables and calculate the pay for each entity
            foreach (IPayable p in ListOfPayables)
            {
                if (p is Employee e)
                {
                    e.printEmployee();
                    Console.WriteLine();
                } 
                else if (p is Vendor v) {
                    v.displayVendorDetails();
                    Console.WriteLine();
                }
            }

            /* foreach (Employee e in employees)
            {
                e.printEmployee();
                Console.WriteLine();
            }

            foreach (Vendor v in vendors)
            {
                v.displayVendorDetails();
                Console.WriteLine();
            } */
        }
    }
}
