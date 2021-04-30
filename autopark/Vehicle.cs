using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public class Vehicle : IComparable<Vehicle>
    {
        private const double TaxWeightCoeff = 0.0013;
        public int Id { get; set; }
        public List<Rent> Rents { get; set; }
        public VehicleType VehicleType { get; set; }
        public AbstractEngine Engine { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public double WeightKg { get; set; }
        public int ManufactureYear { get; set; }
        public double MileageKm { get; set; }
        public Color Color { get; set; }
        public double FuelTankOrBattery { get; set; }
        
        public Vehicle()
        {

        }

        public Vehicle(VehicleType VehicleType, AbstractEngine Engine, string ModelName, string RegistrationNumber,
            double WeightKg, int ManufactureYear, double MileageKm, Color Color, double FuelTankOrBattery)
        {
            this.VehicleType = VehicleType;
            this.Engine = Engine;
            this.ModelName = ModelName;
            this.RegistrationNumber = RegistrationNumber;
            this.WeightKg = WeightKg;
            this.ManufactureYear = ManufactureYear;
            this.MileageKm = MileageKm;
            this.Color = Color;
            this.FuelTankOrBattery = FuelTankOrBattery;
        }
        
        public double GetCalcTaxPerMonth()
        {
            return WeightKg * TaxWeightCoeff + VehicleType.TaxCoefficient * Engine.EngineTaxCoefficient * 30 + 5;
        }

        public double GetTotalIncome()
        {
            return Rents.Sum(rent => rent.RentPrice);
        }

        public double GetTotalProfit()
        {
            return GetTotalIncome() - GetCalcTaxPerMonth();
        }

        public int CompareTo(Vehicle other)
        {
            return GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
        }

        public override bool Equals(object obj)
        {
            Vehicle temp = obj as Vehicle;

            if (temp == null)
                return false;

            return VehicleType.TypeName == temp.VehicleType.TypeName && ModelName == temp.ModelName;
        }
        public override string ToString()
        {
            return $"{VehicleType} {ModelName} " +
                    $"{RegistrationNumber} {WeightKg} " +
                    $"{ManufactureYear} {MileageKm} " +
                    $"{Color} {GetCalcTaxPerMonth().ToString("0.00")}";
        }
    }
}
