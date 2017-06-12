using Ninject;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.ConsoleUI.Container
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.kernel.TryGet<ICommand>(commandName);            
        }
    }
}
