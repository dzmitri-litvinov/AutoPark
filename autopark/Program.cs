using System;

namespace autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i;
            VehicleType[] vehicles = new VehicleType[]
            {
                 new VehicleType("Bus", 1.2F),
                 new VehicleType("Car", 1F),
                 new VehicleType("Rink", 1.5F),
                 new VehicleType("Tractor", 1.2F)
            };
            float maxTaxCoef = 0, sumTaxCoef = 0, averTaxCoef;

            n = vehicles.Length;
            for (i = 0; i < n; i++) {
                if (i == n - 1)
                    vehicles[i].TaxCoefficient = 1.3F;

                vehicles[i].Display();

                if (vehicles[i].TaxCoefficient > maxTaxCoef)
                    maxTaxCoef = vehicles[i].TaxCoefficient;

                sumTaxCoef += vehicles[i].TaxCoefficient;
            }

            Console.WriteLine($"Max tax coefficient is {maxTaxCoef}");

            averTaxCoef = sumTaxCoef / n;
            Console.WriteLine($"Average tax coefficient is {averTaxCoef}");
        }
    }
}
