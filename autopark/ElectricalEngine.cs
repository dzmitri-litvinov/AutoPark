using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption)
            : base ("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public override double GetMaxKilometers(double batterySize)
        {
            return batterySize / ElectricityConsumption;
        }
    }
}
