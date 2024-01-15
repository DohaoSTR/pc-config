using Microsoft.Extensions.Configuration;
using System.IO;

namespace PCConfig.Model.Access
{
    public class ConfigurationManager
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigurationManager()
        {
            _configurationRoot = GetConfiguration();
        }

        private IConfigurationRoot GetConfiguration()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo currentDirectoryInfo = new(currentDirectory);

            DirectoryInfo parentDirectoryInfo = currentDirectoryInfo.Parent.Parent.Parent;

            return new ConfigurationBuilder()
                        .SetBasePath(parentDirectoryInfo.FullName)
                        .AddJsonFile("appsettings.json")
                        .Build();
        }

        public ConnectionSettings GetDatabaseConnectionSettings(string configSectionName)
        {
            ConnectionSettings connectionSettings = new();
            _configurationRoot.GetSection(configSectionName).Bind(connectionSettings);

            return connectionSettings;
        }

        public EmailConfiguration GetEmailConfiguration()
        {
            EmailConfiguration configuration = new();
            _configurationRoot.GetSection("MailSettings").Bind(configuration);

            return configuration;
        }

        public GoogleOAuthConfiguration GetGoogleOAuthConfiguration()
        {
            GoogleOAuthConfiguration configuration = new();
            _configurationRoot.GetSection("GoogleOauthSettings").Bind(configuration);

            return configuration;
        }
    }
}
