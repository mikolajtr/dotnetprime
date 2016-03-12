using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using MillerRabin.Sample.Annotations;

namespace MillerRabin.Sample.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private BigInteger _minValue;
        private BigInteger _maxValue;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BigInteger MinValue
        {
            get { return _minValue; }
            set { _minValue = value; OnPropertyChanged(nameof(MinValue)); }
        }

        public BigInteger MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; OnPropertyChanged(nameof(MaxValue));}
        }
    }
}
