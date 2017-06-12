using SocialServicesManager.App.Exceptions;
using SocialServicesManager.Interfaces;

namespace SocialServicesManager.App
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IProcessor processor;

        public Engine(IReader reader, IWriter writer, IProcessor processor)
        {
            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {
                string commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == string.Empty)
                {
                    this.writer.WriteLine("Empty command. Please enter a valid command.");
                    continue;
                }

                if (commandLine.ToLower() == "end")
                {
                    this.writer.WriteLine("Closing");
                    break;
                }

                try
                {
                    var commandResult = this.processor.ProcessCommand(commandLine);
                    this.writer.WriteLine(commandResult);
                }
                catch (EntryNotFoundException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (ParameterValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (System.FormatException ex)
                {
                    this.writer.WriteLine("! Parse error: " + ex.Message);
                }
            }
        }
    }
}
