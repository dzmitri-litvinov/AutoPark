using System;
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

        public VehicleType(string typeName, float taxCoefficient)
        {
            this.TypeName = typeName;
            this.TaxCoefficient = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine($"TypeName = {TypeName}");
            Console.WriteLine($"TaxCoefficient = {TaxCoefficient}");
        }

        public override string ToString()
        {
            return $"{TypeName} {TaxCoefficient}";
        }
    }
}
