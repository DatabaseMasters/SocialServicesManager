using System;

namespace SocialServicesManager.Interfaces
{
    public interface IServiceLocator
    {
        ICommand GetCommand(string commandName);
    }
}
