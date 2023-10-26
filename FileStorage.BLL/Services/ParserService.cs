using System.Linq;
using FileStorage.BLL.Interfaces;

namespace FileStorage.BLL.Services
{
    public class ParserService : IParserService
    {
        private readonly ICommandsProcessorService _consoleManager;


        public ParserService(ICommandsProcessorService consoleManager)
        {
            _consoleManager = consoleManager;
        }

        
        public void ParseUserInput(string consoleText)
        {
            var splitSentences = consoleText.Split(" ");

            var clearSentences = splitSentences.Select(t => t.Trim(' ', '-')).ToList();

            _consoleManager.ProcessCommands(clearSentences);
        }
    }
}
