using System.Collections.Generic;

using ShipIt.Models.ApiModels;

namespace ShipIt.Models.Helpers
{

    public class CargoLine
    {
        const decimal MAX_WEIGHT = 2000000;
        public string Gtin { get; set; }
        public decimal Weight { get; set; }

        public CargoLine(string gtin, decimal weight)
        {
            Gtin = gtin;
            Weight = weight;
        }

    }
}