using System;

namespace SchoolGradingSystem.Exceptions
{
    public class MissingFieldException : Exception
    {
        public MissingFieldException(string message) : base(message)
        {
        }
    }
}
