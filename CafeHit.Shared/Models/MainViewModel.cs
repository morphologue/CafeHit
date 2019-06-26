using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace CafeHit.Shared.Models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _variant;
        private int _size;
        private int _milk;
        private int _dash;
        private int _sweetener;
        private bool _isProportionFullOne;
        private bool _isProportionFullHalf;
        private bool _isProportionFullThreeQuarters;
        private bool _isStrengthNormal;
        private bool _isStrengthStrong;
        private bool _isStrengthWeak;
        private bool _isTemperatureNormal;
        private bool _isTemperatureExtraHot;
        private bool _isTemperatureWarm;
        private bool _isCustomisationCaramel;
        private bool _isCustomisationHazelnut;
        private bool _isCustomisationExtraChoc;
        private bool _canOrder;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Reset();
        }

        public int Variant
        {
            get => _variant;
            set
            {
                if (value == _variant) return;
                _variant = value;
                OnPropertyChanged();
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                if (value == _size) return;
                _size = value;
                OnPropertyChanged();
            }
        }

        public int Milk
        {
            get => _milk;
            set
            {
                if (value == _milk) return;
                _milk = value;
                OnPropertyChanged();
            }
        }

        public int Dash
        {
            get => _dash;
            set
            {
                if (value == _dash) return;
                _dash = value;
                OnPropertyChanged();
            }
        }

        public int Sweetener
        {
            get => _sweetener;
            set
            {
                if (value == _sweetener) return;
                _sweetener = value;
                OnPropertyChanged();
            }
        }

        public bool IsProportionFullOne
        {
            get => _isProportionFullOne;
            set
            {
                if (value == _isProportionFullOne) return;
                _isProportionFullOne = value;
                OnPropertyChanged();
            }
        }

        public bool IsProportionFullHalf
        {
            get => _isProportionFullHalf;
            set
            {
                if (value == _isProportionFullHalf) return;
                _isProportionFullHalf = value;
                OnPropertyChanged();
            }
        }

        public bool IsProportionFullThreeQuarters
        {
            get => _isProportionFullThreeQuarters;
            set
            {
                if (value == _isProportionFullThreeQuarters) return;
                _isProportionFullThreeQuarters = value;
                OnPropertyChanged();
            }
        }

        public bool IsStrengthNormal
        {
            get => _isStrengthNormal;
            set
            {
                if (value == _isStrengthNormal) return;
                _isStrengthNormal = value;
                OnPropertyChanged();
            }
        }

        public bool IsStrengthStrong
        {
            get => _isStrengthStrong;
            set
            {
                if (value == _isStrengthStrong) return;
                _isStrengthStrong = value;
                OnPropertyChanged();
            }
        }

        public bool IsStrengthWeak
        {
            get => _isStrengthWeak;
            set
            {
                if (value == _isStrengthWeak) return;
                _isStrengthWeak = value;
                OnPropertyChanged();
            }
        }

        public bool IsTemperatureNormal
        {
            get => _isTemperatureNormal;
            set
            {
                if (value == _isTemperatureNormal) return;
                _isTemperatureNormal = value;
                OnPropertyChanged();
            }
        }

        public bool IsTemperatureExtraHot
        {
            get => _isTemperatureExtraHot;
            set
            {
                if (value == _isTemperatureExtraHot) return;
                _isTemperatureExtraHot = value;
                OnPropertyChanged();
            }
        }

        public bool IsTemperatureWarm
        {
            get => _isTemperatureWarm;
            set
            {
                if (value == _isTemperatureWarm) return;
                _isTemperatureWarm = value;
                OnPropertyChanged();
            }
        }

        public bool IsCustomisationCaramel
        {
            get => _isCustomisationCaramel;
            set
            {
                if (value == _isCustomisationCaramel) return;
                _isCustomisationCaramel = value;
                OnPropertyChanged();
            }
        }

        public bool IsCustomisationHazelnut
        {
            get => _isCustomisationHazelnut;
            set
            {
                if (value == _isCustomisationHazelnut) return;
                _isCustomisationHazelnut = value;
                OnPropertyChanged();
            }
        }

        public bool IsCustomisationExtraChoc
        {
            get => _isCustomisationExtraChoc;
            set
            {
                if (value == _isCustomisationExtraChoc) return;
                _isCustomisationExtraChoc = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public bool CanOrder
        {
            get => _canOrder;
            set
            {
                if (value == _canOrder) return;
                _canOrder = value;
                OnPropertyChanged();
            }
        }

        public void Reset()
        {
            Variant = 7;    // Latte
            Size = 1;       // Small
            Milk = 1;       // Full Cream
            Dash = 0;       // None
            Sweetener = 0;  // None
            IsProportionFullOne = true;
            IsProportionFullHalf = false;
            IsProportionFullThreeQuarters = false;
            IsStrengthNormal = true;
            IsStrengthStrong = false;
            IsStrengthWeak = false;
            IsTemperatureNormal = true;
            IsTemperatureExtraHot = false;
            IsTemperatureWarm = false;
            IsCustomisationCaramel = false;
            IsCustomisationHazelnut = false;
            IsCustomisationExtraChoc = false;
            CanOrder = true;
        }

        public void Set(MainViewModel other)
        {
            Variant = other.Variant;
            Size = other.Size;
            Milk = other.Milk;
            Dash = other.Dash;
            Sweetener = other.Sweetener;
            IsProportionFullOne = other.IsProportionFullOne;
            IsProportionFullHalf = other.IsProportionFullHalf;
            IsProportionFullThreeQuarters = other.IsProportionFullThreeQuarters;
            IsStrengthNormal = other.IsStrengthNormal;
            IsStrengthStrong = other.IsStrengthStrong;
            IsStrengthWeak = other.IsStrengthWeak;
            IsTemperatureNormal = other.IsTemperatureNormal;
            IsTemperatureExtraHot = other.IsTemperatureExtraHot;
            IsTemperatureWarm = other.IsTemperatureWarm;
            IsCustomisationCaramel = other.IsCustomisationCaramel;
            IsCustomisationHazelnut = other.IsCustomisationHazelnut;
            IsCustomisationExtraChoc = other.IsCustomisationExtraChoc;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
