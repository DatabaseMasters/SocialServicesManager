using System.Collections.Generic;

namespace SocialServicesManager.Interfaces
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
