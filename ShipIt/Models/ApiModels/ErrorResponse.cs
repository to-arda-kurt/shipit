﻿using ShipIt.Exceptions;

namespace ShipIt.Models.ApiModels
{
    public class ErrorResponse : Response
    {
        public ErrorCode Code { get; set; }
        public string Error { get; set; }

        public ErrorResponse()
        {
            Success = false;
        }
    }
}