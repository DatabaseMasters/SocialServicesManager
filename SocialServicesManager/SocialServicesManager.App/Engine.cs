using SocialServicesManager.Interfaces;
//using System.Text;

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
            //var builder = new StringBuilder();

            while (true)
            {
                string commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "end")
                {
                    //this.Writer.Write(builder.ToString());
                    this.writer.WriteLine("Closing");
                    break;
                }

                try
                {
                    var commandResult = this.processor.ProcessCommand(commandLine);
                    //builder.AppendLine(commandResult);
                    this.writer.WriteLine(commandResult);
                }
                catch (System.Exception ex)
                {
                    //builder.AppendLine("An error appeared. " + ex.Message);
                    this.writer.WriteLine("An error appeared. " + ex.Message);
                }
            }
        }
    }
}
