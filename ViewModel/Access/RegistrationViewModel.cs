using PCConfig.Model.Access;
using PCConfig.Model.Contexts;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.Access
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
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

        private string _emailDescriptionText;
        public string EmailDescriptionText
        {
            get => _emailDescriptionText;
            set
            {
                _emailDescriptionText = value;
                OnPropertyChanged(nameof(EmailDescriptionText));
            }
        }

        private string _passwordDescriptionText;
        public string PasswordDescriptionText
        {
            get => _passwordDescriptionText;
            set
            {
                _passwordDescriptionText = value;
                OnPropertyChanged(nameof(PasswordDescriptionText));
            }
        }

        public RegistrationViewModel() { }

        public RegistrationViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public event Action Backed;
        public event Action Registered;
        public event Action<int, string, string> Confirmation;

        public ICommand BackCommand => new RelayCommand(Back);

        private void Back()
        {
            Backed?.Invoke();
        }

        public ICommand RegistrationCommand => new RelayCommand(Registration);

        private void Registration()
        {
            bool isValid = true;
            if (RegistrationDataValidator.IsValidEmailFormat(_email))
            {
                EmailDescriptionText = $"Email корректный.";
            }
            else
            {
                EmailDescriptionText = $"Email введен некорректно.";
                isValid = false;
            }

            if (RegistrationDataValidator.IsStrongPassword(_password))
            {
                PasswordDescriptionText = $"Введен надежный пароль.";
            }
            else
            {
                PasswordDescriptionText = RegistrationDataValidator.GetPasswordErrorDescription(_password);
                isValid = false;
            }

            if (Password.Length > 20)
            {
                PasswordDescriptionText = $"Пароль больше 20 символов.";
                isValid = false;
            }

            if (isValid == true)
            {
                UserDataContext context = new();
                if (context.IsEmailExist(Email) == true)
                {
                    EmailDescriptionText = $"Такой email уже зарегистрирован.";
                }
                else
                {
                    MailManager manager = new();
                    int code = manager.GenerateConfirmationCode();
                    bool isConfirmationCodeSend = manager.SendConfirmationCodeToEmail(_email, code);

                    if (isConfirmationCodeSend == true)
                    {
                        Confirmation?.Invoke(code, _email, _password);
                    }
                    else
                    {
                        PasswordDescriptionText = $"Код не был отправлен.";
                    }
                }
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
