using System;

namespace FTPClient
{
    class CreateCommandGoToParentDirectory : CommandCreator
    {
        public CreateCommandGoToParentDirectory(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(string commandString)
        {
            if (commandString.Contains(CommandInfo.GoParentDirectory))
            {
                command = new GoToParentDirectoryCommand();
            }
            else
            {
                command = Successor.CreateCommand(commandString);
            }
            return command;
        }
    }
}
