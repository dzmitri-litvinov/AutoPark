using System;

namespace autopark
{
    class Program
    {
        public static void Main(string[] args)
        {
            int scrWidth = 140;
            Console.WindowWidth = scrWidth;
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

            Console.WriteLine("////////////\n" +
                              "//Level 05//\n" +
                              "////////////");

            Console.WriteLine(new string('*', scrWidth) + '\n');
            Console.WriteLine("Initial collection from file:");

            Collections VehiclesCollection = new Collections(@"types.csv", @"vehicles.csv", @"rents.csv");
                        
            VehiclesCollection.Print();

            Console.WriteLine(new string('*', scrWidth) + '\n');
            Console.WriteLine("Add one vehicle and delete 1st and 4th one by one:");

            Vehicle zaz = new Vehicle(new VehicleType("Car", 1.2F), new GasolineEngine(2, 8.5), "ZAZ-8", "1234 AA-7", 1100, 1978, 125000, Color.White, 60);
            zaz.Id = VehiclesCollection.Vehicle.Count + 1;

            VehiclesCollection.Insert(VehiclesCollection.Vehicle.Count, zaz);

            VehiclesCollection.Delete(1);
            VehiclesCollection.Delete(4);
           
            VehiclesCollection.Print();

            Console.WriteLine(new string('*', scrWidth) + '\n');
            Console.WriteLine("Sort collection:");

            VehiclesCollection.Sort(new VehicleNameComparer());
                        
            VehiclesCollection.Print();

            Console.WriteLine("////////////\n" +
                              "//Level 06//\n" +
                              "////////////");

            Queue VehicleQueue = new Queue();

            foreach (Vehicle v in VehiclesCollection.Vehicle)
            {
                VehicleQueue.Enqueue(v);
            }

            while (VehicleQueue.Count() > 0)
            {
                Console.WriteLine("Washed vehicle is: {0}", VehicleQueue.Dequeue());
            }

            Console.WriteLine("////////////\n" +
                              "//Level 07//\n" +
                              "////////////");

            Stack VehicleStack = new Stack();

            foreach (Vehicle v in VehiclesCollection.Vehicle)
            {
                Console.WriteLine("Vehicle entered the garage: {0}", v);
                VehicleStack.Push(v);
            }

            Console.WriteLine();
            while (VehicleStack.Count() > 0)
            {
                Console.WriteLine("Vehicle leaved the garage: {0}", VehicleStack.Pop());
            }
        }
    }
}

