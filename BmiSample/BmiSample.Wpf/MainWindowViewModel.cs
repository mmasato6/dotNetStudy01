using System.ComponentModel;
using BmiSample.Domain;

namespace BmiSample.Wpf
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region "Interface Implementaiton"
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private int? _heightCm;
        public int? HeightCm
        {
            get => _heightCm;
            set
            {
                _heightCm = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HeightCm)));
                CalculateBmi();
            }
        }
        private int? _weightKg;
        public int? WeightKg
        {
            get => _weightKg;
            set
            {
                _weightKg = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(WeightKg)));
                CalculateBmi();
            }
        }

        private double? _bmiIndex = 0.0;
        public double? BmiIndex
        {
            get => _bmiIndex;
            private set
            {
                _bmiIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(BmiIndex)));
            }
        }

        private void CalculateBmi()
        {
            if (!HeightCm.HasValue || HeightCm.Value <= 0) 
            {
                BmiIndex = 0.0;
                return;
            }
            if (!WeightKg.HasValue || WeightKg.Value <= 0) 
            {
                BmiIndex = 0.0;
                return;
            }
            BmiCalculator calculator = new BmiCalculator();
            BmiIndex = calculator.Calculate(HeightCm.Value, WeightKg.Value);
        }
    }
}
