using Moq;
using NUnit.Framework;
using SocialServicesManager.App;
using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Interfaces;
using System;

namespace SSM.App.Tests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Start_CallsWriterOnceWithEmptyMessage_WhenPassedEmptyCommand()
        {
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.SetupSequence(r => r.ReadLine()).Returns(string.Empty).Returns("End");

            engine.Start();

            writerMock.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains("Empty command"))), Times.Once);
        }

        [Test]
        public void Start_CallsWriterOnceWithClosingMessage_WhenPassedEndCommand()
        {
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.Setup(r => r.ReadLine()).Returns("End");

            engine.Start();

            writerMock.Verify(w => w.WriteLine("Closing"), Times.Once);
        }

        [Test]
        public void Start_CallsWriterOnceWithCommandResult_WhenPassedValidCommand()
        {
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var validCommandLine = "createfamily Popovi 1";
            var successCommandResult = "OK";

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.SetupSequence(r => r.ReadLine()).Returns(validCommandLine).Returns("End");
            processorMock.Setup(p => p.ProcessCommand(validCommandLine)).Returns(successCommandResult);

            engine.Start();

            writerMock.Verify(w => w.WriteLine(successCommandResult));
        }

        [Test]
        public void Start_HandlesEntryNotFoundException_WhenNonexistentParameterPassed()
        {
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var invalidCommandLine = "createfamily Popovi 999";

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.SetupSequence(r => r.ReadLine()).Returns(invalidCommandLine).Returns("End");
            processorMock.Setup(p => p.ProcessCommand(invalidCommandLine)).Throws(new EntryNotFoundException(It.IsAny<string>()));

            engine.Start();

            writerMock.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains("Not found error"))), Times.Once);
        }

        [Test]
        public void Start_HandlesParameterValidationException_WhenLessParametersPassed()
        {            
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var invalidCommandLine = "createfamily Popovi";

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.SetupSequence(r => r.ReadLine()).Returns(invalidCommandLine).Returns("End");
            processorMock.Setup(p => p.ProcessCommand(invalidCommandLine)).Throws(new ParameterValidationException(It.IsAny<string>()));

            engine.Start();

            writerMock.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains("Parameter error"))), Times.Once);
        }

        [Test]
        public void Start_HandlesFormatException_WhenCommandParametersAreUnparsable()
        {
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var invalidCommandLine = "createfamily Popovi notANumber";

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.SetupSequence(r => r.ReadLine()).Returns(invalidCommandLine).Returns("End");
            processorMock.Setup(p => p.ProcessCommand(invalidCommandLine)).Throws<FormatException>();

            engine.Start();

            writerMock.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains("Parse error"))), Times.Once);
        }

        [Test]
        public void Start_HandlesNullReferenceException_WhenPassedNonexistentCommand()
        {
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<IProcessor>();

            var invalidCommandLine = "SpiMiSe";

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);
            readerMock.SetupSequence(r => r.ReadLine()).Returns(invalidCommandLine).Returns("End");
            processorMock.Setup(p => p.ProcessCommand(invalidCommandLine)).Throws<NullReferenceException>();

            engine.Start();

            writerMock.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains("Command error"))), Times.Once);
        }
    }
}
