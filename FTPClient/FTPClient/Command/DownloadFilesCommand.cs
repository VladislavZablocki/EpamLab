namespace FTPClient
{
    class DownloadFilesCommand : ICommand
    {
        private string fileName;

        public DownloadFilesCommand(string fileName)
        {
            this.fileName = fileName;
        }

        public void Execute()
        {
            Client.ClientInstance.DownloadFile(fileName);
        }
    }
}
