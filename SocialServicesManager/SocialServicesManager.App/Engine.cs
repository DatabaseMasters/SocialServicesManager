using SocialServicesManager.App.Providers.Contracts;
using System.Text;

namespace SocialServicesManager.App
{
    public class Engine : IEngine
    {

        public Engine(IReader reader, IWriter writer, IProcessor processor)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.Processor = processor;
        }

        public IReader Reader { get; private set; }
        public IWriter Writer { get; private set; }
        public IProcessor Processor { get; private set; }

        public void Start()
        {
            var builder = new StringBuilder();

            while (true)
            {
                string commandLine = this.Reader.ReadLine();

                if (commandLine.ToLower() == "end")
                {
                    this.Writer.Write(builder.ToString());
                    this.Writer.WriteLine("Closing");
                    break;
                }

                try
                {
                    var commandResult = Processor.ProcessCommand(commandLine);
                    builder.AppendLine(commandResult);
                }
                catch (System.Exception ex)
                {
                    builder.AppendLine("An error appeared. " + ex.Message);
                }
            }
        }
    }
}
