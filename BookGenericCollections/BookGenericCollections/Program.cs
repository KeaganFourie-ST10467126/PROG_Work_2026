namespace BookGenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instantiate the BookStore class
            BookStore book = new BookStore();

            //Add some books to the store
            book.AddBook("The Great Gatsby", "1");
            book.AddBook("To Kill a Mockingbird", "2");
            book.AddBook("Percy Jackson", "3");

            //While loop for the application to continue running until the user decides to exit
            bool tf = true;
            while (tf)
            {
                Console.WriteLine("Welcome to the bookstore application! Please select an option:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.WriteLine("3. Search for a book by ISBN number");
                Console.WriteLine("4. Display all books");
                Console.WriteLine("5. Exit");

                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        //Add books to the store
                        Console.WriteLine("Type the book title to add: ");
                        string bookTitle = Console.ReadLine();
                        Console.WriteLine("Type the book ISBN number: ");
                        string bookISBN = Console.ReadLine();

                        book.AddBook(bookTitle, bookISBN);
                        break;

                    case 2:
                        //Remove a book from the store
                        Console.WriteLine("Select a book to remove by title: ");
                        string remove = Console.ReadLine();

                        book.RemoveBook(remove);
                        break;

                    case 3:
                        //Search for a book by ISBN number
                        Console.WriteLine("Search for book by ISBN Number: ");
                        string ISBNsearch = Console.ReadLine();

                        book.SearchBook(ISBNsearch);

                        break;
                    case 4:
                        //Display these books
                        Console.WriteLine("\nBooks Collection");
                        book.DisplayBook();
                        break;
                    case 5:
                        //Exit the application
                        Console.WriteLine("Thank you for using the bookstore application. Goodbye!");
                        tf = false;
                        break;
                    default: 
                        Console.WriteLine("Invalid option. Please select a valid option from the menu.");
                        break;
                }
            }


        }
    }
}
