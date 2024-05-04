﻿namespace MessageQueue.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
       : base($"Domain Exception: \"{message}\"")
        {
        }
    }
}
