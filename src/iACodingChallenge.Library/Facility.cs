using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iACodingChallenge.Library
{
    public class Facility
    {
        public string Name { get; }
        public uint Identifier { get; }
        public string Medication { get; }
        public decimal Cost { get; }

        public Facility(uint identifier, string medication, decimal cost)
        {
            Identifier = identifier;
            Name = $"Central Fill {identifier:000}";
            Medication = medication;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"{Name} - ${Cost:00.00}, {Medication}";
        }
    }
}
