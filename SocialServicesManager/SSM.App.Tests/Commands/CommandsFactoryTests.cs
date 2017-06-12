using Moq;
using NUnit.Framework;
using SocialServicesManager.App.Commands;
using SocialServicesManager.Interfaces;

namespace SSM.App.Tests.Commands
{
    [TestFixture]
    public class CommandsFactoryTests
    {
        [Test]
        public void GetCommand_ReturnsNull_WhenPassedNullArgument()
        {
            var serviceLocatorMock = new Mock<IServiceLocator>();
            var commandFactory = new CommandsFactory(serviceLocatorMock.Object);

            var result = commandFactory.GetCommand(null);

            Assert.AreEqual(null, result);
        }

        [TestCase("createfamily")]
        [TestCase("listfamilies")]
        public void GetCommand_CallsGetCommandWithCorrectArgument_WhenPassedCommandName(string commandName)
        {
            var serviceLocatorMock = new Mock<IServiceLocator>();
            var commandFactory = new CommandsFactory(serviceLocatorMock.Object);

            commandFactory.GetCommand(commandName);

            serviceLocatorMock.Verify(s => s.GetCommand(commandName), Times.Once);
        }
    }
}
