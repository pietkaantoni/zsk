using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_zdarzenia
{
    internal class Program
    {
        public enum AnimalSpecies
        {
            Dog,
            Cat,
            Lion,
            Fish
        }
        

        public class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public AnimalSpecies Species { get; set; }
            public List<string> Traits { get; set; }
            public Dictionary<string, string> Attributes { get; set; }
            public bool IsWild { get; set; }

            public event Action<string> AnimalCreated;
            public event Action<string> AnimalTraitAdded;
            public event Action<string> AnimalAttributeAdded;
            public event Action<string> AnimalStatusChange;

            public Animal(string name, int age, AnimalSpecies species, bool isWild)
            {
                this.Name = name;
                this.Age = age;
                this.Species = species;
                this.IsWild = isWild;
                Traits = new List<string>();
                Attributes = new Dictionary<string, string>();
                AnimalCreated?.Invoke($"Stworzono zwierzę: {this.Name}");
            }
            public void AddTrait(string trait)
            {
                Traits.Add(trait);
                AnimalTraitAdded?.Invoke($"Dodano nowy trait: {trait}");
            }
            public void AddAttribute(string key, string value)
            {
                Attributes.Add(key, value);
                AnimalTraitAdded?.Invoke($"Dodano nowy attrybut: {key}: {value}");
            }
            public void ChangeStatus(bool isWild)
            {
                this.IsWild=isWild;
                string status = isWild ? "Dziki" : "Nie dziki";
                AnimalStatusChange?.Invoke($"Zmienionio status na {status}");
            }
            public void ShowInfo()
            {
                Console.WriteLine($"{this.Name}, {this.Age} years old, dziki: {this.IsWild}, Traits: {string.Join(", ", Traits)}");
            }

        }

        static void Main(string[] args)
        {
            Animal cat = new Animal("Puszek", 2, AnimalSpecies.Cat, false);
            cat.AnimalCreated += message => Console.WriteLine(message);
            cat.AnimalTraitAdded += message => Console.WriteLine(message);
            cat.AnimalAttributeAdded += message => Console.WriteLine(message);
            cat.AnimalStatusChange += message => Console.WriteLine(message);
            cat.AddTrait("Powerful");
            cat.AddTrait("Cute");
            cat.AddAttribute("Color", "Grey");
            cat.ChangeStatus(false);
            cat.ShowInfo();
            Console.WriteLine("Koniec Programu");
            Console.ReadKey();
        }
    }
}
