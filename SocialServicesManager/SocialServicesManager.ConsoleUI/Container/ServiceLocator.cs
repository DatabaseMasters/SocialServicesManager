using Bytes2you.Validation;
using Ninject;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.ConsoleUI.Container
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();
            this.kernel = kernel;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.kernel.TryGet<ICommand>(commandName);            
        }
    }
}
