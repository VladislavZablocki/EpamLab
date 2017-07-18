using System;

namespace FTPClient
{
    /// <summary>
    /// Class contains chain of all commands and method Process
    /// </summary>
    class CommandHandler
    {
        private ICommand command;
        private CommandCreator creator = new CreateCommandConnect(
            new CreateCommandDownloadFiles(
                new CreateCommandGoIntoFolders(
                    new CreateCommandGoToParentDirectory(
                        new CreateCommandPrintDirectoryContent(null)))));

        /// <summary>
        /// create command and execute it
        /// </summary>
        /// <param name="commandLine">string from command line</param>
        public void Process(string commandLine)
        {
            if (commandLine.Contains(CommandInfo.Exit))
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                command = creator.CreateCommand(commandLine);
                if (command == null)
                {
                    Console.WriteLine("Incorrect command!");
                }
                else
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Connection not established");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Incorrect conection data");
                    }
                }
            }
        }
    }
}
