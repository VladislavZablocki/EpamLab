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


        public Connection(params string[] data)
        {
            if (data.Length > 0)
            {
                this.Uri = data[0];
            }
            if (data.Length > 1)
            {
                this.UserName = data[1];
            }
            if (data.Length > 2)
            {
                this.Password = data[2];
            }
        }
    }
}
