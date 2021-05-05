using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public class Queue
    {
        public Vehicle[] Vehicles { get; set; }

        public Queue()
        {
            Vehicles = new Vehicle[0];
        }

        public void Enqueue(Vehicle vehicle)
        {
            Vehicle[] newVehicles = new Vehicle[Vehicles.Length + 1];

            for (int i = 0; i < Vehicles.Length; i++)
            {
                newVehicles[i] = Vehicles[i];
            }
            newVehicles[Vehicles.Length] = vehicle;
            Vehicles = newVehicles;
        }

        public Vehicle Dequeue()
        {
            Vehicle[] newVehicles = new Vehicle[Vehicles.Length - 1];

            for (int i = 1; i < Vehicles.Length; i++)
            {
                newVehicles[i - 1] = Vehicles[i];
            }
            Vehicle vehicle = Vehicles[0];
            Vehicles = newVehicles;

            return vehicle;
        }

        public int Count()
        {
            return Vehicles.Length;
        }
    }
}
