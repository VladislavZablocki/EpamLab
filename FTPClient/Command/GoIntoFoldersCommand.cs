namespace FTPClient
{
    class GoIntoFoldersCommand : ICommand
    {
        private string folder;

        public GoIntoFoldersCommand(string folder)
        {
            this.folder = folder;
        }

        public void Execute()
        {
            Client.ClientInstance.GoInto(folder);
        }
    }
}
