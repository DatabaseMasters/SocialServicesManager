using SocialServicesManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialServicesManager.App.Commands.Abstarcts
{
    public abstract class ExporterCommand : ICommand
    {
        protected readonly IDataFactory dataFactory;

        public ExporterCommand(IDataFactory dataFactory)
        {
            this.dataFactory = dataFactory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
