using PCConfig.Model.Access;
using PCConfig.Model.Contexts;
using PCConfig.Model.UsersData;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.Access
{
    public class RestoreAccessViewModel : INotifyPropertyChanged
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

        public RestoreAccessViewModel() { }

        public RestoreAccessViewModel(string email)
        {
            Email = email;
        }

        public event Action Backed;
        public event Action<int, string> ConfirmationCodeSended;

        public ICommand BackCommand => new RelayCommand(Back);

        private void Back()
        {
            Backed?.Invoke();
        }

        public ICommand RestoreCommand => new RelayCommand(Restore);

        private void Restore()
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

            if (isValid == true)
            {
                UserDataContext context = new();
                UserType? type = context.GetUserType(Email);
                if (type == UserType.Google)
                {
                    EmailDescriptionText = $"Нельзя менять пароль для google аккаунта.";
                }
                else if (type == null)
                {
                    EmailDescriptionText = $"Аккаунта с таким email не существует.";
                }
                else
                {
                    MailManager manager = new();
                    int code = manager.GenerateConfirmationCode();
                    bool isConfirmationCodeSend = manager.SendConfirmationCodeToEmail(_email, code);

                    if (isConfirmationCodeSend == true)
                    {
                        ConfirmationCodeSended?.Invoke(code, _email);
                    }
                    else
                    {
                        EmailDescriptionText = $"Код не был отправлен.";
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
