using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _04_ConsoleApp1
{
    public interface IVehicle
    {
        /*private */void Start();   //błąd z private
        void Stop();
    }
    public interface IElectricVehicle : IVehicle
    {
        void ChargeBattery();
    }
    public abstract class Vehicle : IVehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public virtual void Start()
        {
            Console.WriteLine($"{Brand} {Model} uruchamia się");
        }
        public virtual void Stop()
        {
            Console.WriteLine($"{Brand} {Model} zatrzymuje się");
        }
    }
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string brand, string model, int numberOfDoors) : base(brand, model)
        {
            NumberOfDoors = numberOfDoors;
        }

        public virtual void Start()
        {
            Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} drzwiami uruchamia się");
        }
        public virtual void Stop()
        {
            Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} drzwiami zatrzymuje się");
        }

    }
    public class ElectricCar : Car, IElectricVehicle
    {
        public int BatteryCapacity { get; set; }

        public ElectricCar(string brand, string model, int numberOfDoors, int batteryCapacity) : base(brand, model, numberOfDoors)
        {
            BatteryCapacity = batteryCapacity;
        }

        public void ChargeBattery()
        {
            Console.WriteLine($"{Brand} {Model} z baterią o pojemności  {BatteryCapacity}kWh ładuje się");
        }
        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} z baterią o pojemności  {BatteryCapacity}kWh baterri uruchamia się");
        }
        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} z baterią o pojemności  {BatteryCapacity}kWh zatrzymuje się");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Car("Toyota", "Corolla", 4),
                new Car("Toyota", "Corolla", 4),
                new ElectricCar("Toyota", "Corolla", 4, 200),
                new ElectricCar("Toyota", "Corolla", 4, 40)
            };

            foreach(var vehicle in vehicles)
            {
                vehicle.Start();
                vehicle.Stop();

                if(vehicle is IElectricVehicle electricVehicle)
                {
                    electricVehicle.ChargeBattery();
                }
            }

            Console.ReadKey();
        }
    }
}
