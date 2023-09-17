using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace LINQtoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = SampleData.Books;
            //books.Print("All Books Data");
            // 1-	Display book title and its ISBN.
            var bookObj = books.Select(b => new { BookName = b.Title, BookISBN = b.Isbn });
            //bookObj.Print("Titles And ISBN");
            //2-	Display the first 3 books with price more than 25.
            var FirstThreeBooksMoreThan25 = books.Where(b => b.Price > 25).Take(3);
            //FirstThreeBooksMoreThan25.Print("First 3 books with Price more than 25");
            //3-	Display Book title along with its publisher name. (Using 2 methods).
            var bookPUBlisher = books.Select(b => new { BookName = b.Title, PublisherName = b.Publisher.Name });
            //bookPUBlisher.Print("Books Publishing Details");
            //4-	Find the number of books which cost more than 20
            int numOfBooksCostsMoreThan20 = books.Count(b=>b.Price > 20);
            //Console.WriteLine($"Total Books More than 20 L.E : {numOfBooksCostsMoreThan20}");
            //5-	Display book title, price and subject name sorted by its subject name ascending and by its price descending.
            var sortedBooks = books.OrderBy(b => b.Subject.Name).ThenByDescending(b => b.Price);
            // sortedBooks.Print("Books Sorted By Subject Name Ascending and then Book Price in Descending  ");
            // 6-	Display All subjects with books related to this subject. (Using 2 methods).
            //var subGroup = books.ToLookup(b => b.Subject.Name);
            //var subGroups = from book in books
            //                group book by book.Subject into g
            //                select new { SubjName = g.Key.Name, subs = g };

            //foreach(var grp in subGroups)
            //{
            //    grp.subs.Print($"Subject {grp.SubjName} Books:");
            //}
            //7-	Try to display book title & price (from book objects) returned from GetBooks Function
            var newBooks = SampleData.GetBooks();//.Cast<IEnumerable<Book>>();
            newBooks.Print("New Data With ArrayList");
            //8-	Display books grouped by publisher & Subject
            var subGroups2 = from book in books
                             group book by book.Publisher;
            foreach (var g in subGroups2)
            {
                g.Print($"Books Published By :{g.Key.Name}");
            }






            Console.ReadKey();
        }
    }
}
