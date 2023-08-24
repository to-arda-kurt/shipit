using System.Collections.Generic;

using ShipIt.Models.ApiModels;

namespace ShipIt.Models.Helpers
{

    public class Truck
    {
        const decimal MAX_WEIGHT = 2000000;
        public int Id { get; set; }
        public List<OrderLine> Cargo {get; set;}

        public decimal Weight { get; set;}

        public Truck(int id)
        {
            Id = id;
            Cargo = new List<OrderLine>();
            Weight = 0;
        }

        public bool CanLoadProduct(decimal productWeight)
        {
            decimal newWeight = Weight + productWeight;
            return newWeight <= MAX_WEIGHT;
        }

        public void LoadProductToTruck(OrderLine orderline, decimal productWeight)
        {
            Cargo.Add(orderline);
            Weight += productWeight;
        }



    }
}