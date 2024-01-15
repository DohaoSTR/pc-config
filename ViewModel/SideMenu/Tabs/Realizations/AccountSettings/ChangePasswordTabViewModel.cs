using PCConfig.Model.Access;
using PCConfig.Model.Contexts;
using PCConfig.Model.UsersData;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.AccountSettings
{
    public class ChangePasswordTabViewModel : INotifyPropertyChanged
    {
        private int _code;
        public int Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        private string _confirmationDescription;
        public string ConfirmationDescription
        {
            get => _confirmationDescription;
            set
            {
                _confirmationDescription = value;
                OnPropertyChanged(nameof(ConfirmationDescription));
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

        private readonly int _userId;
        private readonly string _email;
        private readonly int? _generatedCode;

        private readonly UserDataContext _context;

        public ChangePasswordTabViewModel(int userId, string email)
        {
            _userId = userId;
            _email = email;

            _context = new UserDataContext();

            _generatedCode = Restore();
            if (_generatedCode != null)
            {
                _context.AddLog(_email, "Попытка смены пароля");
            }
        }

        public event Action BackButtonClicked;
        public event Action ChangePasswordButtonClicked;

        #region INotifyPropertyChanged BackButtonClicked

        public ICommand BackCommand => new RelayCommand(Back);

        private void Back()
        {
            BackButtonClicked?.Invoke();
        }

        #endregion

        #region INotifyPropertyChanged ChangePasswordButtonClicked

        public ICommand ChangePasswordCommand => new RelayCommand(ChangePassword);

        private int? Restore()
        {
            UserDataContext context = new();
            UserType? type = context.GetUserType(_userId);
            if (type == UserType.Google)
            {
                MessageBox.Show("Нельзя менять пароль для Google аккаунта.");
            }
            else
            {
                string email = context.GetEmail(_userId);

                MailManager manager = new();
                int code = manager.GenerateConfirmationCode();
                bool isConfirmationCodeSend = manager.SendConfirmationCodeToEmail(email, code);

                if (isConfirmationCodeSend == true)
                {
                    return code;
                }
                else
                {
                    MessageBox.Show("Код не был отправлен.");
                }
            }

            return null;
        }

        private void ChangePasswordDatabase(string email, string password)
        {
            if (_context.ChangePassword(email, password) == true)
            {
                _context.AddLog(email, "Успешная смена пароля");
                ChangePasswordButtonClicked?.Invoke();
                MessageBox.Show("Смена пароля успешна!");
            }
            else
            {
                _context.AddLog(email, "Неуспешная смена пароля");
                ChangePasswordButtonClicked?.Invoke();
                MessageBox.Show("Смена пароля не успешна!");
            }
        }

        private void ChangePassword()
        {
            if (string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_repeatPassword))
            {
                ChangePasswordDescription = "Данные не введены!";
                return;
            }

            if (_generatedCode == Code)
            {
                if (_password == _repeatPassword)
                {
                    if (RegistrationDataValidator.IsStrongPassword(_password))
                    {
                        ChangePasswordDatabase(_email, _password);
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
            else
            {
                ConfirmationDescription = "Введен неверный код.";
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