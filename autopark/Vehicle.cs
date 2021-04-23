using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    enum Color
    {
        Blue = 1,
        White,
        Green,
        Gray,
        Yellow,
        Red
    }
    class Vehicle : IComparable<Vehicle>
    {
        public string VehicleType { get; }
        public Engine Engine { get; set; }
        public string ModelName { get;  }
        public string RegistrationNumber { get;  }
        public double WeightKg { get;  }
        public int ManufactureYear { get;  }
        public double MileageKm { get; set; }
        public Color Color { get; set; }
        public double FuelTankLOrKW { get; set; }
        public double TaxCoefficient { get; set; }

        

        public Vehicle()
        {

        }

        public Vehicle(string VehicleType, Engine Engine, string ModelName, string RegistrationNumber,
            double WeightKg, int ManufactureYear, double MileageKm, Color Color)
        {
            this.VehicleType = VehicleType;
            this.Engine = Engine;
            this.ModelName = ModelName;
            this.RegistrationNumber = RegistrationNumber;
            this.WeightKg = WeightKg;
            this.ManufactureYear = ManufactureYear;
            this.MileageKm = MileageKm;
            this.Color = Color;
            TaxCoefficient = GetTaxCoefficient(VehicleType);
        }

        private double GetTaxCoefficient(string VehicleType)
        {
            if (VehicleType == "types[0]")
                return 1.2;
            else if (VehicleType == "types[1]")
                return 1;
            else if (VehicleType == "types[2]")
                return 1.5;
            else if (VehicleType == "types[3]")
                return 1.2;
            else
                return 0;
        }
        public double GetCalcTaxPerMonth()
        {
            return WeightKg * 0.0013 + TaxCoefficient * Engine.EngineTaxCoefficient * 30 + 5;
        }

        public int CompareTo(Vehicle other)
        {
            if (GetCalcTaxPerMonth() < other.GetCalcTaxPerMonth())
                return -1;
            else if (GetCalcTaxPerMonth() > other.GetCalcTaxPerMonth())
                return 1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            Vehicle temp = obj as Vehicle;

            if (temp == null)
                throw new Exception("Impossible object to compare...");

            if (VehicleType == temp.VehicleType && ModelName == temp.ModelName)
                return true;
            else
                return false;
        }
    }
}
