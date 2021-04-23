using System;

namespace autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, j, lowestMiliage = 0, highestMiliage = 0;
            Vehicle[] vehicles = new Vehicle[]
            {
                 new Vehicle("types[0]", new GasolineEngine(2, 8.1),"VW Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
                 new Vehicle("types[0]", new GasolineEngine(2, 8.5),"VW Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White),
                 new Vehicle("types[0]", new ElectricalEngine(50),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
                 new Vehicle("types[1]", new DiedelEngine(1.6, 7.2),"Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray),
                 new Vehicle("types[1]", new ElectricalEngine(25),"Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, Color.White),
                 new Vehicle("types[2]", new DiedelEngine(3.2, 25),"Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
                 new Vehicle("types[2]", new DiedelEngine(4.75, 20.1), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red)
            };

            n = vehicles.Length;

            Console.WriteLine("Initial array:");
            for (i = 0; i < n; i++)
                Console.WriteLine(PrintVehicle.ToString(vehicles[i]));

            Array.Sort(vehicles);

            Console.WriteLine("\nSorted array:");
            for (i = 0; i < n; i++)
                Console.WriteLine(PrintVehicle.ToString(vehicles[i]));

            for (i = 0; i < n; i++)
            {
                if (vehicles[lowestMiliage].MileageKm > vehicles[i].MileageKm)
                    lowestMiliage = i;

                if (vehicles[highestMiliage].MileageKm < vehicles[i].MileageKm)
                    highestMiliage = i;
            }

            Console.WriteLine();
            Console.WriteLine("Vehicle with the lowest miliage:");
            Console.WriteLine(PrintVehicle.ToString(vehicles[lowestMiliage]));
            Console.WriteLine("Vehicle with the highest miliage:");
            Console.WriteLine(PrintVehicle.ToString(vehicles[highestMiliage]));


            Console.WriteLine("\nEqual vehicles are:");
            bool[] isToPrint = new bool[n];
            for (i = 0; i < n; i++)
                isToPrint[i] = false;

            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (vehicles[i].Equals(vehicles[j]))
                    {
                        isToPrint[i] = true;
                        isToPrint[j] = true;
                    }
                }
            }

            for (i = 0; i < n; i++)
                if(isToPrint[i])
                    Console.WriteLine(PrintVehicle.ToString(vehicles[i]));
        }
    }
}
