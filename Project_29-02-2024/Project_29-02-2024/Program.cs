using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _11_2_parking.classes;

namespace _11_2_parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car { Brand = "Fiat", Model = "126p", Year = 1980, Color = Color.czerwony };
            Car c2 = new Car { Brand = "Ferrari", Model = "F430", Year = 2023, Color = Color.niebieski };
            Car c3 = new Car { Brand = "BMW", Model = "M3", Year = 2020, Color = Color.zielony };

            Parking parking1 = new Parking { Name = "center", Cars = new Car[5] };
            parking1.AddCar(c1);
            parking1.AddCar(c3);
            parking1.ShowCars();

            parking1.RemoveCar(0);
            parking1.ShowCars();




            Console.ReadKey();
        }
    }
}
/*
 * Codeshare logo
 ShareSign UpLog In
Zadanie 1: Napisz program, który symuluje działanie parkingu samochodowego.

1
Zadanie 1: Napisz program, który symuluje działanie parkingu samochodowego.
2
 Utwórz typ wyliczenia, który symuluje działanie parkingu samochodowego
3
 Utwórz klasę Car, która reprezentuje samochód. Klasa ta powinna mieć następujące właściwości tylko
4
do odczytu: Brand (marka), Model (model), Year (rok produkcji), Color (kolor). Klasa ta powinna
5
mieć również metodę ShowInformation, która wyświetla informacje o samochodzie na konsoli w
6
formacie: To jest {Brand} {Model} z {Year}, kolor: {Color}.
7
 Utwórz klasę Parking, która reprezentuje parking samochodowy. Klasa ta powinna mieć następujące
8
właściwości: Name (nazwa parkingu), Cars (tablica samochodów, które znajdują się na parkingu). Klasa
9
ta powinna mieć również następujące metody: AddCar, która dodaje samochód do pierwszego
10
wolnego miejsca na parkingu (lub wyświetla komunikat, że nie ma wolnych miejsc), RemoveCar, która
11
usuwa samochód z podanego indeksu miejsca na parkingu (lub wyświetla komunikat, że podany
12
indeks jest nieprawidłowy lub miejsce jest puste), ShowCars, która wyświetla informacje o wszystkich
13
samochodach na parkingu (lub informuje, że miejsce jest wolne).
14
 Utwórz obiekty typu Car dla trzech różnych samochodów, używając inicjalizatorów obiektów.
15
 Utwórz obiekt typu Parking dla parkingu o nazwie Center i pięciu miejscach, używając inicjalizatora
16
obiektów.
17
 Dodaj trzy samochody do parkingu, używając metody AddCar.
18
 Wyświetl informacje o wszystkich samochodach na parkingu, używając metody ShowCars.
19
 Usuń samochód z drugiego miejsca na parkingu, używając metody RemoveCar.
20
 Wyświetl informacje o wszystkich samochodach na parkingu po usunięciu, używając
21
metody ShowCars.
*/