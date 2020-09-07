﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShipIt.Models.ApiModels
{
    public class OrderLine
    {
        public String gtin { get; set; }
        public int quantity { get; set; }

        public override String ToString()
        {
            return new StringBuilder()
                .AppendFormat("gtin: {0}, ", gtin)
                .AppendFormat("quantity: {0}", quantity)
                .ToString();
        }
    }
}