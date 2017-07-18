namespace FTPClient
{
    /// <summary>
    /// class that contains fields with data about connection
    /// </summary>
    class Connection
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Uri { get; set; }

        public bool Passive = true;
        public bool Binary = true;
        public bool Hash = true;


        public Connection(string uri, string userName, string password)
        {
            this.Uri = uri;
            this.Password = password;
            this.UserName = userName;
        }
    }
}
