using System;

namespace FTPClient
{
    class CreateCommandGoIntoFolders : CommandCreator
    {
        private string folder;

        public CreateCommandGoIntoFolders(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(string commandString)
        {
            if (commandString.Contains(CommandInfo.GoIntoFolder))
            {
                ParseCommand(commandString);
                command = new GoIntoFoldersCommand(folder);
            }
            else
            {
                command = Successor.CreateCommand(commandString);
            }
            return command;
        }

        private void ParseCommand(string commandString)
        {
           folder = commandString.Replace(CommandInfo.GoIntoFolder, " ").Trim();
        }
    }
}
