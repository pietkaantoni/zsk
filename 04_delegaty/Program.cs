using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_delegaty
{
    internal class Program
    {
        public delegate float Operation(float x, float y);

        public static float Add(float x, float y)
        {
            return x + y;
        }
        public static float Substract(float x, float y)
        {
            return x - y;
        }
        public static float Multuply(float x, float y)
        {
            return x * y;
        }
        public static float Divide(float x, float y)
        {
            return x / y;
        }

        public static void DisplayResult(Operation op, float x, float y)
        {
            float result;

            if (op.Method.Name == "Divide" && y == 0)
            {
                Console.WriteLine("Błędne dzielenie przez 0");
                result = 0;
            }
            else
            {
                try
                {
                    result = op(x, y);
                    Console.WriteLine("Wynik operacji {0} na liczbach {1} i {2} wynosi {3}", op.Method.Name, x, y, result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    result = 0;
                }
            }
        }

        public static float GetFloatFromUser(string prompt)
        {
            Console.WriteLine(prompt);
            float number;

            bool isValid = float.TryParse(Console.ReadLine(), out number);

            while(!isValid)
            {
                Console.Write("Nieprawidłowe dane. Podaj liczbę:");
                isValid = float.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        static void Main(string[] args)
        {
            //kod bardziej elastyczny (łatwo dodawać nowe operacje) i łatwy do utrzymania dzięki Operacjom, delegatom
            float a = GetFloatFromUser("Podaj pierwszą liczbę:");
            float b = GetFloatFromUser("Podaj drugą liczbę:");

            Operation adding = new Operation(Add);
            Operation substracting = new Operation(Substract);
            Operation multuplying = new Operation(Multuply);
            Operation dividing = new Operation(Divide);

            DisplayResult(adding, a, b);
            DisplayResult(substracting, a, b);
            DisplayResult(multuplying, a, b);
            DisplayResult(dividing, a, b);
            
            Console.ReadKey();
        }
    }
}
