using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BmiSample.Domain;

namespace BmiSample.Wpf
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region "Interface Implementaiton"
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private int? _heightCm;
        public int? HeightCm
        {
            get { return _heightCm; }
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
            get { return _weightKg; } 
            set 
            { 
                _weightKg = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(WeightKg)));
                CalculateBmi();
            } 
        }

        private double? _bmiIndex;
        public double? BmiIndex 
        { 
            get {return _bmiIndex; } 
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
            };
            if (!WeightKg.HasValue || WeightKg.Value <= 0) 
            {
                BmiIndex = 0.0;
                return;
            }
            var calculator = new BmiCalculator();
            BmiIndex = calculator.Calculate(HeightCm.Value, WeightKg.Value);
        }
    }
}
