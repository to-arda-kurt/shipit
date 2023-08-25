using System.Collections.Generic;

using ShipIt.Models.ApiModels;

namespace ShipIt.Models.Helpers
{

    public class Truck
    {
        const decimal MAX_WEIGHT = 2000000;
        public int Id { get; set; }
        public List<CargoLine> CargoLines {get; set;}
        public decimal Weight { get; set;}

        public Truck(int id)
        {
            Id = id;
            CargoLines = new List<CargoLine>();
            Weight = 0;
        }

        public bool CanLoadProduct(decimal productWeight)
        {
            decimal newWeight = Weight + productWeight;
            return newWeight <= MAX_WEIGHT;
        }

        public void LoadProductToTruck(CargoLine cargoLine)
        {
            CargoLines.Add(cargoLine);
            Weight += cargoLine.Weight;
        }



    }
}