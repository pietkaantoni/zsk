using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wczytaj liczbę n : ");
            int n = int.Parse(Console.ReadLine());

            string[] names = new string[n];
            int[] ages = new int[n];

            for(int i = 0; i < n; i++)
            {
                Console.Write($"Podaj imię {i + 1} osoby: ");
                names[i] = Console.ReadLine();
                Console.Write($"Podaj wiek {i + 1} osoby: ");
                ages[i] = int.Parse(Console.ReadLine());
            }

            List<string> namesWithStartsA = new List<string>();
            for (int i = 0; i < n; i++)
            {
                if (names[i].StartsWith("A"))
                {
                    namesWithStartsA.Add(names[i]);
                }
            }

            Dictionary<string, int> adults = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                if (ages[i] >= 18)
                {
                    adults.Add(names[i], ages[i]);
                }
            }

            Console.WriteLine("\nTablica imion i wieków");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{names[i]} - {ages[i]}");
            }

            Console.WriteLine("\nLista imion zaczynających się na \"A\":");
            foreach (string name in namesWithStartsA)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nSłownik osób pełnoletnich:");
            foreach (var pair in adults)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            /*
Zadanie: Napisz program w języku C#, który:
 Wczytuje liczbę n, oznaczającą ilość osób, których dane chcesz wprowadzić.
 Tworzy tablicę imion i wieków tych osób, wczytując je z konsoli.
 Tworzy listę imion zaczynających się na literę A, używając wyrażeń LINQ.
 Tworzy słownik par (imie, wiek) dla osób pełnoletnich, używając wyrażeń LINQ.
 Wypisuje zawartość tablicy, listy i słownika na konsoli, używając funkcji pomocniczych.
Wskazówki:
 Użyj funkcji int.Parse lub int.TryParse, aby zamienić ciąg znaków na liczbę całkowitą.
 Użyj metody StartsWith z parametrem StringComparison, aby sprawdzić, czy ciąg
znaków zaczyna się od określonego znaku lub ciągu znaków, niezależnie od wielkości
liter.
 Użyj metody Zip, aby połączyć dwie sekwencje w jedną sekwencję par.
 Użyj metod Where, ToList i ToDictionary, aby filtrować, sortować i transformować
dane za pomocą wyrażeń LINQ.
 Użyj pętli for lub foreach, aby iterować po elementach kolekcji.
 Użyj znaku $, aby tworzyć łańcuchy znaków interpolowanych, które mogą zawierać
wartości zmiennych lub wyrażeń.
            */


            Console.ReadKey();
        }
    }
}
