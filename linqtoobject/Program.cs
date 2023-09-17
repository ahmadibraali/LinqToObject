using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LINQtoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = SampleData.Books;
            books.Print("All Books Data");
            // 1-	Display book title and its ISBN.
            var bookObj = books.Select(b => new { BookName = b.Title, BookISBN = b.Isbn });
            //bookObj.Print("Titles And ISBN");
            //2-	Display the first 3 books with price more than 25.
            var FirstThreeBooksMoreThan25 = books.Where(b => b.Price > 25).Take(3);
            //FirstThreeBooksMoreThan25.Print("First 3 books with Price more than 25");
            //3-	Display Book title along with its publisher name. (Using 2 methods).
            var bookPUBlisher = books.Select(b => new { BookName = b.Title, PublisherName = b.Publisher.Name });
            bookPUBlisher.Print("Books Publishing Details");



            Console.ReadKey();
        }
    }
}
