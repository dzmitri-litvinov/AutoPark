using System;

namespace autopark
{
    class Program
    {
        public static void Main(string[] args)
        {

            int n, i, j, lowestMiliage = 0, highestMiliage = 0;
            Vehicle[] vehicles = new Vehicle[]
            {
                 new Vehicle(new VehicleType("types[0]", 1.2F), new GasolineEngine(2, 8.1), "VW Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue, 75),
                 new Vehicle(new VehicleType("types[0]", 1.2F), new GasolineEngine(2, 8.5), "VW Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White, 75),
                 new Vehicle(new VehicleType("types[0]", 1.2F), new ElectricalEngine(50), "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green, 150),
                 new Vehicle(new VehicleType("types[1]", 1F), new DiedelEngine(1.6, 7.2), "Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray, 55),
                 new Vehicle(new VehicleType("types[1]", 1F), new ElectricalEngine(25), "Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, Color.White, 70),
                 new Vehicle(new VehicleType("types[2]", 1.5F), new DiedelEngine(3.2, 25), "Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow, 20),
                 new Vehicle(new VehicleType("types[3]", 1.2F), new DiedelEngine(4.75, 20.1), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red, 135)
            };

            n = vehicles.Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine(PrintVehicle.ToString(vehicles));

            Array.Sort(vehicles);

            Console.WriteLine("\nSorted array:");
            Console.WriteLine(PrintVehicle.ToString(vehicles));

            for (i = 0; i < n; i++)
            {
                if (vehicles[lowestMiliage].MileageKm > vehicles[i].MileageKm)
                {
                    lowestMiliage = i;
                }

                if (vehicles[highestMiliage].MileageKm < vehicles[i].MileageKm)
                {
                    highestMiliage = i;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Vehicle with the lowest miliage:");
            Console.WriteLine(vehicles[lowestMiliage].ToString());
            Console.WriteLine("Vehicle with the highest miliage:");
            Console.WriteLine(vehicles[highestMiliage].ToString());


            Console.WriteLine("\nEqual vehicles are:");
            bool[] isToPrint = new bool[n];

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
            {
                if (isToPrint[i])
                {
                    Console.WriteLine(vehicles[i].ToString());
                }
            }

            Console.WriteLine("\nVehicle with the max kilometers");
            double maxKilometers = 0;
            int vehicleWithMaxKolometers = 0;
            for (i = 0; i < n; i++)
            {
                if (vehicles[i].Engine.GetMaxKilometers(vehicles[i].FuelTankOrBattery) > maxKilometers)
                {
                    maxKilometers = vehicles[i].Engine.GetMaxKilometers(vehicles[i].FuelTankOrBattery);
                    vehicleWithMaxKolometers = i;
                }
            }

            Console.WriteLine(vehicles[vehicleWithMaxKolometers]);

            /*////////////
            ///Level 05///
            ////////////*/

            Collections coll = new Collections(@"D:\DevInc\autopark\GitHub\AutoPark\autopark\Data\types.csv",
                @"D:\DevInc\autopark\GitHub\AutoPark\autopark\Data\vehicles.csv",
                @"D:\DevInc\autopark\GitHub\AutoPark\autopark\Data\rents.csv");

            foreach (var v in coll.Vehicle)
            {
                Console.WriteLine(v);
            }

            
        }
    }
}

