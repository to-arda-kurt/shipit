﻿namespace ShipIt.Models.ApiModels
{
    public class ProductResponse: Response
    {
        public Product Product { get; set; }
        public ProductResponse(Product product)
        {
            Product = product;
            Success = true;
        }
        public ProductResponse() { }
    }
}