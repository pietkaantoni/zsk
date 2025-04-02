using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_pola_wlasciwosci
{
    class Program
    {
        class Car
        {
            //pola
            public string brand;
            public string model;

            //pola (prywatne)
            private int _productionYear;
            private decimal _price;
            private string _color;
            private string _interiorColor;

            //właściości
            public int ProductionYear
            {
                get { return _productionYear; }
                set 
                {
                    if (value >= 1886 && value <= DateTime.Now.Year)
                        _productionYear = value;
                    else
                        throw new ArgumentException("Rok produkcji musi być pomiędzy 1886, a obecnym rokiem");
                }
            }
            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (value >= 0)
                        _price = value;
                    else
                        throw new ArgumentException("Cena nie może być ujemna");
                }
            }
            public string Color
            {
                get { return _color; }
                set
                {
                    string[] allowedColors = { "czarny", "biały", "czerwony", "zielony", "niebieski"};
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Kolor nie może być pusty");
                    if (Array.IndexOf(allowedColors, value.ToLower()) == -1)
                    {
                        string allowedColorsList = string.Join(", ", allowedColors);
                        throw new ArgumentException($"Kolor musi być jednym z kolorów z paleti barw: {allowedColorsList}");
                    }
                    _color = value;
                }
            }

            public Car()
            {
                brand = "Nieznana";
                model = "Nieznana";
                _productionYear = 2000;
                _price = 0m;
            }

            public Car(string brand, string model, int productionYear, decimal price, string color)
            {
                this.brand = brand;
                this.model = model;
                ProductionYear = productionYear;
                Price = price;
                Color = color;
            }
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
