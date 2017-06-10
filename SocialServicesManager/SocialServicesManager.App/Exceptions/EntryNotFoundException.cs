using System;

namespace SocialServicesManager.App.Exceptions
{
    public class EntryNotFoundException : Exception
    {
        private const string ExceptionPrefix = "! Not found error: ";

        public EntryNotFoundException(string message)
            : base(ExceptionPrefix + message)
        {
        }
    }
}
