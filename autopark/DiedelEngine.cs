using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    class DiedelEngine : AbstractCombustionEngine
    {
        public DiedelEngine(double engineCapacity, double fuelConsumptionPer100)
            : base ("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }

    }
}
