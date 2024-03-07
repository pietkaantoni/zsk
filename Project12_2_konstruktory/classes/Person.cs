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
        public float Height { get; set; }

        //konstruktor statyczny jest wywoływany automatycznie, aby zainicjować klasę przed utworzeniem pierwszej instancji.
        //Konstruktor statyczny jest wywoływany tylko raz, przed pierwszym użyciem typu. Nie może mieć parametrów ani modyfikatorów dostępu.
        //Służy do inicjowania pól statycznych lub wykonywania innych operacji statycznych
        //(wykonywanie dowolnego kodu, który jest związany z klasą a nie z jej obiektami np. ustawienie wartości domyślnych pól statycznych)
        static Person()
        {
            Console.WriteLine("Statyczny konstruktor klasy Person\n");
        }

        //konstruktor domyślny jest bezparametrowy. Jeśłi klasa nie ma żadnego konstruktora parametrycznego, to konstruktor domyślny jest wywoływany przy tworzeniu obiektu.
        //Inicjuje on wszystkie pola do ich wartości domyślnych.
        //Jeśli zdefiniujemy jakiś konstruktor parametryczny, to nie otrzymamy automatycznie konstruktora domyślnego i możemy/musimy go samodzielnie zadeklarować
        public Person()
        {
            Name = "nieznane";
            Surname = "nieznane";
            Console.WriteLine("Konstruktor domyślny klasy Person");
            Counter++;
        }

        //konstruktor parametryczny ma co najmniej jeden parametr. Służy do inicjowania pól obiektu zgodnie z wartościami podanymi przy tworzeniu obiektu.
        //Możemy mieć wiele konstruktorów parametrycznych, o ile różnią się liczbą lub/i typem parametrów
        public Person(string name)
        {
            Console.WriteLine("Konstruktor parametryczny z 1 parametrami");
            Name = name;
            Counter++;
        } 

        public Person(string name, string surname)
        {
            Console.WriteLine("Konstruktor parametryczny z 2 parametrami");
            Name = name;
            Surname = surname;
            Counter++;
        }

        public Person(string name, string surname, int age) :this(name, surname)
        {
            Console.WriteLine("Konstruktor parametryczny z 3 parametrami");
            Age = age;
            Counter++;
        }
        //this służy do wywołania innego konstruktora tej samej klasy, cyzli konstruktora z dwoma parametrami.
        //Dzięki temu konstruktor z trzema parametrami nie musi inicjować pól Name, Surname a może skupić się na dodaniu pola Age.
        //Jest to sposób na uniknięcie powtarzania kodu i zapewnienie spójności danych
        public Person(string name, string surname, int age, float height) : this(name, surname, age)
        {
            Console.WriteLine("Konstruktor parametryczny z 4 parametrami");
            Height = height;
            Counter++;
        }

    }
}
