using System;

namespace FTPClient
{
    class CreateCommandDownloadFiles : CommandCreator
    {
        private string fileName;

        public CreateCommandDownloadFiles(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(string commandString)
        {
            if (commandString.Contains(CommandInfo.Download))
            {
                ParseCommand(commandString);
                command = new DownloadFilesCommand(fileName);
            }
            else
            {
                command = Successor.CreateCommand(commandString);
            }
            return command;
        }

        private void ParseCommand(string commandString)
        {
            fileName = commandString.Replace(CommandInfo.Download, " ").Trim();
        }
    }
}
