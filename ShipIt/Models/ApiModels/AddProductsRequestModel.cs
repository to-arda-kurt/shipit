﻿using ShipIt.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShipIt.Models.ApiModels
{
    public class InboundManifestRequestModel
    {
        public int WarehouseId { get; set; }
        public string Gcp { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }

        public override String ToString()
        {
            return new StringBuilder()
                .AppendFormat("warehouseId: {0}, ", WarehouseId)
                .AppendFormat("gcp: {0}, ", Gcp)
                .AppendFormat("orderLines: {0}, ", OrderLines)
                .ToString();
        }
    }
}