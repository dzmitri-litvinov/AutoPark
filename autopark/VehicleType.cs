using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    class VehicleType
    {
        string typeName;
        float taxCoefficient; //or float taxCoefficient { get; set; }

        public float TaxCoefficient
        {
            get { return taxCoefficient; }
            set { taxCoefficient = value; }
        }

        public VehicleType(string typeName, float taxCoefficient)
        {
            this.typeName = typeName;
            this.taxCoefficient = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine($"TypeName = {typeName}");
            Console.WriteLine($"TaxCoefficient = {taxCoefficient}");
        }

        public override string ToString()
        {
            return $"{typeName} {taxCoefficient}";
        }

        public void ChangeTaxCoef(float n)
        {
            taxCoefficient = n;
        }
    }
}
