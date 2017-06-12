using SocialServicesManager.App.Commands.Abstarcts;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.DataValidation;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SocialServicesManager.App.Commands.Creational
{
    public class CreateMedicalDoctor : CreationalCommand, ICommand
    {
        private const int ParameterCount = 4;

        public CreateMedicalDoctor(IModelsFactory modelFactory, IDataFactory dataFactory) : base(modelFactory, dataFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters, ParameterCount);

            var firstName = parameters[0];
            var lastName = parameters[1];
            var phoneNumber = parameters[2];
            var specialty = parameters[3];

            this.ValidateName("First name", firstName);
            this.ValidateName("Last name", lastName);
            this.ValidateName("Specialty", specialty);

            var doctor = this.ModelFactory.CreateMedicalDoctor(firstName, lastName, phoneNumber, specialty);

            this.DataFactory.AddMedicalDoctor(doctor);
            this.DataFactory.SaveAllChanges();

            return $"Medical doctor {doctor.FirstName} with id {doctor.Id} created.";
        }

        protected override void ValidateParameters(IList<string> parameters, int paramterCount)
        {
            base.ValidateParameters(parameters, paramterCount);

            var phoneNumber = parameters[2];

            if (phoneNumber.Length != ModelsConstraints.PhoneNumberLength)
            {
                throw new ParameterValidationException($"Phone number should be {ModelsConstraints.PhoneNumberLength} digits long.");
            }

            if (!new Regex(ModelsConstraints.PhoneNumberContents).IsMatch(phoneNumber))
            {
                throw new ParameterValidationException("Phone number should start with zero and contain only digits (eg. 0888123456).");
            }
        }
    }
}
