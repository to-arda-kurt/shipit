﻿namespace ShipIt.Exceptions
{
    public class ValidationException : MalformedRequestException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}