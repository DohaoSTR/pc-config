using PCConfig.Model.Access;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.Access
{
    public class ChangePasswordViewModel : INotifyPropertyChanged
    {
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

        private string _repeatPassword;
        public string RepeatPassword
        {
            get => _repeatPassword;
            set
            {
                _repeatPassword = value;
                OnPropertyChanged(nameof(RepeatPassword));
            }
        }

        private string _changePasswordDescription;
        public string ChangePasswordDescription
        {
            get => _changePasswordDescription;
            set
            {
                _changePasswordDescription = value;
                OnPropertyChanged(nameof(ChangePasswordDescription));
            }
        }

        private readonly string _email;

        public ChangePasswordViewModel(string email)
        {
            _email = email;
        }

        public event Action BackButtonClicked;
        public event Action<string, string> ChangePasswordButtonClicked;

        #region INotifyPropertyChanged BackButtonClicked

        public ICommand BackCommand => new RelayCommand(Back);

        private void Back()
        {
            BackButtonClicked?.Invoke();
        }

        #endregion

        #region INotifyPropertyChanged ChangePasswordButtonClicked

        public ICommand ChangePasswordCommand => new RelayCommand(ChangePassword);

        private void ChangePassword()
        {
            if (string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_repeatPassword))
            {
                ChangePasswordDescription = "Данные не введены!";
                return;
            }

            if (_password == _repeatPassword)
            {
                if (RegistrationDataValidator.IsStrongPassword(_password))
                {
                    ChangePasswordButtonClicked?.Invoke(_email, _password);
                }
                else
                {
                    ChangePasswordDescription = RegistrationDataValidator.GetPasswordErrorDescription(_password);
                }
            }
            else
            {
                ChangePasswordDescription = "Пароли не совпадают!";
            }
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