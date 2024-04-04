using _12_2_Konstruktory_Animal.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_2_Konstruktory_Animal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region animalObjects
            /*
            Animal a1 = new Animal("Burek");
            Console.WriteLine(a1.Describe());
            a1.BirthDate = new DateTime(2000, 2, 3);
            a1.ShowAge();
            */

            /*
            Animal a2 = new Animal("Mruczek", new DateTime(2020, 1, 10));
            Console.WriteLine(a2.Describe());
            a2.BirthDate = new DateTime(2020, 2, 3);
            a2.ShowAge();
            */

            /*
            Animal a3 = new Animal("Mruczek", new DateTime(2020, 1, 10), true);
            Console.WriteLine(a3.Describe());
            a3.BirthDate = new DateTime(2020, 2, 3);
            a3.ShowAge();
            */

            /*
            Animal a4 = new Animal("Mruczek", new DateTime(2020, 1, 10), true, Kind.Ssak);
            Console.WriteLine(a4.Describe());
            a4.BirthDate = new DateTime(2020, 2, 3);
            
            a4.ShowAge();
            */
            #endregion

            List<Animal> animals = new List<Animal>();

            ShowMainMenu(animals);

            Console.ReadKey();
        }

        private static void ShowMainMenu(List<Animal> animals)
        {
            Console.Clear();

            Console.WriteLine("Witaj w programie do zarządzania zwierzętami");
            Console.WriteLine("1. Dodaj zwierzę");
            Console.WriteLine("2. Pokaż listę zwierząt");
            Console.WriteLine("3. Pokaż szczegóły zwierzęcia");
            Console.WriteLine("4. Usuń zwierzę");
            Console.WriteLine("5. Zakończ program\n");
            Console.Write("Wybierz jedną z opcji:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewAnimal(animals);
                    break;
                case "2":
                    ShowAnimalList(animals);
                    break;
                case "3":
                    ShowAnimalDetails(animals);
                    break;
                case "4":
                    RemoveAnimal(animals);
                    break;
                case "5":
                    Console.WriteLine("\nDziękujemy za skorzystanie z programu");
                    return;
                default:
                    Console.WriteLine("\nNiepoprawna opcja. Naciśnij dowolny klawisz, aby spróbować ponownie");
                    Console.ReadKey();
                    ShowMainMenu(animals);
                    break;
            }
        }

        private static void AddNewAnimal(List<Animal> animals)
        {
            Console.Clear();

            Console.WriteLine("Podaj nazwę zwierzęcia:");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj datę urodenia zwierzęcia: (RRRR-MM-DD)");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Czy zwierze jest ssakiem? (tak/nie)");
            bool isMammal = bool.Parse(Console.ReadLine());
            Console.WriteLine("Podaj rodzaj zwierzęcia:");
            Kind kind = (Kind)Enum.Parse(typeof(Kind), Console.ReadLine());

            Animal animal = new Animal(name, birthDate, isMammal, kind);

            animals.Add(animal);

            Console.WriteLine("\nDodano nowe zwierze: " + animal.Name);
            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu głównego\n");
            Console.ReadKey();
            ShowMainMenu(animals);
        }

        private static void ShowAnimalList(List<Animal> animals)
        {
            Console.Clear();

            if (animals.Count == 0)
            {
                Console.WriteLine("nie ma zwierząt na liscie");
            }
            else
            {
                Console.WriteLine("Lista zwierząt: ");
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + animals[i].Name);
                }
            }
            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu głównego\n");
            Console.ReadKey();
            ShowMainMenu(animals);
        }

        private static void ShowAnimalDetails(List<Animal> animals)
        {
            Console.Clear();

            if (animals.Count == 0)
            {
                Console.WriteLine("nie ma zwierząt na liscie");
            }
            else
            {
                Console.WriteLine("Lista zwierząt: ");
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + animals[i].Name);
                }
            }
            Console.Write("podaj numer zwierzecia, ktorego szczegoly chcesz zobaczyc:");

            int index = int.Parse(Console.ReadLine()) - 1;

            if(index >= 0 && index < animals.Count)
            {
                Animal animal = animals[index];
                Console.WriteLine("\nSzczegóły zwierzęcia:");
                Console.WriteLine(animal.Describe());
                animal.ShowAge();
            }
            else
            {
                Console.WriteLine("Niepoprawny numer. Sprubuj ponownie");
            }

            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu głównego\n");
            Console.ReadKey();
            ShowMainMenu(animals);
        }

        private static void RemoveAnimal(List<Animal> animals)
        {
            Console.Clear();

            if (animals.Count == 0)
            {
                Console.WriteLine("nie ma zwierząt na liscie");
            }
            else
            {
                Console.WriteLine("1. Usuń wszystkie zwierzęta");
                Console.WriteLine("1. Usuń jedno zwierzę");
                
                Console.WriteLine("Wybierz jedną z opcji:");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        animals.Clear();
                        if(animals.Count == 0)
                        {
                            Console.WriteLine("\nUsunięto wszystkie zwierzęta\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Lista zwierząt: ");
                        for (int i = 0; i < animals.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + animals[i].Name);
                        }
                        Console.WriteLine("\nPodaj numer zwierzęcia, które chcesz usunąć:");

                        int index = int.Parse(Console.ReadLine()) - 1;

                        if (true)
                        {
                            animals.RemoveAt(index);
                            Console.WriteLine("\nUsunięto zwierzę\n");
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawny numer zwierzęcia. Sprubuj ponownie");
                        }
                        break;
                    default: 
                        Console.WriteLine("\nNiepoprawna opcja, spróbuj ponownie");
                        break;
                }
            }

            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu głównego\n");
            Console.ReadKey();
            ShowMainMenu(animals);
        }
    }
}