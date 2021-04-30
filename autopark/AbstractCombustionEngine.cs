using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        public double EngineCapacity { get; set; }
        public double FuelConsumptionPer100 { get; set; }
        public AbstractCombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient)
        { }

        public override double GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}
