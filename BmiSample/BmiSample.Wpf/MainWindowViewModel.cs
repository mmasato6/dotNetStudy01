using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
            set { _heightCm = value; }
        }
        private int? _weightKg;
        public int? WeightKg 
        { 
            get { return _weightKg; } 
            set { _weightKg = value; } 
        }

        public double? BmiIndex 
        { 
            get 
            {
                return 0.0;
            }
        }

        private void CalculateBmi() 
        {
        }
    }
}
