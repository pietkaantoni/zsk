using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _01_Zadanie_Hotel
{
    /*
     Zadanie: System Rezerwacji Hotelowych
    Cel:
    Stwórz aplikację konsolową w języku C#, która symuluje prosty system rezerwacji hotelowych. Aplikacja powinna umożliwiać dodawanie pokoi, gości oraz rezerwowanie pokoi.

    Wymagania:
    Dodawanie pokoi:

    Użytkownik powinien mieć możliwość dodania nowego pokoju do systemu.

    Każdy pokój powinien mieć numer, typ (np. jednoosobowy, dwuosobowy) oraz cenę za noc.

    Dodawanie gości:

    Użytkownik powinien mieć możliwość dodania nowego gościa do systemu.

    Każdy gość powinien mieć imię i nazwisko.

    Rezerwowanie pokoi:

    Użytkownik powinien mieć możliwość rezerwacji pokoju przez gościa.

    Po rezerwacji pokój powinien być usunięty z listy dostępnych pokoi w hotelu.

    Wyświetlanie informacji:

    Użytkownik powinien mieć możliwość wyświetlenia listy wszystkich pokoi w hotelu.

    Użytkownik powinien mieć możliwość wyświetlenia listy wszystkich gości w hotelu.

    Użytkownik powinien mieć możliwość wyświetlenia listy wszystkich zarezerwowanych pokoi.
     */
    internal class Program
    {
        public enum Type
        {
            Jednoosobowy,
            Wieloosobowy
        }
        public class Room
        {
            public int Number { get; set; }
            public Type RoomType { get; set; }
            public double CostPerNight { get; set; }
            public Room(int number, Type roomType, double Cost)
            {
                Number = number;
                RoomType = roomType;
                CostPerNight = Cost;
            } 
        }
        public class Guest
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public List<Room> RentedRooms { get; set; }
            public Guest(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }
        }
        public class Hotel
        {
            public List<Room> RoomsList;
            public List<Guest> GuestsList;
            public Hotel()
            {
                RoomsList = new List<Room>();
                GuestsList = new List<Guest>();
            }
            public void AddRoom(int number, Type roomType, double costPerNight)
            {
                RoomsList.Add(new Room(number, roomType, costPerNight));
                Console.WriteLine($"Dodano pokój {roomType} z numerem {number}, który kosztuje {costPerNight} na noc");
            }
            public void AddGuest(string name, string surname)
            {
                GuestsList.Add(new Guest(name, surname));
                Console.WriteLine($"Dodano Gościa {name} {surname} do listy gości hotelowych");
            }
            public void RentdRoom(Guest guest, Room room)
            {
                
            }
        }



        static void Main(string[] args)
        {
        }
    }
}
