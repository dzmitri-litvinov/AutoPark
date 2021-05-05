using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public class Stack
    {
        public Vehicle[] Vehicles { get; set; }

        public Stack()
        {
            Vehicles = new Vehicle[0];
        }

        public void Push(Vehicle vehicle)
        {
            Vehicle[] newVehicles = new Vehicle[Vehicles.Length + 1];

            for (int i = 0; i < Vehicles.Length; i++)
            {
                newVehicles[i] = Vehicles[i];
            }
            newVehicles[Vehicles.Length] = vehicle;
            Vehicles = newVehicles;
        }

        public Vehicle Pop()
        {
            Vehicle[] newVehicles = new Vehicle[Vehicles.Length - 1];

            for (int i = 0; i < Vehicles.Length - 1; i++)
            {
                newVehicles[i] = Vehicles[i];
            }
            Vehicle vehicle = Vehicles[Vehicles.Length - 1];
            Vehicles = newVehicles;

            return vehicle;
        }

        public int Count()
        {
            return Vehicles.Length;
        }
    }
}
