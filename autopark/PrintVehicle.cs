using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    static class PrintVehicle
    {
        public static string ToString(Vehicle[] obj)
        {
            StringBuilder strBld = new StringBuilder();

            for (int i = 0; i < obj.Length; i++)
            {
                strBld.Append($"{obj[i].VehicleType} {obj[i].ModelName} " +
                    $"{obj[i].RegistrationNumber} {obj[i].WeightKg} " +
                    $"{obj[i].ManufactureYear} {obj[i].MileageKm} " +
                    $"{obj[i].Color} {obj[i].GetCalcTaxPerMonth().ToString("0.00")}\n");
            }

            return strBld.ToString();
        }
    }
}
