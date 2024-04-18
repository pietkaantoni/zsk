using _13_2_destruktor_symulator.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _13_2_destruktor_symulator
{
    internal class Program
    {
        /*
         * Zadanie: Symulator jazdy samochodem w C#
        1. Zaprojektuj Menu Symulatora (DisplayMenu):
            o Stwórz menu, które wyświetli opcje takie jak: dodanie samochodu, wyświetlenie listy, jazda, symulacja uszkodzenia, zezłomowanie i wyjście z programu.
            o Podpowiedź: Użyj pętli i instrukcji warunkowych do obsługi różnych opcji menu.
        2. Bezpieczne Wprowadzanie Danych (GetUserInput):
            o Zaimplementuj mechanizmy walidacji danych wejściowych, aby uniknąć błędów spowodowanych nieprawidłowym wprowadzeniem informacji przez użytkownika.
            o Podpowiedź: Wykorzystaj int.TryParse do bezpiecznego parsowania danych wejściowych i obsłuż wyjątki.
        3. Dodawanie Nowych Samochodów (AddCar):
            o Pozwól użytkownikowi na dodanie nowego samochodu do symulatora, poprzez podanie marki i modelu.
            o Podpowiedź: Utwórz instancję klasy Car i dodaj ją do listy oraz słownika.
        4. Wyświetlanie Listy Samochodów (DisplayCars):
            o Zapewnij funkcjonalność wyświetlania wszystkich samochodów dostępnych w symulatorze.
            o Podpowiedź: Iteruj po słowniku samochodów, wyświetlając ich klucz, markę i model.
        5. Jazda Testowa (DriveCar):
            o Zaprogramuj opcję, która umożliwi “jazdę” wybranym samochodem.
            o Podpowiedź: Znajdź samochód w słowniku i wywołaj jego metodę Drive.
        6. Symulacja Uszkodzeń (SimulateDamage):
            o Dodaj możliwość symulowania losowych uszkodzeń samochodu.
            o Podpowiedź: Zaimplementuj metodę w klasie Car, która zmieni stan samochodu.
        7. Zezłomowanie Samochodu (ScrapCar):
            o Stwórz procedurę, która pozwoli na usunięcie samochodu z symulatora.
            o Podpowiedź: Usuń samochód z listy i słownika, a następnie wywołaj Dispose.8. Zarządzanie Pamięcią:
            o Zaimplementuj odpowiednie zarządzanie pamięcią, w tym zwalnianie zasobów przy pomocy interfejsu IDisposable.
            o Podpowiedź: Upewnij się, że każdy obiekt klasy Car jest poprawnie usuwany.
        9. Testowanie Programu:
            o Przygotuj zestaw testów jednostkowych, które sprawdzą poprawność działania kluczowych funkcji symulatora.
            o Podpowiedź: Użyj frameworka do testów jednostkowych, np. NUnit lub MSTest, do przetestowania logiki programu.
         */

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Dictionary<int, Car> carDictionary = new Dictionary<int, Car>();

            while (true)
            {
                DisplayMenu();
                int choice = GetUserInput();

                switch (choice)
                {
                    case 1:
                        AddCar(cars, carDictionary);
                        break;
                    case 2:
                        DisplayCars(carDictionary);
                        break;
                    case 3:
                        DisplayCars(carDictionary);
                        DriveCar(carDictionary);
                        break;
                    case 4:
                        DisplayCars(carDictionary);
                        SimulateDamage(carDictionary);
                        break;
                    case 5:
                        DisplayCars(carDictionary);
                        scrapCar(carDictionary);
                        break;
                    case 6:
                        Console.WriteLine("Zamykanie symulatora");
                        return;
                    default:
                        break;
                }
                Console.WriteLine("\nNaciśnij dowolny klawisz, aby powrócić do menu");
                Console.ReadKey();
            }
        }

        private static void scrapCar(Dictionary<int, Car> carDictionary)
        {
            Console.Write("Podaj numer samochodu do zezłomowania:");
            int carNumber = GetUserInput(carDictionary);
            Car carToScrap = carDictionary[carNumber];
            carToScrap = null;
            GC.Collect();
            Console.WriteLine($"Samochód {carToScrap} został zezłomowany");
        }

        private static void SimulateDamage(Dictionary<int, Car> carDictionary)
        {
            Console.Write("Podaj numer samochodu, który będzie podlegać wypadkowi:");
            int carNumber = GetUserInput(carDictionary);
            Car carToDamage = carDictionary[carNumber];
            carToDamage.SimulateRandomDamage();
        }

        private static void DriveCar(Dictionary<int, Car> carDictionary)
        {
            Console.Write("Podaj numer samochodu do jazdy:");
            int carNumber = GetUserInput(carDictionary);
            Car carToDrive = carDictionary[carNumber];
            carToDrive.Drive();
        }

        private static void DisplayCars(Dictionary<int, Car> carDictionary)
        {
            if(carDictionary.Count == 0)
            {
                Console.WriteLine("\nBrak samochodów do wyświetlenia\n");
            }
            else
            {
                Console.WriteLine("\nLista samochodów:");
                foreach (var carEntry in carDictionary)
                {
                    int key = carEntry.Key;
                    Car car = carEntry.Value;
                    Console.WriteLine($"Klucz: {key}, marka: {car.Brand}, model: {car.Model}");
                }
            }
        }

        private static void AddCar(List<Car> cars, Dictionary<int, Car> carDictionary)
        {
            Console.Write("Podaj markę samochodu:");
            string brand = Console.ReadLine();
            Console.Write("Podaj model samochodu:");
            string model = Console.ReadLine();
            Car newCar = new Car(brand, model);
            cars.Add(newCar);
            carDictionary[cars.Count] = newCar;
            Console.WriteLine("Dodano nowy samochód");
        }

        private static int GetUserInput(Dictionary<int, Car> carDictionary = null)
        {
            int input;

            while (true)
            {
                Console.WriteLine("\nPodaj wartość(int):");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (carDictionary == null || carDictionary.ContainsKey(input))
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("\nNumer samochodu nie istnieje w słowniku\n");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format. Sprubuj ponownie");
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu symulatora jazdy samochodem");
            Console.WriteLine("1. Dodaj samochód");
            Console.WriteLine("2. Wyświetl listę samochodów");
            Console.WriteLine("3. Jedź samochodem");
            Console.WriteLine("4. Symuluj losowe uszkodzenie");
            Console.WriteLine("5. Zezłomuj samochód");
            Console.WriteLine("6. Wyjście");
        }
    }
}