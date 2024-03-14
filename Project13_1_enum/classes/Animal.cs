using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project13_1_enum.classes
{
    enum Kind
    {
        Ptak,
        Ryba,
        Gad,
        Płaz,
        Ssak
    }
    internal class Animal
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMammal { get; set; }
        public Kind Kind { get; set; }

        public Animal(string name)
        {
            this.Name = name;
        }

        public Animal(string name, DateTime birthDate) : this(name)
        {
            this.BirthDate = birthDate;
        }

        public Animal(string name, DateTime birthDate, bool isMannal) : this(name, birthDate)
        {
            this.IsMammal = isMannal;
        }
        public Animal(string name, DateTime birthDate, bool isMannal, Kind kind) : this(name, birthDate, isMannal)
        {
            this.Kind = kind;
        }

        public string Describe()
        {
            string description = "Nazwa zwierzęcia: " + this.Name + ". Data urodzenia: " + this.BirthDate.ToShortDateString() + "r. ";
            if (IsMammal)
            {
                description += "Zwierze jest ssakiem. ";
            }
            else
            {
                description += "Zwierze nie jest ssakiem. ";
            }

            description += "Rodzaj zwierzęcia: " + Kind;

            return description;
        }
        public void ShowAge()
        {
            int age  = DateTime.Now.Year - this.BirthDate.Year;
            Console.WriteLine($"Wiek {this.Name} wynosi: {age}");
        }



    }
}
