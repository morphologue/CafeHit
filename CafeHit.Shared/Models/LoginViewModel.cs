using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CafeHit.Shared.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            Reset();
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (value == _userName) return;
                _userName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IsValid => !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);

        public void Reset()
        {
            UserName = "";
            Password = "";
        }

        public void Set(LoginViewModel other)
        {
            UserName = other.UserName;
            Password = other.Password;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
