using System;

namespace SocialServicesManager.App.Exceptions
{
    public class ParameterValidationException : Exception
    {
        private const string ExceptionPrefix = "! Parameter error: ";

        public ParameterValidationException(string message) 
            : base(ExceptionPrefix + message)
        {
        }
    }
}
