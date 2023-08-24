﻿using System.Collections;
using ShipIt.Models.Helpers;

namespace ShipIt.Models.ApiModels
{
    public class OrderRespond : Response
    {

        public TruckPacker TruckPacker { get; set; }
        //Empty constructor required for xml serialization.
        public OrderRespond()
        {
        }

        public OrderRespond(TruckPacker truckPacker)
        {
            TruckPacker = truckPacker;
            Success = true;
        }
    }
}

