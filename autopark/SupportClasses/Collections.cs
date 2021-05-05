using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


namespace autopark
{
    public class Collections
    {
        public List<VehicleType> VehicleTypes { get; set; } = new();
        public List<Vehicle> Vehicle { get; set; } = new();
        public List<Rent> rents = new List<Rent>();

        public Collections(string typeFile, string vehiclesFile, string rentsFile)
        {
            LoadRents(rentsFile);
            VehicleTypes = LoadTypes(typeFile);
            Vehicle = LoadVehicles(vehiclesFile);
        }

        public List<VehicleType> LoadTypes(string inFile)
        {
            List<VehicleType> vehicleTypes = new List<VehicleType>();

            if (File.Exists(inFile))
            {
                string[] lines = File.ReadAllLines(inFile);
                foreach (string s in lines)
                {
                    vehicleTypes.Add(CreateType(s));
                }
            }
            else
            {
                Console.WriteLine("File does not exist...");
            }

            return vehicleTypes;
        }

        public VehicleType CreateType(string csvString)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            VehicleType vehicleType = new VehicleType();
            string[] data = csvString.Split(',');

            vehicleType.Id = int.Parse(data[0]);
            vehicleType.TypeName = data[1];
            vehicleType.TaxCoefficient = float.Parse(data[2], numberFormatInfo);

            return vehicleType;
        }

        public List<Vehicle> LoadVehicles(string inFile)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            if (File.Exists(inFile))
            {
                string[] lines = File.ReadAllLines(inFile);
                foreach (string s in lines)
                {
                    vehicles.Add(CreateVehicle(s));
                }
            }
            else
            {
                Console.WriteLine("File does not exist...");
            }

            return vehicles;
        }
           
        public Vehicle CreateVehicle(string csvString)
        {
            NumberFormatInfo nFI = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            string[] data = csvString.Split(',');
            VehicleType vehicleType = null;
            AbstractEngine engine = null;

            foreach (VehicleType type in VehicleTypes)
            {
                if (type.Id == int.Parse(data[1]))
                {
                    vehicleType = type;
                }
            }

            switch (data[8])
            {
                case "Gasoline":
                    engine = new GasolineEngine(double.Parse(data[9], nFI), double.Parse(data[10], nFI));
                    break;
                case "Diesel":
                    engine = new DiedelEngine(double.Parse(data[9], nFI), double.Parse(data[10], nFI));
                    break;
                case "Electrical":
                    engine = new ElectricalEngine(double.Parse(data[10], nFI));
                    break;
                default:
                    break;
            }

            Vehicle vehicle = new Vehicle(vehicleType, engine, data[2], data[3],
                double.Parse(data[4], nFI), int.Parse(data[5], nFI), double.Parse(data[6], nFI),
                Enum.Parse<Color>(data[7]), double.Parse(data[11], nFI));
            vehicle.Id = int.Parse(data[0]);

            foreach (Rent r in rents)
            {
                if (vehicle.Id == r.Id)
                {
                    vehicle.Rents.Add(r);
                }
            }

            return vehicle;            
        }

        public void LoadRents(string inFile)
        {
            if (File.Exists(inFile))
            {
                NumberFormatInfo nFI = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                string[] lines = File.ReadAllLines(inFile);
                foreach (string s in lines)
                {
                    string[] data = s.Split(',');
                    rents.Add(new Rent(int.Parse(data[0]), DateTime.Parse(data[1]), double.Parse(data[2], nFI)));
                }
            }
            else
            {
                Console.WriteLine("File does not exist...");
            }
        }

        public void Insert(int index, Vehicle v)
        {
            if (index > Vehicle.Count)
            {
                Vehicle.Add(v);
            }
            else 
            {
                Vehicle.Insert(index, v);
            }
        }

        public int Delete(int index)
        {
            if (index > Vehicle.Count)
            {
                return -1;
            }
            else 
            {
                Vehicle.RemoveAt(index);
                return index;
            }
        }

        public double SumTotalProfit()
        {
            double sum = 0;

            foreach (Vehicle v in Vehicle)
            {
                sum += v.GetTotalProfit();
            }

            return sum;
        }

        public void Print()
        {
            Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                " Id", " Type", " ModelName", " Number", " Weight (kg)", " Year", " Mileage", " Color", " Income", " Tax", " Profit");

            foreach (Vehicle v in Vehicle)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                    v.Id,
                    v.VehicleType.TypeName,
                    v.ModelName,
                    v.RegistrationNumber,
                    v.WeightKg,
                    v.ManufactureYear,
                    v.MileageKm,
                    v.Color,
                    v.GetTotalIncome().ToString("0.00"),
                    v.GetCalcTaxPerMonth().ToString("0.00"),
                    v.GetTotalProfit().ToString("0.00"));
            }

            Console.WriteLine($"{"Total",-5}{"",-10}{"",-25}{"",-15}{"",-15}{"",-10}{"",-10}{"",-10}{"",-10}{"",-10}{SumTotalProfit().ToString("0.00"),-10}");
        }

        public void Sort(IComparer<Vehicle> comparator)
        {
            Vehicle.Sort(comparator);
        }
    }
}
