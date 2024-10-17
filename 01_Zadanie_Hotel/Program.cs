using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static _01_Zadanie_Hotel.Program;

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
            public Room(int number, Type roomType, double cost)
            {
                Number = number;
                RoomType = roomType;
                CostPerNight = cost;
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
                Console.WriteLine($"Dodano pokój {roomType} z numerem {number}, który kosztuje {costPerNight} zł na noc.\n");
            }
            public void AddGuest(string name, string surname)
            {
                GuestsList.Add(new Guest(name, surname));
                Console.WriteLine($"Dodano Gościa {surname} {name} do listy gości hotelowych.\n");
            }
            public void RentdRoom(Guest guest, Room room)
            {
                guest.RentedRooms.Add(room);
                RoomsList.Remove(room);
                Console.WriteLine($"{guest.Surname} {guest.Name} wypożyczył pokój {room.RoomType} nr {room.Number}, który kosztuje {room.CostPerNight} zł za noc.\n");
            }
            public void ViewGuests()
            {
                Console.WriteLine("Goście hotelowi: ");
                for (int i = 0; i < GuestsList.Count(); i++)
                {
                    Console.WriteLine($"{i+1}. {GuestsList[i].Surname} {GuestsList[i].Name}");
                }
            }
            public void ViewRooms()
            {
                Console.WriteLine("Wolne pokoje hotelowe: ");
                for (int i = 0; i < RoomsList.Count(); i++)
                {
                    Console.WriteLine($"{i+1}. {RoomsList[i].RoomType}, nr {RoomsList[i].Number}, {RoomsList[i].CostPerNight} zł za noc");
                }
            }
            public void ViewRentedRooms()
            {
                Console.WriteLine("Wypożyczone pokoje:");
                for (int i = 0; i < GuestsList.Count(); i++)
                {
                    Console.WriteLine($"\tPrzez {GuestsList[i].Surname} {GuestsList[i].Name}:");
                    for(int j = 0; j < GuestsList[i].RentedRooms.Count(); j++)
                    {
                        Console.WriteLine($"\t\tPokój {GuestsList[i].RentedRooms[j].RoomType} nr {GuestsList[i].RentedRooms[j].Number}, który kosztował {GuestsList[i].RentedRooms[j].CostPerNight} zł za noc");
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            hotel.AddRoom(1, Type.Jednoosobowy, 990.50);
            hotel.ViewRooms();
            Console.ReadKey();
        }
    }
}