using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tabA;
            do
            {
                tabA = CreateArray("tabA");
            } while (tabA == null);
            
            tabA = SetArray(tabA, "tabA");
            
            DisplayArray(tabA, "tabA");
            
            Console.ReadLine();
            /*
             * funkcja statyczna, która pozwala wprowadzić rozmiar tablicy i nazwę CreateArray()
             * funkcja statyczna, która ustawia elementy tablicy SetArray()
             * funkcja statyczna, która wyświetla zawartość tablicy DisplayArray()
             */
        }
        public static int[] CreateArray(string name)
        {
            Console.Write($"Podaj rozmiar tablicy {name} <0 ; {int.MaxValue}>: ");
            int size = 0;
            try
            {
                size = int.Parse(Console.ReadLine());
                if (size <= 0) throw new ArgumentException("rozmiar tablicy musi być dodatni.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nWystąpił błąd: [0], {ex.Message}");
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nBłędny format danych, trzeba wprowadzić liczbę naturalną.\n");
                return null;
            }
            int[] array = new int[size];
            return array;
        }
        public static int[] SetArray(int[] array, string name)
        {
            Console.WriteLine($"\nPodaj elementy tablicy {name}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Podaj element tablicy {i+1}: ");
                try
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\nBłędny format danych, trzeba wprowadzić liczbę naturalną.\n");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"podana liczba wykracza poza możliwości int, musisz się zmieścić w przedziale <{int.MinValue} ; {int.MaxValue}>");
                }
                catch (Exception ex)
                {
                    
                }
            }
            return array;
        }
        public static void DisplayArray(int[] array, string name)
        {
            Console.Write($"\nWyświetlanie zawartości tablicy {name}\n");
            int i = 0;
            foreach (int element in array)
            {
                Console.WriteLine($"{name}[{i}]: {element}");
                i++;
            }
        }
    }
}
