namespace FTPClient
{
    class ConnectCommand : ICommand
    {
        private string[] connectionString;

        public ConnectCommand(string[] connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Execute()
        {
            Client.ClientInstance.CreateConnection(connectionString);
        }
    }
}
