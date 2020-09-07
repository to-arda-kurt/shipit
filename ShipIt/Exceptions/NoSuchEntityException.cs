﻿namespace ShipIt.Exceptions
{
    public class NoSuchEntityException : ClientVisibleException
    {
        private ErrorCode _errorCode;

        public NoSuchEntityException(string message) : base(message, ErrorCode.NO_SUCH_ENTITY_EXCEPTION)
        {
        }

        public override ErrorCode ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
    }
}