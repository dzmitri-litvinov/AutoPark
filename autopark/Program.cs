using System;

namespace autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, lowestMiliage = 0, highestMiliage = 0;
            Vehicle[] vehicles = new Vehicle[]
            {
                 new Vehicle("types[0]","VW Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
                 new Vehicle("types[0]","VW Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White),
                 new Vehicle("types[0]","Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
                 new Vehicle("types[1]","Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray),
                 new Vehicle("types[1]","Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, Color.White),
                 new Vehicle("types[2]","Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
                 new Vehicle("types[2]","МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red)
            };

            n = vehicles.Length;

            for (i = 0; i < n; i++)
                Console.WriteLine(PrintVehicle.ToString(vehicles[i]));

            Array.Sort(vehicles);

            Console.WriteLine();
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

        }
    }
}
