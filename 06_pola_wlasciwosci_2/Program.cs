using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_pola_wlasciwosci
{
    class Program
    {
        enum InteriorColorOptions
        {
            Czarny,
            Szary,
            Beżowy
        }
        class Car
        {
            //pola
            public string brand;
            public string model;
            //koniec

            //pola (prywatne)
            private int _productionYear;
            private decimal _price;
            private string _color;
            private string _interiorColor;
            //koniec

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
                    string[] allowedColors = { "czarny", "biały", "czerwony", "zielony", "niebieski" };
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Kolor nie może być pusty");
                    if (Array.IndexOf(allowedColors, value.ToLower()) == -1)
                    {
                        string allowedColorsList = string.Join(", ", allowedColors);
                        throw new ArgumentException($"Kolor musi być jednym z: {allowedColorsList}");
                    }
                    _color = value;
                }
            }
            public string InteriorColor
            {
                get { return _interiorColor; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Kolor wnętrza nie może być pusty");
                    if (!Enum.TryParse<InteriorColorOptions>(value, true, out _))
                    {
                        string allowedColorList = string.Join(", ", Enum.GetNames(typeof(InteriorColorOptions))).ToLower();
                        throw new ArgumentException($"Kolor wnętrza musi być jednym z: {allowedColorList}");
                    }
                    _interiorColor = value;
                }
            }
            //koniec

            //konstruktory
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
            //konic

            //metody
            public void DisplayCar()
            {
                Console.WriteLine($"Samochód: {brand} {model}, rok produkcji: {ProductionYear}, color: {Color}, cena: {Price:C}"); // Price:C -> zł
            }
            //koniec
        }
        static void Main(string[] args)
        {
            
            Car car1 = new Car();
            car1.brand = "Toyota";
            car1.model = "Corolla";
            car1.ProductionYear = 2000;
            car1.Price = 20000.99m;
            car1.Color = "czarny";
            car1.DisplayCar();

            Car car2 = new Car("BMW", "i7", 2024, 75000.5m, "biały");
            car2.DisplayCar();
            
            try
            {
                car2.ProductionYear = 1000;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            try
            {
                car2.Price = -3;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            try
            {
                car1.InteriorColor = InteriorColorOptions.Czarny.ToString();
                car2.InteriorColor = "Czerwony";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}