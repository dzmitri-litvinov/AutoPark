﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    class VehicleType
    {
        public string TypeName { get; set; }
        public float TaxCoefficient { get; set; }       

        public VehicleType(string typeName)
        {
            this.TypeName = typeName;
            this.TaxCoefficient = GetTaxCoefficient(typeName);
        }

        public void Display()
        {
            Console.WriteLine($"TypeName = {TypeName}");
            Console.WriteLine($"TaxCoefficient = {TaxCoefficient}");
        }

        public override string ToString()
        {
            return $"{TypeName}";
        }
        private float GetTaxCoefficient(string typeName)
        {
            switch (typeName)
            {
                case "types[0]":
                     return 1.2F;
                case "types[1]":
                     return 1F;
                case "types[2]":
                     return 1.5F;
                case "types[3]":
                     return 1.2F;
                default:
                     return 0;
            }
        }
    }
}
