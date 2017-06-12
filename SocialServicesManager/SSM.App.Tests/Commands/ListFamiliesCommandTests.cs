using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SocialServicesManager.App.Commands.Listing;
using SocialServicesManager.Data.Factories.Contracts;
using SocialServicesManager.Data.Models;

namespace SSM.App.Tests.Commands
{
    [TestFixture]
    public class ListFamiliesCommandTests
    {
        [Test]
        public void Execute_CallsDataGetAllFamilies()
        {
            var dataFactoryMock = new Mock<IDataFactory>();

            var fakeFamilies = new List<Family>()
            {
                new Family(),
                new Family()
            };

            var command = new ListFamiliesCommand(dataFactoryMock.Object);
            dataFactoryMock.Setup(d => d.GetAllFamilies()).Returns(fakeFamilies);

            command.Execute(new List<string>());

            dataFactoryMock.Verify(d => d.GetAllFamilies(), Times.Once);
        }

        [Test]
        public void Execute_MessageContainsNoFamilies_WhenNoFamiliesInDatabase()
        {
            var dataFactoryMock = new Mock<IDataFactory>();

            var command = new ListFamiliesCommand(dataFactoryMock.Object);
            dataFactoryMock.Setup(d => d.GetAllFamilies()).Returns(new List<Family>());

            var result = command.Execute(new List<string>());

            StringAssert.Contains("no families", result);
        }

        [Test]
        public void Execute_MessageContainsName_WhenFamiliesExistInDatabase()
        {
            var dataFactoryMock = new Mock<IDataFactory>();

            var fakeFamilies = new List<Family>()
            {
                new Family(),
                new Family()
            };

            var command = new ListFamiliesCommand(dataFactoryMock.Object);
            dataFactoryMock.Setup(d => d.GetAllFamilies()).Returns(fakeFamilies);

            var result = command.Execute(new List<string>());

            StringAssert.Contains("Name", result);
        }
    }
}
