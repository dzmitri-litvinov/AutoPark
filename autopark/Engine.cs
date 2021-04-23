using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    class Engine
    {
        public string EngineType { get; set; }
        public double EngineTaxCoefficient { get; set; }

        public Engine(string engineType, double engineTaxCoefficient)
        {
            EngineType = engineType;
            EngineTaxCoefficient = engineTaxCoefficient;
        }
    }
}
