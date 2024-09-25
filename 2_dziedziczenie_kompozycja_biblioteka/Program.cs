using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_dziedziczenie_kompozycja_biblioteka
{
    class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

        }
        public class Author : Person
        {
            public List<Book> BookList { get; set; }
            
            public Author(string firstName, string lastName) : base(firstName, lastName)
            {
                BookList = new List<Book>();
            }
            public void AddBook(Book book)
            {
                BookList.Add(book);
            }

        }
        public class Book
        {
            public string Title { get; set; }
            public Author Author { get; set; }
            public int PublicationYear { get; set; }
            
            public Book(string title, Author author, int publicationYear) 
            {
                Title = title;
                Author = author;
                PublicationYear = publicationYear;
            }

        }

        public class Reader : Person
        {
            public List<Book> BorrowedBooksList { get; set; }

            public Reader(string firstName, string lastName) : base(firstName, lastName)
            {
                BorrowedBooksList = new List<Book>();
            }
            public void BorrowBook(Book book)
            {
                BorrowedBooksList.Add(book);
                Console.WriteLine($"Książkę \"{book.Title}\" napisał {book.Author.FirstName} {book.Author.LastName} i wypożyczył ją {this.FirstName} {this.LastName}");
            }

        }

        static void Main(string[] args)
        {
/*
        Zadanie: Utworzenie klasy Reader
        Cel:
        Utworzenie klasy Reader, która dziedziczy po klasie Person i reprezentuje czytelnika biblioteki.Klasa ta powinna zawierać listę wypożyczonych książek oraz metodę do dodawania książek do tej listy.


        Kroki:
        Dziedziczenie po klasie Person:
        Klasa Reader powinna dziedziczyć po klasie Person.
        Deklaracja właściwości:
        Utwórz właściwość BorrowedBooksList typu List<Book>, która będzie przechowywać listę wypożyczonych książek.
        Konstruktor:
                    Utwórz konstruktor, który przyjmuje dwa parametry: firstName i lastName.
        Konstruktor powinien inicjalizować pola FirstName i LastName(odziedziczone z klasy Person) oraz inicjalizować pustą listę BorrowedBooksList.
        Metoda BorrowBook:
        Utwórz metodę BorrowBook, która przyjmuje parametr typu Book.
        Metoda ta powinna dodawać książkę do listy BorrowedBooksList i wyświetlać komunikat informujący o wypożyczeniu książki.            
*/

            Author author = new Author("Adam", "Mickiewicz");
            Book book = new Book("Pan Tadeusz", author, 1834);
            author.AddBook(book);
            Reader reader = new Reader("Antoni", "Piętka");
            reader.BorrowBook(book);

            Console.Read();
        }
    }
}
