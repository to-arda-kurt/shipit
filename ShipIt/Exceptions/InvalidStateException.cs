﻿namespace ShipIt.Exceptions
{
    public class InvalidStateException : ClientVisibleException
    {
        private ErrorCode _errorCode;

        public InvalidStateException(string message) : base(message, ErrorCode.INVALID_STATE)
        {
        }

        public override ErrorCode ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
    }
}