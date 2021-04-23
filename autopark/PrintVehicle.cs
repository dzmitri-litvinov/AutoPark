using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    static class PrintVehicle
    {
        public static string ToString(Vehicle obj)
        {
            return $"{obj.VehicleType} {obj.ModelName} {obj.RegistrationNumber} {obj.WeightKg} {obj.ManufactureYear} {obj.MileageKm} {obj.Color} {obj.GetCalcTaxPerMonth().ToString("0.00")}";
        }
    }
}
