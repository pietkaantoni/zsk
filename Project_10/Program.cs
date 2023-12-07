using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(-1);
            ints.Add(100);

            Console.WriteLine($"Dlugość listy: {0}", ints.Count);
            ints.Add(1);
            Console.WriteLine($"Dlugość listy: {0}", ints.Count);

            foreach (int i in ints)
            {
                Console.WriteLine($"{i}")
            }
            Console.WriteLine();
            
            ints.Remove(0);
            ints.Remove(1);
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }

            Random losuj = new Random();
            losuj.Next(1, 101);
            Console.WriteLine(losuj);
            */

            List<int> lista = new List<int>();
            Random rand = new Random();

            bool isCorrect = false;

            try
            {
                Console.WriteLine("Podaj długość pierwotnej tablicy: ");
                int n = int.Parse(Console.ReadLine());
                /*if (n <= 0)
                {
                    throw new Exception(OverflowException);
                }*/
                for (int i = 0; i < n; i++)
                {
                    lista.Add(rand.Next(1, 101));
                }

                Console.WriteLine($"Długość listy lista, wynosi: {lista.Count} i zawiera ona wylosowane przez program liczby");
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine($"\tlista[{i}] = {lista[i]}");
                }
                podzielne_3_5(lista);
                isCorrect = true;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Podałeś zły format, wpisz wartość całkowitą, dodatnią");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Przekroczyłeś możliwości int, wpisz liczbę z zakresu <0 ; {int.MaxValue}>");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            Console.ReadLine();
        }
        public static void podzielne_3_5(List<int> lista)
        {
            List<int> nowa = new List<int>();
            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i]%3==0 || lista[i] % 5 == 0)
                {
                    nowa.Add(lista[i]);
                }
            }
            Console.WriteLine($"\nDługość listy nowa, wynosi: {nowa.Count} i zawiera ona liczby podzielne przez 3 lub 5");
            for (int i = 0; i < nowa.Count; i++)
            {
                Console.WriteLine($"\tnowa[{i}] = {nowa[i]}");
            }
        }


    }
}
