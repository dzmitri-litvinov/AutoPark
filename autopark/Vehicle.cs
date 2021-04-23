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
        public string ModelName { get;  }
        public string RegistrationNumber { get;  }
        public double WeightKg { get;  }
        public int ManufactureYear { get;  }
        public double MileageKm { get; set; }
        public Color Color { get; set; }
        public double FuelTankLOrKW { get; set; }
        public float TaxCoefficient { get; set; }


        public Vehicle()
        {

        }

        public Vehicle(string VehicleType, string ModelName, string RegistrationNumber,
            double WeightKg, int ManufactureYear, double MileageKm, Color Color)
        {
            this.VehicleType = VehicleType;
            this.ModelName = ModelName;
            this.RegistrationNumber = RegistrationNumber;
            this.WeightKg = WeightKg;
            this.ManufactureYear = ManufactureYear;
            this.MileageKm = MileageKm;
            this.Color = Color;

            if (VehicleType == "types[0]")
                TaxCoefficient = 1.2F;
            else if (VehicleType == "types[1]")
                TaxCoefficient = 1F;
            else if (VehicleType == "types[2]")
                TaxCoefficient = 1.5F;
            else if (VehicleType == "types[3]")
                TaxCoefficient = 1.2F;
        }

        public double GetCalcTaxPerMonth()
        {
            return WeightKg * 0.0013 + TaxCoefficient * 30 + 5;
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
    }
}
