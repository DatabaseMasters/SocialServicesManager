using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Services.Parser;
using SocialServicesManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SocialServicesManager.App.Commands.Import
{
    public class ImportDataCommand : Command, ICommand
    {
        private const int ParametersCount = 2;
        private const string JsonFormat = "json";
        private const string XMLFormat = "xml";

        private readonly string[] dataFormats = new string[] { JsonFormat, XMLFormat };

        public ImportDataCommand(IDataFactory dataFactory) : base(dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string dataFormat = parameters[0].ToLower();
            string filePath = parameters[1];
            this.ValidateParameters(parameters, ParametersCount);

            int families;

            if (dataFormat == JsonFormat)
            {
                families = DataParser.ParseFamiliesJsonData(filePath, "dd.MM.yyyy", this.DataFactory);
            }
            else
            {
                families = DataParser.ParseFamiliesXMLData(filePath, this.DataFactory);
            }

            return $"{families} successfully families imported from {filePath}";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, paramterCount);

            string dataFormat = parameters[0].ToLower();
            string filePath = parameters[1];

            if (!File.Exists(filePath))
            {
                throw new ParameterValidationException($"File {filePath} does not exist.");
            }

            if (Array.IndexOf(this.dataFormats, dataFormat) == -1)
            {
                throw new ParameterValidationException($"No such data type {dataFormat} found. Allowed data types are: "
                    + string.Join(", ", this.dataFormats));
            }
        }
    }
}
