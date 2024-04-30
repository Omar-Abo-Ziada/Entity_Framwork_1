using LINQtoObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////1-Display book title and its ISBN.

            //// using Anonymous and have to use var here   ==> the best

            //var query1 = SampleData.Books.Select(b => new { b.Title, b.Isbn });

            //foreach (var book in query1)
            //{
            //    Console.WriteLine(book);
            //    Console.WriteLine("");
            //}

            //Console.WriteLine("................\n");

            //// using query Expression
            //var query1_1 =
            //    from book in SampleData.Books
            //    select new { book.Title, book.Isbn };

            //foreach (var book in query1_1)
            //{
            //    Console.WriteLine(book);
            //    Console.WriteLine("");
            //}

            //Console.WriteLine("-------------------");

            //// returning as a string and don't have to use var here  
            //IEnumerable<string> query2 = SampleData.Books.Select(b => $"{b.Title} => {b.Isbn}");

            //foreach (var book in query2)
            //{
            //    Console.WriteLine(book);
            //    Console.WriteLine("");
            //}

            //Console.WriteLine("-------------------");

            //// returning the whole book and don't have to use var here  ==> the worst in preformance
            //IEnumerable<Book> query3 = SampleData.Books.Select(b => b);

            //foreach (var book in query3)
            //{
            //    Console.WriteLine($"{book.Title} \t {book.Isbn}");
            //    Console.WriteLine("");
            //}

            ////===============================================================================================================================

            //2-Display the first 3 books with price more than 25.

            //IEnumerable<Book> query1 = SampleData.Books.Where(b => b.Price > 25);

            //foreach (Book book in query1)
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("-----------------------");
            //// using Expression

            //IEnumerable<Book> query2 =
            //    from book in SampleData.Books
            //    where book.Price > 25
            //    select book;

            //foreach (Book book in query2)
            //{
            //    Console.WriteLine(book);
            //}

            ////===============================================================================================================================

            //3 - Display Book title along with its publisher name.

            //var query1 = SampleData.Books.Select( b => new { b.Title , b.Publisher });

            //foreach(var book in query1)
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("--------------");
            //// using Expression

            //var query2 = 
            //    from book in SampleData.Books
            //    select new { book.Title , book.Publisher };

            //foreach (var book in query1)
            //{
            //    Console.WriteLine(book);
            //}

            ////===============================================================================================================================

            // 4-Find the number of books which cost more than 20.

            //int booksCount1 = SampleData.Books
            //    .Where(b => b.Price > 20)
            //    .Count();

            //Console.WriteLine($"number of books which cost more than 20 : {booksCount1}");

            //int booksCount1_1 = SampleData.Books
            //   //.Where(b => b.Price > 20)
            //   .Count(b => b.Price > 20);

            //Console.WriteLine($"number of books which cost more than 20 : {booksCount1_1}");

            //Console.WriteLine("-----------------");

            ////using Expression

            //int booksCount2 = 
            //    (from book in SampleData.Books
            //    where book.Price > 20
            //    select book).Count();

            //Console.WriteLine($"number of books which cost more than 20 : {booksCount2}");

            //int booksCount2_1 =
            //  (from book in SampleData.Books
            //   //where book.Price > 20
            //   select book).Count(b => b.Price > 20);

            //Console.WriteLine($"number of books which cost more than 20 : {booksCount2_1}");

            //===============================================================================================================================

            //5-Display book title, price and subject name sorted by its subject name ascending and by its price descending.

            //var query1 = SampleData.Books
            //    .OrderBy(b => b.Subject.Name)
            //    .ThenByDescending(b => b.Price)
            //    .Select(b => new { b.Title , b.Price , b.Subject.Name });

            //foreach (var item in query1)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("--------------");

            //var query2 =
            //    from book in SampleData.Books
            //    orderby book.Subject.Name, book.Price
            //    select new { book.Title, book.Price, book.Subject.Name };

            //foreach (var item in query2)
            //{
            //    Console.WriteLine(item);
            //}

            //===============================================================================================================================

            //// 6-Display All subjects with books related to this subject. (Using 2 methods).

            //// using subquery
            //var query1 =
            //    SampleData.Subjects
            //    .Select(s => new
            //    {
            //        subjectName = s.Name,

            //        books =
            //        SampleData.Books
            //        .Where(b => b.Subject.Name == s.Name)
            //    });

            //foreach (var sub in query1)
            //{
            //    Console.WriteLine($"{sub.subjectName} ,, Total Books : {sub.books.Count()} ,, Total Prices : {sub.books.Sum(b => b.Price)}");
            //    Console.WriteLine("------------------------------------------------------------------------------");
            //    foreach (Book book in sub.books)
            //    {
            //        Console.WriteLine($"  {book}");
            //    }
            //    Console.WriteLine("\n");
            //}

            //Console.WriteLine("===========================================\n");

            //var query2 =
            //    from subject in SampleData.Subjects
            //    select new
            //    {
            //        subjectName = subject.Name,

            //        books =
            //        from book in SampleData.Books
            //        where book.Subject.Name == subject.Name
            //        select book
            //    };

            //foreach (var sub in query2)
            //{
            //    Console.WriteLine($"{sub.subjectName} ,, Total Books : {sub.books.Count()} ,, Total Prices : {sub.books.Sum(b => b.Price)}");
            //    Console.WriteLine("------------------------------------------------------------------------------");

            //    foreach (Book book in sub.books)
            //    {
            //        Console.WriteLine($"  {book}");
            //    }
            //    Console.WriteLine("\n");
            //}

            //Console.WriteLine("**************************************************************************\n");

            //// using group by

            //var query2_1 =
            // SampleData.Books
            // .GroupBy(b => b.Subject.Name);

            // foreach (IGrouping<string, Book> booksGroup in query2_1)
            // {
            //     Console.WriteLine($" subject Name : {booksGroup.Key} ,, Total Books : {booksGroup.Count()} ,, Total Prices : {booksGroup.Sum(b => b.Price)}");
            //     Console.WriteLine("------------------------------------------------------------------------------");
            //     foreach (Book book in booksGroup)
            //     {
            //         Console.WriteLine($"  {book}");
            //     }
            //     Console.WriteLine("\n");
            // }

            // Console.WriteLine("===========================================\n");

            // var query2_2 =
            //     from book in SampleData.Books
            //     group book by book.Subject.Name;

            // foreach (IGrouping<string, Book> booksGroup in query2_2)
            // {
            //     Console.WriteLine($" subject Name : {booksGroup.Key} ,, Total Books : {booksGroup.Count()} ,, Total Prices : {booksGroup.Sum(b => b.Price)}");
            //     Console.WriteLine("------------------------------------------------------------------------------");
            //     foreach (Book book in booksGroup)
            //     {
            //         Console.WriteLine($"  {book}");
            //     }
            //     Console.WriteLine("\n");
            // }

            // Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- \n");

            // //another way to use anoymous with the group
            // var query2_3 =                                                 
            //from book in SampleData.Books
            //group book by book.Subject.Name into booksGroup
            //select new { subName = booksGroup.Key, books = booksGroup };


            // foreach (var booksGroup in query2_3)
            // {
            //     Console.WriteLine($" subject Name : {booksGroup.subName} ,, Total Books : {booksGroup.books.Count()} ,, Total Prices : {booksGroup.books.Sum(b => b.Price)}");
            //     Console.WriteLine("------------------------------------------------------------------------------");
            //     foreach (Book book in booksGroup.books)
            //     {
            //         Console.WriteLine($"  {book}");
            //     }
            //     Console.WriteLine("\n");
            // }

            //===============================================================================================================================

            // 7 - Try to display book title &price(from book objects) returned from GetBooks Function.

            //var query1 = 
            //    from Book book in SampleData.GetBooks() 
            //    select new { book.Title , book.Price };

            //foreach (var book in query1)
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("=====================");

            //var query1_1 =
            //   from  book in SampleData.GetBooks().Cast<Book>()
            //   select new { book.Title, book.Price };

            //foreach (var book in query1_1)
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("=====================");

            //var query1_2 =
            //   from book in SampleData.GetBooks().OfType<Book>()  // the best because it loops on the Book type only in the arraylist
            //   select new { book.Title, book.Price };

            //foreach (var book in query1_2)
            //{
            //    Console.WriteLine(book);
            //}

            //===============================================================================================================================

            //8-Display books grouped by publisher & Subject.

            //var query1 =
            //    SampleData.Books
            //    .GroupBy(b => new
            //    {
            //        b.Publisher , 
            //        b.Subject
            //    });

            //foreach (var grp in query1)
            //{
            //    Console.WriteLine($"group => publisher : {grp.Key.Publisher} ,, subject : {grp.Key.Subject}");
            //    Console.WriteLine("    ************");

            //    foreach (Book book in grp)
            //    {
            //        Console.WriteLine($"   {book}");
            //    }
            //    Console.WriteLine();
            //}


            //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>\n");

            //using Expression

            //var query2 =
            //     from book in SampleData.Books
            //     group book by new { book.Publisher, book.Subject };

            //foreach (var group in query2)
            //{
            //    Console.WriteLine($"Publisher: {group.Key.Publisher}, Subject: {group.Key.Subject}");
            //    Console.WriteLine("--------------");

            //    foreach (var book in group)
            //    {
            //        Console.WriteLine(book);
            //    }
            //    Console.WriteLine();
            //}


            //===============================================================================================================================

            //1 - Ask the user for a publisher name & sorting method(sorting criteria(by Title, price, etc….) and sorting way(ASC.Or DESC.))….
            //    And implement a function named FindBooksSorted() that displays all books written by this Author sorted as the user requested.

            //foreach (var publisher in SampleData.Publishers)
            //{
            //    Console.Write($"{publisher}\t");
            //}

            //Console.WriteLine("\nEnter publisher name : ");
            //string publisherName = Console.ReadLine();

            //Console.WriteLine("\nEnter Sorting Method : ");
            //string sortMethod = Console.ReadLine();

            //FindBooks(publisherName , sortMethod);

            //===============================================================================================================================




        }
        //public static void FindBooks(string publisherName , string sortMethod)
        //{
        //    var query =
        //        SampleData.Books
        //        .OrderBy(b => b.Publisher.Name)
        //}
    }
}

