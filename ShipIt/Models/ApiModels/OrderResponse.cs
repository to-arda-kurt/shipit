﻿namespace ShipIt.Models.ApiModels
{
    public class OrderRespond : Response
    {

        public int Truck { get; set; }
        //Empty constructor required for xml serialization.
        public OrderRespond()
        {
        }

        public OrderRespond(int truck)
        {
            Truck= truck;
        }
    }
}