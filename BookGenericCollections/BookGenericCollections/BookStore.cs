using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace BookGenericCollections
{
    public class BookStore
    {
        // Create a dictionary to store book titles and their ISBN Numbers
        public Dictionary<string, string> bookCollection = new Dictionary<string, string>();

        //Add method to add books to the store
        public void AddBook(string title, string isbn)
        {
            //Check if the book already exists in the dictionary before adding it 
            if (!bookCollection.ContainsKey(title))
            {
                bookCollection.Add(title, isbn);
                
            }
            else
            {
                Console.WriteLine("This book already exists in the collection.");
            }
        }

        //Add method to remove books from the store using TryGetValue
        public void RemoveBook(string title)
        {
            foreach (var book in bookCollection)
            {
                if (book.Key == title)
                {
                    bookCollection.Remove(title);
                    Console.WriteLine("Book succesfully removed: " + title);
                    return;
                }
            }
            Console.WriteLine("Book not found with the given title.");
            
        }

        //Add a method to search for a book by ISBN Number
        public void SearchBook(string isbn)
        {
            foreach (var book in bookCollection)
            {
                if (book.Value == isbn)
                {
                    Console.WriteLine("Book found: " + book.Key);
                    return;
                }
            }
            Console.WriteLine("Book not found with the given ISBN number.");
        }

        //Add a method to display all books
        public void DisplayBook()
        {
            foreach (var b in bookCollection)
            {
                Console.WriteLine("Book Title: " + b.Key + "\nISBN: " + b.Value + "\n");
            }
        }

    }
}
