using PCConfig.Model.Access;
using PCConfig.Model.Contexts;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.Access
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        private readonly GoogleOAuthManager _manager;

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _authorizationDescription;
        public string AuthorizationDescription
        {
            get => _authorizationDescription;
            set
            {
                _authorizationDescription = value;
                OnPropertyChanged(nameof(AuthorizationDescription));
            }
        }

        private void Authorized(string email)
        {
            GoogleAuthorized?.Invoke(email);
        }

        public AuthenticationViewModel()
        {
            _manager = new GoogleOAuthManager();
            _manager.Authorized += Authorized;

            Email = "muzalevskij.evgenij@mail.ru";
            Password = "1234#$2aBda";

        }

        public event Action RegisteredButtonClick;
        public event Action<string, string> AuthorizedButtonClick;
        public event Action<string> GoogleAuthorized;
        public event Action RestoreAccessButtonClick;

        #region INotifyPropertyChanged ResiteredButtonClick

        public ICommand RegistrationCommand => new RelayCommand(Registration);

        private void Registration()
        {
            RegisteredButtonClick?.Invoke();
        }

        #endregion

        #region INotifyPropertyChanged AuthorizedButtonClick

        public ICommand AuthorizationCommand => new RelayCommand(Authorization);

        private async void Authorization()
        {
            bool isValid = true;
            if (RegistrationDataValidator.IsValidEmailFormat(_email) == false)
            {
                AuthorizationDescription = $"Данные некорректны.";
                isValid = false;
            }


            if (RegistrationDataValidator.IsStrongPassword(_password) == false)
            {
                AuthorizationDescription = $"Данные некорректны.";
                isValid = false;
            }

            if (isValid == true)
            {
                UserDataContext context = new();
                if (context.Authorize(_email, _password) == false)
                {
                    AuthorizationDescription = $"Данные введены неверно.";
                }
                else
                {
                    AuthorizedButtonClick?.Invoke(_email, _password);
                }

            }
        }

        #endregion

        #region INotifyPropertyChanged GoogleAuthorization

        public ICommand GoogleAuthorizationCommand => new RelayCommand(GoogleAuthorization);

        private void GoogleAuthorization()
        {
            _manager.Authorization();
        }

        #endregion

        #region INotifyPropertyChanged RestoreAccessButtonClick

        public ICommand RestoreAccessCommand => new RelayCommand(RestoreAccess);

        private void RestoreAccess()
        {
            RestoreAccessButtonClick?.Invoke();
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
