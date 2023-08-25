using System;
using System.Collections.Generic;
using ShipIt.Models.ApiModels;



namespace ShipIt.Models.Helpers
{

    public class TruckPacker
    {
        const decimal MAX_WEIGHT = 2000000;
        public IEnumerable<OrderLine> OrderLines { get; set; }
        public Dictionary<string, Product> Products { get; set; }
        public List<Truck> Trucks { get; set; }
        public DateTime PackingDate { get; set; }
        public decimal LabourCost { get; set; }
        public List<CargoLine> UnloadedItems { get; set; }

        public int TruckQuantity { get; set; }


        public TruckPacker(IEnumerable<OrderLine> orderLines, Dictionary<string, Product> products)
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

            List<CargoLine> cargoLines = SplitAndSortOrder();

            foreach (var cargoline in cargoLines)
            {

                var successLoaded = LoadProductToATruck(cargoline);
                if (!successLoaded)
                {
                    UnloadedItems.Add(cargoline);
                    Console.WriteLine("Bring in the humans!");
                }

            }

            return Trucks;

        }

        public bool LoadProductToATruck(CargoLine cargoLine)
        {

            // Check if there is a truck that can take product
            foreach (Truck truck in Trucks)
            {

                if (truck.CanLoadProduct(cargoLine.Weight)) //true
                {
                    truck.LoadProductToTruck(cargoLine); //true
                    LabourCost += 10;
                    SortTrucks();
                    return true;
                }

            }

            // if false
            // If no truck make a new one and load
            Trucks.Add(new Truck(Trucks.Count + 1));
            TruckQuantity += 1;
            LabourCost += 100;
            Trucks[Trucks.Count - 1].LoadProductToTruck(cargoLine);
            SortTrucks();
            LabourCost += 10;

            return true;

        }

        public List<CargoLine> SplitAndSortOrder()
        {

            var cargoLineList = new List<CargoLine>();

            foreach (var orderLine in OrderLines)
            {
                var quantity = orderLine.quantity;
                var product = Products[orderLine.gtin];
                decimal totalOrderWeight = (decimal)product.Weight * quantity;

                if (totalOrderWeight <= MAX_WEIGHT)
                {
                    cargoLineList.Add(new CargoLine(orderLine.gtin, totalOrderWeight));
                    continue;
                }

                var maxCargoQ = Math.Floor(MAX_WEIGHT / (decimal)product.Weight);
                var maxCargoW = maxCargoQ * (decimal)product.Weight;
                var remainingWeight = totalOrderWeight;

                do
                {
                    CargoLine newCargoLine;

                    if (remainingWeight > maxCargoW)
                    {
                        newCargoLine = new CargoLine(orderLine.gtin, maxCargoW);
                    }
                    else
                    {
                        newCargoLine = new CargoLine(orderLine.gtin, remainingWeight);
                    }

                    cargoLineList.Add(newCargoLine);
                    remainingWeight -= maxCargoW;

                } while (remainingWeight > 0);


            }

            cargoLineList.Sort((a, b) =>
            {
                return b.Weight.CompareTo(a.Weight);
            });

            return cargoLineList;

        }

        public void SortTrucks()
        {

            Trucks.Sort((a, b) =>
            {
                return b.Weight.CompareTo(a.Weight);
            });
        }
    }

}