using PCConfig.Model.Contexts;
using PCConfig.View;
using PCConfig.View.Access;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.ViewModel.Access
{
    public class AccessControlManager : INotifyPropertyChanged
    {
        private readonly UserDataContext _context;

        public string Title => WindowData.StandardTitle;

        private Control accessControl;
        public Control AccessControl
        {
            get => accessControl;
            set
            {
                accessControl = value;
                OnControlPropertyChanged(nameof(AccessControl));
                OnPropertyChanged(nameof(Title));
            }
        }

        public IAccessControl WindowData => AccessControl as IAccessControl;

        public AccessControlManager()
        {
            _context = new UserDataContext();

            InitAuthenticationControl();
        }

        public event Action Closed;

        private void InitAuthenticationControl()
        {
            AccessControl = new AuthenticationControl();
            AuthenticationViewModel authenticationModel = AccessControl.DataContext as AuthenticationViewModel;
            authenticationModel.RegisteredButtonClick += AuthenticationModel_Registration;
            authenticationModel.AuthorizedButtonClick += AuthenticationModel_AuthorizedButtonClick; ;
            authenticationModel.RestoreAccessButtonClick += InitRestoreAccessControl;
            authenticationModel.GoogleAuthorized += GoogleAuth;
        }

        private void InitRegistrationControl(string email = "", string password = "")
        {
            AccessControl = new RegistrationControl(email, password);
            RegistrationViewModel registrationViewModel = AccessControl.DataContext as RegistrationViewModel;
            registrationViewModel.Backed += InitAuthenticationControl;
            registrationViewModel.Confirmation += InitConfirmationControl;
        }

        private void InitConfirmationControl(int code, string email, string password)
        {
            AccessControl = new ConfirmationControl(code, email, password);
            ConfirmationViewModel confirmationViewModel = AccessControl.DataContext as ConfirmationViewModel;
            confirmationViewModel.Backed += InitRegistrationControl;
            confirmationViewModel.Confirmed += RegistrationConfirm;
        }

        private void InitConfirmationControl(int code, string email)
        {
            AccessControl = new ConfirmationControl(code, email);
            RestoreConfirmationViewModel confirmationViewModel = AccessControl.DataContext as RestoreConfirmationViewModel;
            confirmationViewModel.Backed += InitRestoreAccessControl;
            confirmationViewModel.Confirmed += InitChangePasswordControl;
        }

        private void InitRestoreAccessControl()
        {
            AccessControl = new RestoreAccessControl();
            RestoreAccessViewModel restoreAccess = AccessControl.DataContext as RestoreAccessViewModel;
            restoreAccess.Backed += InitAuthenticationControl;
            restoreAccess.ConfirmationCodeSended += RestoreAccess_ConfirmationCodeSended;
        }

        private void InitRestoreAccessControl(string email)
        {
            AccessControl = new RestoreAccessControl(email);
            RestoreAccessViewModel restoreAccess = AccessControl.DataContext as RestoreAccessViewModel;
            restoreAccess.Backed += InitAuthenticationControl;
            restoreAccess.ConfirmationCodeSended += RestoreAccess_ConfirmationCodeSended;
        }

        private void InitChangePasswordControl(string email)
        {
            AccessControl = new ChangePasswordControl(email);
            ChangePasswordViewModel changePassword = AccessControl.DataContext as ChangePasswordViewModel;
            changePassword.BackButtonClicked += InitAuthenticationControl;
            changePassword.ChangePasswordButtonClicked += ChangePassword;
        }

        private void ChangePassword(string email, string password)
        {
            if (_context.ChangePassword(email, password) == true)
            {
                _context.AddLog(email, "Успешная смена пароля");
                InitAuthenticationControl();
                MessageBox.Show("Смена пароля успешна!");
            }
            else
            {
                _context.AddLog(email, "Неуспешная смена пароля");
                InitAuthenticationControl();
                MessageBox.Show("Смена пароля не успешна!");
            }
        }

        private void RestoreAccess_ConfirmationCodeSended(int code, string email)
        {
            _context.AddLog(email, "Попытка смены пароля");
            InitConfirmationControl(code, email);
        }

        private void SwitchToMainWindow(int userId)
        {
            MainWindow mainWindow = new(userId);
            mainWindow.Show();

            Closed?.Invoke();
        }

        private bool SwitchToMainWindow(string email)
        {
            UserDataContext context = new();
            int? userId = context.GetUserId(email);
            if (userId != null)
            {
                SwitchToMainWindow((int)userId);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SwitchToMainWindow(string email, string password)
        {
            UserDataContext context = new();
            int? userId = context.GetUserId(email, password);
            if (userId != null)
            {
                SwitchToMainWindow((int)userId);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GoogleAuth(string email)
        {
            if (_context.AuthorizeGoogleAccount(email))
            {
                _context.AddLog(email, "Google авторизация");
                SwitchToMainWindow(email);
            }
            else
            {
                _context.AddLog(email, "Попытка Google авторизации по этому email");
                MessageBox.Show("Аккаунт с такой почтой уже зарегистрирован.");
            }
        }

        private void AuthenticationModel_Registration()
        {
            InitRegistrationControl();
        }

        private void AuthenticationModel_AuthorizedButtonClick(string email, string password)
        {
            _context.AddLog(email, "Авторизация");
            SwitchToMainWindow(email, password);
        }

        private void HandleRegistrationFailure()
        {
            InitAuthenticationControl();
            MessageBox.Show("Регистрация не успешна!");
        }

        private void RegistrationConfirm(string email, string password)
        {
            if (_context.Registration(email, password) == true)
            {
                _context.AddLog(email, "Регистрация");
                bool isClosed = SwitchToMainWindow(email, password);

                if (isClosed == false)
                {
                    HandleRegistrationFailure();
                }
            }
            else
            {
                HandleRegistrationFailure();
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler ControlPropertyChanged;

        protected virtual void OnControlPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
