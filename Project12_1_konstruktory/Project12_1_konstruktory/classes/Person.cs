using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12_1_konstruktory.classes
{
    internal class Person
    {
        //statyczne, pola które przechowują liczbę obiektów klasy person
        public static int Counter = 0;

        //właściwości
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        //konstruktor statyczny, jest on wywoływany automatycznie, aby zainicjować klasę przed utworzeniem pierwszej instancji. Konstruktor statyczny jest wywoływany tylko raz. przed pierwszym użyciem typu. Nie może mieć parametrów ani modyfikatorów dostępu. Służy do inicjowania pól statycznych lub wywoływania innych operacji statycznych (wykonywanie kodu który jest związany z całą klasą, a nie jej obiektami np. ustawianie wartości domyślnych dla pól statycznych. 
        static Person()
        {
            Console.WriteLine("Statyczny konstruktor klasy Person");
            Counter++;
        }

        //konstruktor domyślny, 
        public Person()
        {
            Console.WriteLine("Konstruktor domyślny klasy Person");
        }

        //konstruktor parametryczny
        public Person(string name, string surname, int age)
        {
            Name = name; ;
            Surname = surname;
            Age = age;
        }

    }
}
