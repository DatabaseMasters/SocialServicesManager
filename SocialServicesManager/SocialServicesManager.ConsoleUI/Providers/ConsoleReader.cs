using SocialServicesManager.Interfaces;
using System;

namespace SocialServicesManager.ConsoleUI.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string result = Console.ReadLine();
            return result;
        }
    }
}
