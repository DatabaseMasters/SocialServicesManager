using SocialServicesManager.App.Providers.Contracts;
using System;

namespace SocialServicesManager.ConsoleUI.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
