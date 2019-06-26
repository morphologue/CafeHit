using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace CafeHit.Shared.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;
        private bool _isEnabled;

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

        [JsonIgnore]
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (value == _isEnabled) return;
                _isEnabled = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IsValid => IsEnabled && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);

        public void Reset()
        {
            UserName = "";
            Password = "";
            IsEnabled = true;
        }

        public void Set(LoginViewModel other)
        {
            UserName = other.UserName;
            Password = other.Password;
            IsEnabled = other.IsEnabled;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
