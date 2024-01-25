using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pietka_Antoni_gr2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //nie pamiętam jak wylosować liczby
            bool isCorrect = false;
            do
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input < 0) throw new Exception($"\nWystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}>");
                    List<int> liczby = UtworzListe("Liczby", input);
                    isCorrect = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Wystąpił błąd, zły format.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Wystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}>");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Wystąpił błąd, zły argument");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!isCorrect);

            int[,] dwaWymiary = UtworzTablice("dwaWymiary");

            int suma = 0;
            for (int i = 0; i < dwaWymiary.Length; i++)
            {
                suma += dwaWymiary[i,i];
            }
            Console.WriteLine($"Suma głównej przekątnej tablicy dwaWymiary wynisi: {suma}");

            Dictionary<string, string> countries = UtworzSlownik("countries");
            isCorrect = false;
            string input;
            do
            {
                Console.WriteLine($"\nPodaj kraj, a podam Ci jego stolicę: ");
                input = Console.ReadLine();
                if(input == "koniec")
                {
                    isCorrect = true;
                }
                foreach (var item in countries)
                {
                    if(item.Key == input)
                    {
                        Console.WriteLine(item.value"\n");
                    }
                }
            } while (!isCorrect);

            Console.ReadKey();
        }
        static List<int> UtworzListe(string nazwa, int l)
        {
            List<int> lista = new List<int>();
            Console.WriteLine($"Podaj długość listy {nazwa}");

            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input < 0) throw new Exception($"\nWystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}>");
                l = input;
            }
            catch(FormatException)
            {
                Console.WriteLine($"Wystąpił błąd, zły format.");
                return null;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Wystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}>");
                return null;
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Wystąpił błąd, zły argument");
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            //_____________________________________________________________________
            int i = 0;
            try
            {
                while(i < l)
                {
                    lista.Add(int.Parse(Console.ReadLine()));
                    i++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Wystąpił błąd, zły format. \nWprowadź dane jeszcae raz.\n\n");
                i--;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Wystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}> \nWprowadź dane jeszcae raz.\n\n");
                i--;
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Wystąpił błąd, zły argument. \nWprowadź dane jeszcae raz.\n\n");
                i--;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                i--;
            }

            return lista;
        }
        static int[,] UtworzTablice(string nazwa)
        {
            int[,] tablica = new int[3,3];
            Console.WriteLine($"Podaj zawartość tablicy dwuwymiarowej 3x3 {nazwa}");
            int i = 0, j = 0;
            try
            {
                while (i < 3)
                {
                    while(j<3)
                    {
                        Console.Write($"{nazwa}[{i}][{j}] = ");
                        tablica[i, j] = int.Parse(Console.ReadLine());
                        j++;
                    }
                    i++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Wystąpił błąd, zły format. \nWprowadź dane jeszcae raz.\n\n");
                j--;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Wystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}> \nWprowadź dane jeszcae raz.\n\n");
                j--;
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Wystąpił błąd, zły argument. \nWprowadź dane jeszcae raz.\n\n");
                j--;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                j--;
            }

            return tablica;
        }
        static Dictionary<string,string> UtworzSlownik(string nazwa)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Console.WriteLine($"Podaj ile krajów wraz z stolicami chcesz zapisać w słowniku {nazwa}");

            int l;
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input < 0) throw new Exception("$\"Wystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}>");
                l = input;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Wystąpił błąd, zły format.");
                return null;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Wystąpił błąd, Wprowadź dane z przedziału <0 ; {int.MaxValue}>");
                return null;
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Wystąpił błąd, zły argument");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            int kraj;
            int stolica;
            for (int i = 0; i<l; i++)
            {
                Console.WriteLine($"Podaj nazwę kraju: ");
                kraj = Console.ReadLine();
                Console.WriteLine($"Podaj stolicę {kraj}: ");
                stolica = Console.ReadLine();
                
                dict.Add(kraj, stolica);
            }

            return dict;
        }


    }
}
