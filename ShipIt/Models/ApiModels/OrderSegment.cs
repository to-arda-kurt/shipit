﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipIt.Models.ApiModels
{
    public class InboundOrderResponse
    {
        public Employee OperationsManager { get; set; }
        public int WarehouseId { get; set; }
        public IEnumerable<OrderSegment> OrderSegments { get; set; }
    }

    public class OrderSegment
    {
        public List<InboundOrderLine> OrderLines { get; set; }
        public Company Company { get; set; } 
    }
}