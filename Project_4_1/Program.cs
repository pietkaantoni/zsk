using System;
using System.Security.Cryptography;

namespace Project_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(int.MinValue);    // -2^16 
            Console.WriteLine(int.MaxValue);    // 2^16 - 1

            Console.WriteLine(char.MaxValue);   // ?

            string firstName = "Janusz";
            Console.WriteLine(firstName.Length);    // 6

            Console.WriteLine(firstName[0]);    // J

            string lastName = "Nowak";
            Console.WriteLine(firstName.Equals(lastName));   // False
            Console.WriteLine("Janusz".Equals("Janusz"));    // True
            Console.WriteLine("Janusz".Equals("janusz"));    // False

            //###################################################################
            
            Console.Write("Podaj imię:");
            string? name2 = Console.ReadLine();
            Console.WriteLine($"Imię: {name2}");

            while( name2.Length == 0 ) 
            {
                Console.Clear();
                Console.WriteLine("Podaj imię:");
                name2 = Console.ReadLine();

            }
            
            //#####################################################################

            float a;
            do
            {
                Console.Clear();
                Console.Write($"Podaj bok a:");
                a = float.Parse(Console.ReadLine());
            }while (a <= 0);

            Console.WriteLine($"Pole kwadratu o boku {a} wynosi: {a*a:2f}");

            //#########################################################################
            //Wzór Herona

            float b;
            float c;

            do
            {
                Console.Clear();
                Console.Write($"Podaj bok a:");
                a = float.Parse(Console.ReadLine());
                Console.Write($"Podaj bok b:");
                b = float.Parse(Console.ReadLine());
                Console.Write($"Podaj bok c:");
                c = float.Parse(Console.ReadLine());

            }while (a+b<=c || a+c<=b || b+c<=a);

            Console.WriteLine($"Pole trójkąta o bokach {a,b,c} wynosi: {(a + b + c)/2:2f}");
        }
    }
}