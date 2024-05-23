using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Zdefiniuj klasę MachineSimulator.
Dodaj prywatne pole typu List<Machine>, które będzie przechowywać obiekty maszyn.
Zaimplementuj metodę AddMachine, która przyjmuje jeden argument typu Machine i dodaje go do listy maszyn.
Zaimplementuj metodę StartAll, która iteruje przez listę maszyn i wywołuje metodę Start na każdym obiekcie.
Zaimplementuj metodę WorkAll, która iteruje przez listę maszyn i wywołuje metodę Work na każdym obiekcie.
Zaimplementuj metodę StopAll, która iteruje przez listę maszyn i wywołuje metodę Stop na każdym obiekcie.
Upewnij się, że wszystkie metody są publiczne i nie zwracają żadnych wartości (typ void).

Dodatkowe informacje:

Klasa Machine powinna być już zdefiniowana z metodami Start, Work i Stop.
Metody te mogą być wirtualne lub abstrakcyjne, w zależności od wymagań dotyczących projektu klasy Machine.

Wskazówki:


Rozważ użycie pętli foreach do iteracji przez listę maszyn.
Zastanów się nad obsługą wyjątków, które mogą wystąpić podczas wykonywania metod maszyn.
*/
namespace Project14_1_dziedziczenie.classes 
{
    internal class MachineSimulator
    {
        private List<Machine> Machines { get; set; }

        public void AddMachine(Machine machine)
        {
            Machines.Add(machine);
        }
        public void StartAll()
        {
            foreach(Machine machine in Machines)
            {
                machine.Start();
            }
        }
        public void WorkAll()
        {
            foreach(Machine machine in Machines)
            {
                machine.Work();
            }
        }
        public void StopAll()
        {
            foreach(Machine machine in Machines)
            {
                machine.Stop();
            }
        }

    }
}