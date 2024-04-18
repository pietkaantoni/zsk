using _13_2_destruktor_symulator.classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
                
                try
                {
                    int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                        
                }



                switch (choice)
                {
                    case 1:
                        Console.Write("Podaj markę samochodu:");
                        string brand = Console.ReadLine();
                        Console.Write("Podaj model samochodu:");
                        string model = Console.ReadLine();
                        Car newCar = new Car(brand, model);
                        cars.Add(newCar);
                        carDictionary[cars.Count] = newCar;
                        Console.WriteLine("Dodano nowy samochód");
                        break;
                    case 2:
                        Console.WriteLine("\nLista samochodów:");
                        foreach (Car car in cars)
                        {
                            Console.WriteLine($"{car.Brand} {car.Model}");
                        }
                        break;
                    case 3:
                        Console.Write("Podaj numer samochodu do jazdy:");
                        int carNumber = int.Parse(Console.ReadLine());
                        if (carDictionary.TryGetValue(carNumber, out Car selectedCar))
                        {
                            selectedCar.Drive();
                        }
                        else
                        {
                            Console.WriteLine("Nierawidłowy numer samochodu");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Podaj numer samochodu do symulacji uszkodzenia:");
                        int damagedCarNumber = int.Parse(Console.ReadLine());
                        if(carDictionary.TryGetValue(damagedCarNumber, out Car damagedCar))
                        {
                            damagedCar.SimulateRandomDamage();
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer samochodu");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Podaj numer samochodu do zezłomowania:");
                        int scrappedCarNumber = int.Parse(Console.ReadLine());
                        if (carDictionary.TryGetValue(scrappedCarNumber, out Car scrappedCar))
                        {
                            scrappedCar = null;
                            GC.Collect();
                            Console.WriteLine($"Samochód {scrappedCar} został zezłomowany");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer samochodu");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Zamykanie symulatora");
                        return;
                    default:
                        break;
                }
                Console.WriteLine("\nNaciśnij dowolny klawisz, aby powrócić do menu");
                Console.ReadKey;
            }

            Console.ReadKey();
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
        private static int GetUserInput()
        {
            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                if (int.TryParse(Console.ReadLine(), out int choice)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Błędnie wprowadzone dane. Sprubuj ponownie")
                }
            }
        }


    }
}