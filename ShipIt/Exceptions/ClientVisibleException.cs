﻿using System;

namespace ShipIt.Exceptions
{
    public abstract class ClientVisibleException : Exception
    {
        public abstract ErrorCode ErrorCode { get; set; }

        protected ClientVisibleException(string message, ErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}