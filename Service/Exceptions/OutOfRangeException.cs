using System;

namespace Service.Exceptions
{
    public class OutOfRangeException : ArgumentOutOfRangeException
    {
        public OutOfRangeException(string message) : base(message: message, innerException: null)
        {
        }
    }
}