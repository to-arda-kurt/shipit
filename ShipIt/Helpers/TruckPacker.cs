using System;
using System.Collections.Generic;
using ShipIt.Models.ApiModels;



namespace ShipIt.Models.Helpers
{

    public class TruckPacker
    {

        public IEnumerable<OrderLine> OrderLines { get; set; }
        public Dictionary<string, Product> Products { get; set; }
        public List<Truck> Trucks { get; set; }
        public DateTime PackingDate { get; set; }
        public decimal LabourCost   { get; set; }
        public List<OrderLine> UnloadedItems { get; set; }

        public TruckPacker (IEnumerable<OrderLine> orderLines, Dictionary<string, Product> products )
        {
            OrderLines = orderLines;
            Trucks = new List<Truck>();
            Products = products;

            PackingDate = DateTime.Now;
            LabourCost = 0;


        }

        public List<Truck> LoadTrucks()
        {
            var errors = new List<string>();

            foreach (var orderLine in OrderLines)
            {
                if (!Products.ContainsKey(orderLine.gtin))
                {
                    errors.Add(string.Format("Unknown product gtin: {0}", orderLine.gtin));
                }
                else
                {
                    var successLoaded = LoadProductToATruck(orderLine);
                    if(!successLoaded)
                    {
                        UnloadedItems.Add(orderLine);
                        Console.WriteLine("Bring in the humans!");
                    }
                }
            }

            return Trucks;

        }

        public bool LoadProductToATruck(OrderLine orderLine)
        {

            var quantity = orderLine.quantity;
            var product = Products[orderLine.gtin];
            decimal productWeight = (decimal) product.Weight * quantity;

            if (productWeight > 2000000)
            {
                return false;
            }

            // Check if there is a truck that can take product
            foreach(Truck truck in Trucks)
            {
                if(truck.CanLoadProduct(productWeight)){
                    truck.LoadProductToTruck(orderLine, productWeight);
                    LabourCost += 10;
                    return true;
                }
            }

            // If no truck make a new one and load
            Trucks.Add(new Truck(Trucks.Count + 1));
            LabourCost += 100;
            Trucks[Trucks.Count-1].LoadProductToTruck(orderLine, productWeight);
            LabourCost += 10;
            return true;



        }


    }

}