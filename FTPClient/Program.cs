using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string readLine;
            CommandInfo commandInfo = new CommandInfo();
            CommandHandler commandHandler = new CommandHandler();
            Console.WriteLine(commandInfo);
            try
            {
                do
                {
                    Console.Write("> ");
                    readLine = Console.ReadLine();
                    commandHandler.Process(readLine);
                }
                while (!readLine.Contains(CommandInfo.Exit));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
