using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_classes_enum.classes
{
    internal class Parking
    {
        public string Name { get; set; }
        public Car[] Cars { get; set; }
        
        public void AddCar(Car car)
        {
            for (int i = 0; i < Cars.Length; i++)
            {
                if (Cars[i] == null)
                {
                    Cars[i] = car;
                    Console.WriteLine($"Dodano samochód na miejscu parkingowym nr {i}");
                    return;
                }
            }
            Console.WriteLine($"Niestety brak wolnych miejsc parkingowych.");
        }
        public void RemoveCar(int index)
        {
            if(index >= 0 && index < Cars.Length)
            {
                if (Cars[index] != null)
                {
                    Cars[index] = null;
                    Console.WriteLine($"Samochód został nusunięty z miejsca parkingowego nr {index}");
                }
                else
                {
                    Console.WriteLine($"W podanym mkiejscu parkingowym nie ma samochodu");
                }
            }
            else
            {
                Console.WriteLine($"Błędny numer miejsca parkingowego.");
            }
        }
        public void ShowCars()
        {
            Console.WriteLine($"Parking {Name} ma {Cars.Length} miejsc parkingowych.");
            for(int i=0; i<Cars.Length; i++)
            {
                if (Cars[i] != null)
                {
                    Console.WriteLine($"\nMiejsce {i}");
                    Cars[i].ShowInformation();
                }
                else
                {
                    Console.WriteLine($"{i}. Miejsce jest wolne");
                }
            }
        }
    }
}
