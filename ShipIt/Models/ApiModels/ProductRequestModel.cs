﻿namespace ShipIt.Parsers
{
    public class ProductRequestModel
    {
        public string Gtin { get; set; }
        public string Gcp { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string LowerThreshold { get; set; }
        public string Discontinued { get; set; }
        public string MinimumOrderQuantity { get; set; }
    }
}