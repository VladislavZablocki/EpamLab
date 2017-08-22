using System;

namespace FTPClient
{
    /// <summary>
    /// abstract class with method CreateCommand and reference on next command creator
    /// </summary>
    public abstract class CommandCreator
    {
        protected ICommand command;

        public char[] Separators = { ' ' };

        public CommandCreator Successor { get; set; }

        public abstract ICommand CreateCommand(string commandString);

        protected string ReplaseCommandNameAndTrim(string commandline, string commandName)
        {
            return commandline.Replace(commandName, " ").Trim();
        }
    }
}
