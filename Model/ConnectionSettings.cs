namespace PCConfig.Model
{
    public class ConnectionSettings
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string DatabaseName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ConnectionSettings(string host, string port, string databaseName, string username, string password)
        {
            Host = host;
            Port = port;
            DatabaseName = databaseName;
            Username = username;
            Password = password;
        }

        public ConnectionSettings() { }
    }
}
