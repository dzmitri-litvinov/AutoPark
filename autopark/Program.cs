using System;

namespace autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4, i;
            VehicleType[] vehicles = new VehicleType[n];
            float maxTaxCoef = 0, sumTaxCoef = 0, averTaxCoef;

            vehicles[0] = new VehicleType("Bus", 1.2F);
            vehicles[1] = new VehicleType("Car", 1F);
            vehicles[2] = new VehicleType("Rink", 1.5F);
            vehicles[3] = new VehicleType("Tractor", 1.2F);

           /* for (i = 0; i < n; i++) 
                vehicles[i].Display();
            
            vehicles[3].TaxCoefficient = 1.3F;
            
            for (i = 0; i < n; i++)
                if (vehicles[i].TaxCoefficient > maxTaxCoef)
                    maxTaxCoef = vehicles[i].TaxCoefficient;

            Console.WriteLine($"Max tax coefficient is {maxTaxCoef}");

            for (i = 0; i < n; i++)
                sumTaxCoef += vehicles[i].TaxCoefficient;

            averTaxCoef = sumTaxCoef / n;
            Console.WriteLine($"Average tax coefficient is {averTaxCoef}");*/


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
