using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FTPClient
{
    /// <summary>
    /// Singleton client
    /// </summary>
    public class Client
    {
        private Connection connection;
        private int bufferSize = 1024;

        private Client()
        { }

        private static Client clientInstance;

        public static Client ClientInstance
        {
            get { return clientInstance ?? (clientInstance = new Client()); }
        }

        public void CreateConnection(string[] connectionString)
        {
            connection = new Connection(connectionString);
            //connection = new Connection(@"ftp://ftp.intel.com", "", "");
        }

        public void PrintDirectoryContent()
        {
            List<string> contentDirectoryList = new List<string>();
            var request = CreateRequest(WebRequestMethods.Ftp.ListDirectoryDetails);
            using (var reader = new StreamReader(((FtpWebResponse)request.GetResponse()).GetResponseStream(), true))
            {
                while (!reader.EndOfStream)
                {
                    contentDirectoryList.Add(reader.ReadLine());
                }
            }
            foreach (var item in contentDirectoryList)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// download file in bin/debug/filename
        /// </summary>
        /// <param name="fileName">name of downloaded file</param>
        public void DownloadFile(string fileName)
        {
            var request = CreateRequest(Path.Combine(connection.Uri, fileName).Replace("\\", "/"),
                WebRequestMethods.Ftp.DownloadFile);
            byte[] buffer = new byte[bufferSize];
            using (var stream = ((FtpWebResponse)request.GetResponse()).GetResponseStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    int readCount = stream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        PrintDownloadBar();
                        fileStream.Write(buffer, 0, readCount);
                        readCount = stream.Read(buffer, 0, bufferSize);
                    }
                }
            }
            Console.Write("\n");
        }

        public void GoInto(string folder)
        {
            connection.Uri = Path.Combine(connection.Uri, folder).Replace("\\", "/");
        }

        public void GoToParent()
        {
            string uri = connection.Uri.Remove(connection.Uri.LastIndexOf("/"));
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(uri);
                connection.Uri = uri;
            }
            catch (UriFormatException)
            {
                Console.WriteLine("you are in root folder");
            }
        }

        private FtpWebRequest CreateRequest(string method)
        {
            return CreateRequest(connection.Uri, method);
        }

        private FtpWebRequest CreateRequest(string uri, string method)
        {
            var request = (FtpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(connection.UserName, connection.Password);
            request.Method = method;
            request.UseBinary = connection.Binary; 
            request.UsePassive = connection.Passive;
            return request;
        }

        private void PrintDownloadBar()
        {
            if (connection.Hash)
            {
                Console.Write("#");
            }
        }
    }
}
