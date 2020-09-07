﻿namespace ShipIt.Exceptions
{
    public class MalformedRequestException : ClientVisibleException
    {
        private ErrorCode _errorCode;

        public MalformedRequestException(string message) : base(message, ErrorCode.MALFORMED_REQUEST)
        {
        }

        public override ErrorCode ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
    }
}