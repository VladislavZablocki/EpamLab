using System;

namespace FTPClient
{
    class CreateCommandPrintDirectoryContent : CommandCreator
    {
        public CreateCommandPrintDirectoryContent(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(string commandString)
        {
            if (commandString.Contains(CommandInfo.PrintDirectoryContent))
            {
                command = new PrintDirectoryContentCommand();
            }
            else if (Successor == null)
            {
                command = null;
            }
            return command;
        }
    }
}
