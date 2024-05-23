using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project14_1_dziedziczenie.classes 
{
    internal class Loader : Machine
    {
        public Loader(string name) : base(name)
        {
        }

        //przesłonięcie metody wirtualnej
        public override void Start()
        {
            base.Start();
            Console.WriteLine($"{Name} rozpoczyna ładowanie materiału");
        }

        public void Stop(string reason)
        {
            Console.WriteLine($"{Name} została zatrzymana z powodu: {reason}");
        }

        //symulacja kopania
        public void Load()
        {
            Console.WriteLine($"{Name} ładuje materiał");
        }

        //przesłonięcie metody Work
        public override void Work()
        {
            Load();
        }

    }
}