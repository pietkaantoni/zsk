using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfejsy
{
    class Program
    {
        class Book : IComparable<Book>
        {
            string title;
            public string Author;
            public int YearOfPublication;
            public double Price;

            public Book(string title, string author, int yearOfPublication, double price)
            {
                this.title = title;
                Author = author;
                YearOfPublication = yearOfPublication;
                Price = price;
            }

            public override string ToString()
            {
                return $"{title}, {Author}, {YearOfPublication}, {Price} zł";
            }

            public int CompareTo(Book other)
            {
                return Price.CompareTo(other.Price);
            }
        }

        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
            books.Add(new Book("Hobbit2", "Pawlak", 2000, 155.99));
            books.Add(new Book("Hobbit3", "Arbuz", 2000, 5.99));
            books.Add(new Book("Hobbit4", "Arbuz", 1948, 5.99));

            Console.WriteLine($"\n\nLista książek: ");
            foreach(Book book in books)
            {
                Console.WriteLine(book.ToString());
            }

            books.Sort();
            Console.WriteLine($"\n\nPosortowana lista książek: ");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine($"\n\nPosortowana lista książek według daty publikacji: ");
            var sortedByYear = books.OrderBy(b => b.YearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine($"\n\nPosortowana lista książek według autorów nierosnąco: ");
            var sortedByAuthorDesc = books.OrderByDescending(b => b.Author); 
            foreach (Book book in sortedByAuthorDesc)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine($"\n\nPosortowana lista książek według ceny nierosnąco i daty publikacji od najstarszej książki: ");
            var sortedByPriceDescAndYear = books.OrderByDescending(b => b.Price).ThenBy(b => b.YearOfPublication);
            foreach (Book book in sortedByPriceDescAndYear)
            {
                Console.WriteLine(book.ToString());
            }

            Console.ReadKey();
        }
    }
}
