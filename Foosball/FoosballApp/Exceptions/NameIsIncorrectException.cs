using System;

namespace FoosballApp.Exceptions
{
    public class NameIsIncorrectException : Exception
    {
        public NameIsIncorrectException(string message)
            : base($"Name \"{message}\" is incorrect or empty")
        {
        }
    }
}