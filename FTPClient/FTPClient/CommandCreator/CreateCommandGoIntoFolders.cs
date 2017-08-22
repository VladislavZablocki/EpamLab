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
                folder = ReplaseCommandNameAndTrim(commandString, CommandInfo.GoIntoFolder);
                command = new GoIntoFoldersCommand(folder);
            }
            else
            {
                command = Successor.CreateCommand(commandString);
            }
            return command;
        }
    }
}
