using System.Collections.Generic;

namespace SocialServicesManager.App.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
