﻿namespace ShipIt.Exceptions
{
    public class InsufficientStockException: ClientVisibleException
    {
        private ErrorCode _errorCode;

        public InsufficientStockException(string message) : base(message, ErrorCode.INSUFFICIENT_STOCK)
        {
        }

        public override ErrorCode ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
    }
}