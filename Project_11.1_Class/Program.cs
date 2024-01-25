using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_11._1_Class
{
    internal class Program
    {
        class Address
        {
            public string City { get; set; }
            public string Street { get; set; }
            public string HouseOfNumber { get; set; }
            public string PostalCode { get; set; }
        }
        class Person
        {
            public string FirstName { get; private set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Address Address { get; set; }

            public void SetName(string name)
            {
                this.FirstName = name;
            }
        }
        static void Main(string[] args)
        {
            Person p1 = new Person();
            //p1.FirstName = "Janusz";
            p1.SetName("Paweł");
            Console.Write(p1.FirstName);
            Console.Write(p1.LastName);
        }
    }
}
