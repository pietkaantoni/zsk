﻿using System;
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
                Console.WriteLine($"Czytelnik {FirstName} {LastName} wypożyczył książkę: \"{book.Title}\" którą napisał {book.Author.FirstName} {book.Author.LastName}");
            }

        }
        public class Library
        {
            public List<Book> BooksList { get; set; }
            public List<Reader> ReaderList { get; set; }
            public List<Author> AuthorList { get; set; }

            public Library()
            {
                BooksList = new List<Book>();
                ReaderList = new List<Reader>();
                AuthorList = new List<Author>();
            }
            public void AddBook(Book book)
            {
                BooksList.Add(book);
                Console.WriteLine($"Dodano książkę: {book.Title}");
            }
            public void AddReader(Reader reader)
            {
                ReaderList.Add(reader);
                Console.WriteLine($"Dodano czytelnika: {reader.FirstName} {reader.LastName}");
            }
            public void AddAuthor(Author author)
            {
                AuthorList.Add(author);
                Console.WriteLine($"Dodano autora: {author.FirstName} {author.LastName}");
            }
            public void BorrowBook(Reader reader, Book book)
            {
                if (BooksList.Contains(book))
                {
                    reader.BorrowBook(book);
                    BooksList.Remove(book);
                    Console.WriteLine($"Książka {book.Title} została wypożyczona przez: {reader.FirstName} {reader.LastName}");
                }
                else
                {
                    Console.WriteLine($"Nie ma książki: \"{book.Title}\" w bibliotece");
                }
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
            Library library = new Library();
            library.AddBook(book);
            library.AddReader(reader);

            library.BorrowBook(reader, book);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Dodaj Autora:");
                Console.WriteLine("2. Dodaj książkę:");
                Console.WriteLine("3. Dodaj czytelnika:");
                Console.WriteLine("4. Wyświetl autorów:");
                Console.WriteLine("5. Wyświetl książki:");
                Console.WriteLine("6. Wyświetl czytelników:");
                Console.WriteLine("8. wyjście:");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Podaj imię autora: ");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko autora: ");
                        string lastname = Console.ReadLine();
                        library.AddAuthor(new Author(firstname, lastname));
                        break;
                    case "2":
                        Console.WriteLine("Podaj nazwę książki: ");
                        string bookname = Console.ReadLine();
                        Console.WriteLine("Podaj rok opublikowania książki: ");
                        int pyear =int.Parse(Console.ReadLine());
                        library.AddAuthor(new Book(bookname, , pyear));
                        break;
                    case "3":
                        Console.WriteLine("Podaj imię czytelnika: ");
                        string firstReaderName = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko czytelnika: ");
                        string lastReaderName = Console.ReadLine();
                        library.AddAuthor(new Author(firstReaderName, lastReaderName));
                        break;
                    case "4":
                        Console.WriteLine("Autorzy:");
                        for(int i=0; i<library.AuthorList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}\t{library.AuthorList[i].FirstName} {library.AuthorList[i].LastName}\t");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Książki:");
                        for (int i = 0; i < library.BooksList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}\t\"{library.BooksList[i].Title}\" wyprodukowana w:{library.BooksList[i].PublicationYear}\t");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Czytelnicy:");
                        for (int i = 0; i < library.ReaderList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}\t{library.ReaderList[i].FirstName} {library.ReaderList[i].LastName}\t");
                        }
                        break;

                }
            }

            Console.Read();
        }
    }
}