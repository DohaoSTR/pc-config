using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.Access
{
    public class ConfirmationViewModel : INotifyPropertyChanged
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

        private readonly int _generatedCode;
        private readonly string _email;
        private readonly string _password;

        public ConfirmationViewModel(int generatedCode, string email, string password)
        {
            _generatedCode = generatedCode;
            _email = email;
            _password = password;
        }

        public event Action<string, string> Backed;

        public ICommand BackCommand => new RelayCommand(Back);

        private void Back()
        {
            Backed?.Invoke(_email, _password);
        }

        public event Action<string, string> Confirmed;

        public ICommand ConfirmationCommand => new RelayCommand(Confirmation);

        private void Confirmation()
        {
            if (_generatedCode == Code)
            {
                Confirmed?.Invoke(_email, _password);
            }
            else
            {
                ConfirmationDescription = "Введен неверный код.";
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
