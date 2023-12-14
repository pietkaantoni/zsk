using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> d = new Dictionary<int, string>();

            d.Add(1, "Anna");
            d.Add(2, "Tomasz");
            d.Add(3, "Franek");

            foreach (var item in d)
            {
                Console.WriteLine($"{item.Value}");
            }
            Console.WriteLine();
            //########################################################################

            Dictionary<string, int> d2 = new Dictionary<string, int>();

            d2.Add("jeden", 1);
            d2.Add("dwa", 2);
            d2.Add("trzy", 3);

            foreach (var item in d2)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine();
            //#########################################################################

            Dictionary<string, string> capitals = new Dictionary<string, string>();

            capitals.Add("Polska", "Warszawa");
            capitals.Add("Niemcy", "Berlin");
            capitals.Add("Francja", "Paryż");

            foreach(KeyValuePair<string, string> item in capitals)
            {
                Console.WriteLine(item.Value);
            }
            Console.WriteLine();
            //###########################################################################

            Dictionary<string, string> phones = new Dictionary<string, string>()
            {
                {"+48 123 456 789", "Anna" },
                {"+48 123 456 788", "Franek" },
                {"+48 123 456 787", "Wojciech" },

            };
            foreach (var item in phones)
            {
                Console.WriteLine(item.Value, item.Key);
            }
            Console.WriteLine();
            //############################################################################

            Dictionary<string, string> animals = new Dictionary<string, string>()
            {
                {"pies", "hau hau" },
                {"kot", "miau miau" },
                {"koń", "iha" },

            };
            foreach (var item in animals)
            {
                Console.WriteLine($"{item.Value}");
            }
            Console.WriteLine();
            //############################################################################

            Dictionary<string, string> colors = new Dictionary<string, string>()
            {
                {"biały", "#FFFFFF" },
                {"czarny", "#000000" },
                {"czerwony", "#FF0000" },
                {"zielony", "#00FF00" },
                {"niebieski", "#0000FF" },

            };
            foreach (var color in colors)
            {
                Console.WriteLine($"Kolor: {color.Key}, hex: {color.Value}" );
            }
            Console.WriteLine();
            //############################################################################

            /*
              * Napisz program, który tworzy słownik typu Dictionary<string, string> i umożliwia użytkownikowi 
              * wprowadzenie dowolnej liczby par klucz-wartość.
             Następnie program wyświetla wszystkie elementy słownika w formacie: “Klucz: …, wartość: …”.
             Użyj pętli for do pobierania danych od użytkownika i pętli foreach do wyświetlania elementów słownika.
        
             Przykład działania programu:
        
             Podaj ile par klucz-wartość chcesz wprowadzić: 3
             
             Podaj klucz: imię
             Podaj wartość: Anna
             Podaj klucz: kolor
             Podaj wartość: niebieski
             Podaj klucz: zwierzę
             Podaj wartość: kot
        
             Klucz: imię, wartość: Anna
             Klucz: kolor, wartość: niebieski
             Klucz: zwierzę, wartość: kot
            */

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            Console.Write("Podaj ile par klucz-wartość chcesz wprowadzić: ");
            int n = int.Parse(Console.ReadLine());
            string klucz, wartosc;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Podaj klucz: ");
                klucz = Console.ReadLine();
                Console.Write("Podaj wartość: ");
                wartosc = Console.ReadLine();
                dictionary.Add(klucz, wartosc);
            }
            
            foreach(var item in dictionary)
            {
                Console.WriteLine($"Klucz: {item.Key}, wartość: {item.Value}");
            }

            Console.ReadLine();
        }
    }
}
