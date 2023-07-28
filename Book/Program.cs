using System;
using System.Collections.Generic;

class Book
{
    public int Id { get; set; } //Fields
    public string Title { get; set; }
    public string Author { get; set; }

    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\n\tLibrary Books:\n\t-------------------------------------");
        foreach (var book in books)
        {
            Console.WriteLine($"\tLibrary ID:\t{book.Id}\n\tTitle:\t\t{book.Title}\n\tAuthor:\t\t{book.Author}\n\tISBN:\t\t{book.ISBN}\n\tAvailability:\t{(book.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
            //Console.WriteLine($"ID:            {book.Id}\n\tTitle:         {book.Title}\n\tAuthor:        {book.Author}\n\tAvailability:  {(book.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------");
        }
        Console.WriteLine();
    }

    public void BorrowBook(String id)
    {
        var book = FindBookById(id);
        if (book != null)
        {
            if (book.IsAvailable)
            {
                book.IsAvailable = false;
                Console.WriteLine($"Book '{book.Title}' has been borrowed.");
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' is not available for borrowing.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
        Console.WriteLine();
    }

    public void ReturnBook(String id)
    {
        var book = FindBookById(id);
        if (book != null)
        {
            if (!book.IsAvailable)
            {
                book.IsAvailable = true;
                Console.WriteLine($"Book '{book.Title}' has been returned.");
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' has already been returned.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
        Console.WriteLine();
    }

    private Book FindBookById(String idInput)
    {
        try 
        {
            int id = int.Parse(idInput);
            return books.Find(book => book.Id == id);
        }
        catch (Exception e)
        {
            return null;
        }

    }
    private Book FindBookByTitle(String Title)
    {
        return books.Find(book => book.Title == Title);
    }
    private Book FindBookByAuthor(String Author)
    {
        return books.Find(book => book.Author == Author);
    }
    public void FindAvailability(bool checkAvailable) 
    {
        if (checkAvailable)
        {
            Console.WriteLine("\n\tAvailable Books:\n\t-------------------------------------");
            foreach (var book in books)
            {
                if (book.IsAvailable == true)
                {
                    Console.WriteLine($"\tLibrary ID:\t{book.Id}\n\tTitle:\t\t{book.Title}\n\tAuthor:\t\t{book.Author}\n\tISBN:\t\t{book.ISBN}\n\tAvailability:\t{(book.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
                }

            }

        }
        else
        {
            Console.WriteLine("\n\tUnavailable Books:\n\t-------------------------------------");
            foreach (var book in books)
            {
                if (book.IsAvailable == false)
                {

                    Console.WriteLine($"\tLibrary ID:\t{book.Id}\n\tTitle:\t\t{book.Title}\n\tAuthor:\t\t{book.Author}\n\tISBN:\t\t{book.ISBN}\n\tAvailability:\t{(book.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
                }

            }
        }
    }
    private Book FindBookByISBN(String ISBN)
    {
        return books.Find(book => book.ISBN == ISBN);
    }

    public void SearchBook(String id)
    {
        var bookByID = FindBookById(id);
        var bookByTitle = FindBookByTitle(id);
        var bookByAuthor = FindBookByAuthor(id);
        var bookByISBN = FindBookByISBN(id);

        if (bookByTitle != null)
        {
            Console.WriteLine("\n\tBook Found:\n\t-------------------------------------");
            Console.WriteLine($"\tLibrary ID:\t{bookByTitle.Id}\n\tTitle:\t\t{bookByTitle.Title}\n\tAuthor:\t\t{bookByTitle.Author}\n\tISBN:\t\t{bookByTitle.ISBN}\n\tAvailability:\t{(bookByTitle.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
        }
        else if(bookByAuthor != null)
        {
            Console.WriteLine("\n\tBook Found:\n\t-------------------------------------");
            Console.WriteLine($"\tLibrary ID:\t{bookByAuthor.Id}\n\tTitle:\t\t{bookByAuthor.Title}\n\tAuthor:\t\t{bookByAuthor.Author}\n\tISBN:\t\t{bookByAuthor.ISBN}\n\tAvailability:\t{(bookByAuthor.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
        }
        else if (bookByISBN != null)
        {
            Console.WriteLine("\n\tBook Found:\n\t-------------------------------------");
            Console.WriteLine($"\tLibrary ID:\t{bookByISBN.Id}\n\tTitle:\t\t{bookByISBN.Title}\n\tAuthor:\t\t{bookByISBN.Author}\n\tISBN:\t\t{bookByISBN.ISBN}\n\tAvailability:\t{(bookByISBN.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
        }
        else if (bookByID != null)
        {
            Console.WriteLine("\n\tBook Found:\n\t-------------------------------------");
            Console.WriteLine($"\tLibrary ID:\t{bookByID.Id}\n\tTitle:\t\t{bookByID.Title}\n\tAuthor:\t\t{bookByID.Author}\n\tISBN:\t\t{bookByID.ISBN}\n\tAvailability:\t{(bookByID.IsAvailable ? "Available" : "Not Available")}\n\t-------------------------------------");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool exit = false;

        // Adding books to the library
        library.AddBook(new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald",ISBN = "9780192832696", IsAvailable = true });
        library.AddBook(new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780060935467", IsAvailable = false });
        library.AddBook(new Book { Id = 3, Title = "1984", Author = "George Orwell", ISBN = "9780198185215", IsAvailable = true });
        library.AddBook(new Book { Id = 4, Title = "The Hobbit", Author = "JRR Tolkien", ISBN = "9780044403371", IsAvailable = true });
        library.AddBook(new Book { Id = 5, Title = "Of Mice and Men", Author = "John Steinbeck", ISBN = "9788431634506", IsAvailable = false });
        library.AddBook(new Book { Id = 6, Title = "The Lord of the Rings", Author = "JRR Tolkien", ISBN = "9780395647387", IsAvailable = true });
        library.AddBook(new Book { Id = 7, Title = "Lord of the Flies", Author = "William Golding", ISBN = "9781573226127", IsAvailable = true });
        library.AddBook(new Book { Id = 8, Title = "The Handmaid's Tale", Author = "Margaret Atwood", ISBN = "9780385539241", IsAvailable = true });
        /*
        // Displaying available books
        library.DisplayBooks();

        // Borrowing a book
        library.BorrowBook(1);

        // Displaying available books after borrowing
        library.DisplayBooks();

        // Returning a book
        library.ReturnBook(2);

        // Displaying available books after returning
        library.DisplayBooks();
        */

        while (!exit)
        {
            Console.WriteLine("\nLibrary Management System\n\nOptions:\n1.Borrow\n2.Return\n3.Display\n4.Search\n0.Exit\n");

            //var optionInput = Console.ReadLine();
            //var option = int.Parse(optionInput);
            var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("\nEnter Library ID:\n");
                    //library.BorrowBook(int.Parse(Console.ReadLine()));
                    library.BorrowBook(Console.ReadLine());
                }
                else if (option == 2)
                {
                    Console.WriteLine("\nEnter Library ID:\n");
                    library.ReturnBook(Console.ReadLine());
                }
                else if (option == 3)
                {
                    Console.WriteLine("\nShow List:\n0. All\n1. Avaiable\n2. Unavailable\n");
                    var opt = int.Parse(Console.ReadLine());
                    bool avail = false;
                    if (opt == 0) 
                    {
                       library.DisplayBooks();
                    }
                    else 
                    {
                        if (opt == 1)
                        {
                           avail = true;
                        }
                         library.FindAvailability(avail);
                    }
                
                }
                else if (option == 4) 
                {
                    /*
                    Console.WriteLine("Search Method:\n\t1.ID\n\t2.Title\n\t3.Author\n\t4.Availability");
                    var searchOption = int.Parse(Console.ReadLine());
                    if (searchOption == 1) 
                    {
                        Console.WriteLine("\n\tEnter ID:");
                        library.SearchBook(Console.ReadLine());
                    }*/
                    Console.WriteLine("\nEnter Search Term:\n");
                    library.SearchBook(Console.ReadLine());

                
                    
                }
                else if (option == 0)
                {
                    Console.WriteLine("\nProgram exited");
                    exit = true;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid number");
                }

            
        }
        Console.ReadLine();
        //Will wait for user to type something before showing:
        /*
            C:\Users\CEQ2310\source\repos\Library Management System\Book\bin\Debug\net6.0\Book.exe (process 10552) exited with code 0.
            To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
            Press any key to close this window . . .
        */
    }
}
