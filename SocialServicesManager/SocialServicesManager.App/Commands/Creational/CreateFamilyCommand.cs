﻿using System;
using System.Collections.Generic;
using SocialServicesManager.App.Commands.Contracts;
using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.Data.Factories;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateFamilyCommand : CreationalCommand, ICommand
    {
        public CreateFamilyCommand(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            // TODO Fix passed parameters to factory
            var family = this.ModelFactory.CreateFamily(parameters[0]);

            this.DataFactory.AddFamily(family);
            this.DataFactory.SaveAllChanges();

            return $"Family {family.Name} with id {family.Id} created.";
        }
    }
}
