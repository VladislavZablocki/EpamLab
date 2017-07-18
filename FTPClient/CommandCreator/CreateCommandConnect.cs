using System;

namespace FTPClient
{
    class CreateCommandConnect : CommandCreator
    {
        private string[] connectionString = new string[] { };

        public CreateCommandConnect(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(string commandString)
        {
            if (commandString.Contains(CommandInfo.CreateConnection))
            {
                ParseCommand(commandString);
                command = new ConnectCommand(connectionString);
            }
            else
            {
                command = Successor.CreateCommand(commandString);
            }
            return command;
        }

        private void ParseCommand(string commandString)
        {
            connectionString = commandString.Replace(CommandInfo.CreateConnection," ").Trim().Split(Separators);
        }
    }
}
