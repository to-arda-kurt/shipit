﻿namespace ShipIt.Models.ApiModels
{
    public class Response
    {
        public bool Success { get; set; }

        //Empty constructor required for xml serialization.
        public Response()
        {
        }
    }
}