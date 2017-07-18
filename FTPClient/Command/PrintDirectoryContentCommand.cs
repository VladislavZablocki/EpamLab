namespace FTPClient
{
    class PrintDirectoryContentCommand : ICommand
    {
        public void Execute()
        {
            Client.ClientInstance.PrintDirectoryContent();
        }
    }
}
