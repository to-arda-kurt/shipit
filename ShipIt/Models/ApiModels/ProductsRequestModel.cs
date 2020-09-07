﻿using System.Collections.Generic;
using ShipIt.Parsers;

namespace ShipIt.Controllers
{
    public class ProductsRequestModel
    {
        public IEnumerable<ProductRequestModel> Products { get; set; }
    }
}