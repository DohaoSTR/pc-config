using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Windows;

namespace PCConfig.Model.Access
{
    public class GoogleOAuthManager
    {
        private readonly GoogleOAuthConfiguration _googleOAuthConfiguration;

        private UserCredential _userCredential;

        public GoogleOAuthManager()
        {
            ConfigurationManager manager = new();
            _googleOAuthConfiguration = manager.GetGoogleOAuthConfiguration();
        }

        public event Action<string> Authorized;

        public async void Authorization()
        {
            try
            {
                FileDataStore data_store = new(_googleOAuthConfiguration.ApplicationName);

                _userCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = _googleOAuthConfiguration.ClientId,
                        ClientSecret = _googleOAuthConfiguration.ClientSecret
                    },
                    new[] { "profile", "email" },
                    Environment.UserName,
                    CancellationToken.None,
                    data_store
                );

                Oauth2Service service = new(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = _userCredential,
                    ApplicationName = _googleOAuthConfiguration.ApplicationName,
                });

                Google.Apis.Oauth2.v2.Data.Userinfo userInfo = await service.Userinfo.Get().ExecuteAsync();

                await _userCredential.RevokeTokenAsync(CancellationToken.None);
                Authorized?.Invoke(userInfo.Email);
            }
            catch (Exception)
            {
                MessageBox.Show($"Пользователь не авторизован!");
            }
        }
    }
}
