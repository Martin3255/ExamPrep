using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Capacity = capacity;
            Model = model;
            MultyProcessor = new List<CPU>();
        }

        public List<CPU> MultyProcessor { get; set; }

        public int Capacity { get; set; }
        public string Model { get; set; }
        public int Count { get { return MultyProcessor.Count; } }


        public void Add(CPU cpu)
        {
            if (MultyProcessor.Count < Capacity)
            {
                MultyProcessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            for (int i = 0; i < MultyProcessor.Count; i++)
            {
                if (MultyProcessor[i].Brand == brand)
                {
                    MultyProcessor.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public CPU MostPowerfull()
        {
            CPU mostPowerful = MultyProcessor[0];
            foreach (var cpu in MultyProcessor)
            {
                if (cpu.Frequency > mostPowerful.Frequency)
                {
                    mostPowerful = cpu;
                }
            }
            return mostPowerful;
        }
        public CPU GetCpu(string brand)
        {
            return MultyProcessor.FirstOrDefault(c => c.Brand == brand);
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in MultyProcessor)
            {
                result.AppendLine(cpu.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
