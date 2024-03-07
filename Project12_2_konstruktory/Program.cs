using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project12_1_konstruktory.classes;

namespace Project12_1_konstruktory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p0 = new Person();
            Person p1 = new Person(name: "Kowalski");
            Person p2 = new Person(name: "Piętka", surname: "Antoni");
            Person p3 = new Person(name: "Nowak", surname: "Jan", age: 80);
            Person p4 = new Person(name: "Nowak", surname: "Jan", age: 80, height: 175.5f );

            Console.WriteLine("Ilość obiektów klasy Person {0}", Person.Counter);
            
            List<Person> persons = new List<Person>();
            /*
            persons.Add(p0);
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);
            persons.Add(p4);
            */

            persons.AddRange(collection: new[] {p0, p1, p2, p3, p4});

            Console.WriteLine("Ilość obiektów klasy Person {0}", persons.Count);

            Console.ReadKey();
        }
    }
}
