﻿using Project14_1_dziedziczenie.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;



namespace Project14_1_dziedziczenie
{
    internal class Program
    {
        static void Main(string[] agrs)
        {
            Machine machine = new Machine("M-100");
            Excavator excavator = new Excavator("E-200");
            excavator.Start();
            excavator.Stop("awaria silnika");
            excavator.Work();
            //excavator.Dig();

            MachineSimulator machineSimulator = new MachineSimulator();
            machineSimulator.AddMachine(machine);
            machineSimulator.StartAll();
            machineSimulator.WorkAll();
            machineSimulator.StopAll();

            Console.ReadKey();
        }
        public void MachinesMenu(MachineSimulator machineSimulator)
        {

        }



    }
}