﻿namespace ShipIt.Models.ApiModels
{
    public class OrderRespond : Response
    {

        public int NumOfTrucks { get; set; }
        //Empty constructor required for xml serialization.
        public OrderRespond()
        {
        }

        public OrderRespond(int numOfTrucks)
        {
            NumOfTrucks= numOfTrucks;
            Success = true;
        }
    }
}