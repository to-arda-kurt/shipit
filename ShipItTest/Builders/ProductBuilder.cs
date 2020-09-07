﻿using System;
using System.Collections.Generic;
using ShipIt.Controllers;
using ShipIt.Models.ApiModels;
using ShipIt.Models.DataModels;
using ShipIt.Parsers;

namespace ShipItTest.Builders
{
    public class ProductBuilder
    {
        private int Id = 1;
        private string Gtin = "0099346374235";
        private string Gcp = "0000346";
        private string Name = "2 Count 1 T30 Torx Bit Tips TX";
        private float Weight = 300.0f;
        private int LowerThreshold = 322;
        private int Discontinued = 0;
        private int MinimumOrderQuantity = 108;

        public ProductBuilder setId(int id)
        {
            Id = id;
            return this;
        }

        public ProductBuilder setGtin(String gtin)
        {
            Gtin = gtin;
            return this;
        }

        public ProductBuilder setGcp(String gcp)
        {
            Gcp = gcp;
            return this;
        }

        public ProductBuilder setName(String name)
        {
            Name = name;
            return this;
        }

        public ProductBuilder setWeight(float weight)
        {
            Weight = weight;
            return this;
        }

        public ProductBuilder setLowerThreshold(int lowerThreshold)
        {
            LowerThreshold = lowerThreshold;
            return this;
        }

        public ProductBuilder setDiscontinued(int discontinued)
        {
            Discontinued = discontinued;
            return this;
        }

        public ProductBuilder setMinimumOrderQuantity(int minimumOrderQuantity)
        {
            MinimumOrderQuantity = minimumOrderQuantity;
            return this;
        }

        public ProductDataModel CreateProductDatabaseModel()
        {
            return new ProductDataModel()
            {
                Discontinued = this.Discontinued,
                Gcp = this.Gcp,
                Gtin = this.Gtin,
                Id = this.Id,
                LowerThreshold = this.LowerThreshold,
                MinimumOrderQuantity = this.MinimumOrderQuantity,
                Name = this.Name,
                Weight = this.Weight
            };
        }

        public Product CreateProduct()
        {
            return new Product()
            {
                Discontinued = this.Discontinued == 1,
                Gcp = this.Gcp,
                Gtin = this.Gtin,
                Id = this.Id,
                LowerThreshold = this.LowerThreshold,
                MinimumOrderQuantity = this.MinimumOrderQuantity,
                Name = this.Name,
                Weight = this.Weight
            };
        }

        public ProductsRequestModel CreateProductRequest()
        {
            return new ProductsRequestModel()
            {
                Products = new List<ProductRequestModel>()
                {
                    new ProductRequestModel()
                    {
                        Discontinued = this.Discontinued == 1 ? "true" : "false",
                        Gcp = this.Gcp,
                        Gtin = this.Gtin,
                        LowerThreshold = this.LowerThreshold.ToString(),
                        MinimumOrderQuantity = this.MinimumOrderQuantity.ToString(),
                        Name = this.Name,
                        Weight = this.Weight.ToString()
                    }
                } 
            }; 
        }

        public ProductsRequestModel CreateDuplicateProductRequest()
        {
            return new ProductsRequestModel()
            {
                Products = new List<ProductRequestModel>()
                {
                    new ProductRequestModel()
                    {
                        Discontinued = this.Discontinued == 1 ? "true" : "false",
                        Gcp = this.Gcp,
                        Gtin = this.Gtin,
                        LowerThreshold = this.LowerThreshold.ToString(),
                        MinimumOrderQuantity = this.MinimumOrderQuantity.ToString(),
                        Name = this.Name,
                        Weight = this.Weight.ToString()
                    },
                    new ProductRequestModel()
                    {
                        Discontinued = this.Discontinued == 1 ? "true" : "false",
                        Gcp = this.Gcp,
                        Gtin = this.Gtin,
                        LowerThreshold = this.LowerThreshold.ToString(),
                        MinimumOrderQuantity = this.MinimumOrderQuantity.ToString(),
                        Name = this.Name,
                        Weight = this.Weight.ToString()
                    }
                }
            };
        }
    }
}