using System;
using System.Collections.Generic;

class Program
{
    static List<Book> books = new List<Book>();
    static List<User> users = new List<User>();
    static List<Borrow> borrows = new List<Borrow>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Library Menu ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Add User");
            Console.WriteLine("4. Borrow Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    ViewBooks();
                    break;
                case 3:
                    AddUser();
                    break;
                case 4:
                    BorrowBook();
                    break;
                case 5:
                    ReturnBook();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Book b = new Book();

        Console.Write("Enter Book ID: ");
        b.BookId = int.Parse(Console.ReadLine());

        Console.Write("Enter Book Title: ");
        b.Title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        b.Author = Console.ReadLine();

        b.IsBorrowed = false;

        books.Add(b);

        Console.WriteLine("Book added successfully.");
    }

    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (Book b in books)
        {
            Console.WriteLine($"BookId: {b.BookId}, Title: {b.Title}, Author: {b.Author}, IsBorrowed: {b.IsBorrowed}");
        }
    }

    static void AddUser()
    {
        User u = new User();

        Console.Write("Enter User ID: ");
        u.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter User Name: ");
        u.Name = Console.ReadLine();

        Console.Write("Enter Address: ");
        u.Addres = Console.ReadLine();

        Console.Write("Enter Telephone Number: ");
        u.TelNo = int.Parse(Console.ReadLine());

        users.Add(u);

        Console.WriteLine("User added successfully.");
    }

    static void BorrowBook()
    {
        Console.Write("Enter Book ID to borrow: ");
        int bookId = int.Parse(Console.ReadLine());

        Console.Write("Enter User ID: ");
        int userId = int.Parse(Console.ReadLine());

        Book book = books.Find(b => b.BookId == bookId);
        User user = users.Find(u => u.Id == userId);

        if (book == null || user == null)
        {
            Console.WriteLine("Invalid Book ID or User ID.");
            return;
        }

        if (book.IsBorrowed)
        {
            Console.WriteLine("Book is already borrowed.");
            return;
        }

        book.IsBorrowed = true;

        Borrow borrow = new Borrow
        {
            BookId = bookId,
            UserId = userId,
            BorrowDate = DateTime.Now
        };

        borrows.Add(borrow);

        Console.WriteLine($"Book '{book.Title}' borrowed successfully by {user.Name}.");
    }

    static void ReturnBook()
    {
        Console.Write("Enter Book ID to return: ");
        int bookId = int.Parse(Console.ReadLine());

        Borrow borrow = borrows.Find(b => b.BookId == bookId);

        if (borrow == null)
        {
            Console.WriteLine("This book is not currently borrowed.");
            return;
        }

        Book book = books.Find(b => b.BookId == bookId);
        book.IsBorrowed = false;

        borrows.Remove(borrow);

        Console.WriteLine($"Book '{book.Title}' returned successfully.");
    }
}