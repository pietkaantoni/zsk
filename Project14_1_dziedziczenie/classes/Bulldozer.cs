using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project14_1_dziedziczenie.classes 
{
    internal class Bulldozer : Machine
    {
        public Bulldozer(string name) : base(name)
        {
        }

        public override void Start()
        {
            base.Start();
            Console.WriteLine($"{Name} rozpoczyna równanie terenu");
        }

        //symulacja równania terenu
        public void Flatten()
        {
            Console.WriteLine($"{Name} równa teren");
        }

        //przesłonięcie metody Work
        public override void Work()
        {
            Flatten();
        }

    }
}