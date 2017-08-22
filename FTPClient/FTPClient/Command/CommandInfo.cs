namespace FTPClient
{
    /// <summary>
    /// class with all available commands
    /// </summary>
    class CommandInfo
    {
        public static string CreateConnection = "connect";
        public static string Download = "download";
        public static string GoIntoFolder = "goInto";
        public static string GoParentDirectory = "goParent";
        public static string PrintDirectoryContent = "printContent";
        public static string Exit = "exit";

        public override string ToString()
        {
            return string.Concat(CreateConnection, "\n", Download, "\n", GoIntoFolder, "\n",
                GoParentDirectory, "\n", PrintDirectoryContent, "\n", Exit);
        }
    }
}
