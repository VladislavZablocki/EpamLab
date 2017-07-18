namespace FTPClient
{
    class GoToParentDirectoryCommand : ICommand
    {
        public void Execute()
        {
            Client.ClientInstance.GoToParent();
        }
    }
}
