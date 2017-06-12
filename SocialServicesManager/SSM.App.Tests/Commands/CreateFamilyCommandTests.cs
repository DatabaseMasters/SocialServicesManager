using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SocialServicesManager.App.Commands.Creational;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;

namespace SSM.App.Tests.Commands
{
    [TestFixture]
    public class CreateFamilyCommandTests
    {
        [Test]
        public void Excecute_ThrowsParameterValidationException_WhenPassedLessParameters()
        {
            var modelFactoryMock = new Mock<IModelsFactory>();
            var dataFactoryMock = new Mock<IDataFactory>();

            var parameters = new List<string>
            {
                "Petrovi"
            };

            var command = new CreateFamilyCommand(modelFactoryMock.Object, dataFactoryMock.Object);

            Assert.Throws<ParameterValidationException>(() => command.Execute(parameters));
        }

        [Test]
        public void Excecute_ThrowsParameterValidationException_WhenPassedShortName()
        {
            var modelFactoryMock = new Mock<IModelsFactory>();
            var dataFactoryMock = new Mock<IDataFactory>();

            var parameters = new List<string>
            {
                "P",
                "1"
            };

            var command = new CreateFamilyCommand(modelFactoryMock.Object, dataFactoryMock.Object);

            Assert.Throws<ParameterValidationException>(() => command.Execute(parameters));
        }

        [Test]
        public void Excecute_ThrowsFormatException_WhenPassedUserIdNotInt()
        {
            var modelFactoryMock = new Mock<IModelsFactory>();
            var dataFactoryMock = new Mock<IDataFactory>();

            var parameters = new List<string>
            {
                "Petrovi",
                "au"
            };

            var command = new CreateFamilyCommand(modelFactoryMock.Object, dataFactoryMock.Object);

            Assert.Throws<FormatException>(() => command.Execute(parameters));
        }

        [Test]
        public void Excecute_ThrowsEntryNotFoundException_WhenPassedUserIdNotInDatabase()
        {
            var modelFactoryMock = new Mock<IModelsFactory>();
            var dataFactoryMock = new Mock<IDataFactory>();
                       
            var parameters = new List<string>
            {
                "Petrovi",
                "999"
            };

            var parsedUserId = 999;
            User nullUser = null;

            var command = new CreateFamilyCommand(modelFactoryMock.Object, dataFactoryMock.Object);
            dataFactoryMock.Setup(d => d.FindUser(parsedUserId)).Returns(nullUser);

            Assert.Throws<EntryNotFoundException>(() => command.Execute(parameters));
        }

        [Test]
        public void Excecute_CallsModelCreate_WhenPassedValidParameters()
        {
            var modelFactoryMock = new Mock<IModelsFactory>();
            var dataFactoryMock = new Mock<IDataFactory>();

            var parameters = new List<string>
            {
                "Petrovi",
                "1"
            };

            var parsedUserId = 1;

            var command = new CreateFamilyCommand(modelFactoryMock.Object, dataFactoryMock.Object);
            dataFactoryMock.Setup(d => d.FindUser(parsedUserId)).Returns(new User());
            modelFactoryMock.Setup(m => m.CreateFamily(It.IsAny<string>(), It.IsAny<User>())).Returns(new Family());

            command.Execute(parameters);

            modelFactoryMock.Verify(m => m.CreateFamily(It.IsAny<string>(), It.IsAny<User>()), Times.Once);
        }
    }
}
