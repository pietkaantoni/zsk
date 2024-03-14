using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Project13_1_enum.classes;

namespace Project13_1_enum
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
            
            Animal a2 = new Animal("Mruczek", new DateTime(2000, 1, 10));
            Console.WriteLine(a2.Describe());
            a2.ShowAge();
            
            Animal a3 = new Animal("Mruczek", new DateTime(2000, 1, 10), true);
            Console.WriteLine(a3.Describe());
            a3.ShowAge();
            
            Animal a4 = new Animal("Mruczek", new DateTime(2000, 1, 10), true, Kind.Ssak);
            Console.WriteLine(a4.Describe());
            a4.ShowAge();
            */

            #endregion

            List<Animal> animals = new List<Animal>();
            ShowMainMneu(animals);



            Console.ReadKey();
        }

        private static void ShowMainMneu(List<Animal> animals)
        {
            Console.Clear();

            Console.WriteLine("Witaj w programie do zarządzania zwierzętami");
            Console.WriteLine("1. Dodaj zwierzę");
            Console.WriteLine("2. Pokaż listę");
            Console.WriteLine("3. Pokaż szczegóły zwierzęcia");
            Console.WriteLine("4. Usuń zwierzę");
            Console.WriteLine("5. Zakończ program \n");
            Console.WriteLine("Wybierz jedną z opcji: ");

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
                    AddAnimalDetails(animals);
                    break;

                case "4":
                    RemoveAnimal(animals);
                    break;

                case "5":
                    Console.WriteLine("Dziękujemy za skorzystanie z programu");
                    return;
                deafult:
                    Console.WriteLine("Niepoprawna opcja. Naciśnij dowolny klawisz, aby spróbować ponownie");
                    Console.ReadKey();
                    ShowMainMneu();
                    break;
            }



        }

        private static void AddNewAnimal(List<Animal> animals)
        {
            throw new NotImplementedException();
        }

        private static void ShowAnimalList(List<Animal> animals)
        {
            throw new NotImplementedException();
        }

        private static void AddAnimalDetails(List<Animal> animals)
        {
            throw new NotImplementedException();
        }

        private static void RemoveAnimal(List<Animal> animals)
        {
            throw new NotImplementedException();
        }
    }
}
