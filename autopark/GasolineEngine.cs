using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public class GasolineEngine : CombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100)
            : base ("Gasoline", 1)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
