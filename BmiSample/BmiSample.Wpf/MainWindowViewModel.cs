using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using BmiSample.Domain;

namespace BmiSample.Wpf
{
    /*

https://docs.microsoft.com/en-us/previous-versions/windows/silverlight/dotnet-windows-silverlight/ee652637(v=vs.95)?redirectedfrom=MSDN
http://nineworks2.blog.fc2.com/blog-entry-21.html
http://sourcechord.hatenablog.com/entry/2014/06/08/123738
http://sourcechord.hatenablog.com/entry/2014/06/14/204749
*/

    internal class MainWindowViewModel : INotifyPropertyChanged,INotifyDataErrorInfo
    {
        #region "events"
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion

        #region "poperties"

        #region "Interface Implementation"
        public bool HasErrors => _currentErrors.Count > 0;
        private readonly Dictionary<String, IList<String>> _currentErrors = new Dictionary<string, IList<string>>();
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

        #endregion

        #region "Methods"
        #region "Interface Implementation"
        public IEnumerable GetErrors(string propertyName)
        {
            if (!_currentErrors.ContainsKey(propertyName))
            {
                return null;
            }
            return _currentErrors[propertyName];
        }
        private void AddError(string propertyName,string error) 
        {
            if (_currentErrors.ContainsKey(propertyName)) 
            {
                _currentErrors.GetValueOrDefault(propertyName).Add(error);
            }
            else 
            {
                var errrors = new List<string> { error };
                _currentErrors.Add(propertyName, errrors);
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void RemoveError(string propertyName,string Error) 
        {
            _currentErrors.GetValueOrDefault(propertyName)?.Remove(Error);
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void SetErrors(string propertyName, IList<string> errors) 
        {
            if (_currentErrors.ContainsKey(propertyName)) 
            {
                _currentErrors[propertyName] = errors;
            } 
            else 
            {
                _currentErrors.Add(propertyName, errors);
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName) 
        {
            if (_currentErrors.ContainsKey(propertyName)) 
            {
                _currentErrors.Remove(propertyName);
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors() 
        {
            _currentErrors.Clear();
            ErrorsChanged(this, new DataErrorsChangedEventArgs(string.Empty));
        }
        
        #endregion
        private void CalculateBmi()
        {
            ClearErrors();
            if (!CheckInput()) 
            {
                BmiIndex = 0.0;
                return;
            }
            BmiCalculator calculator = new BmiCalculator();
            BmiIndex = calculator.Calculate(HeightCm.Value, WeightKg.Value);
        }
        private bool CheckInput() 
        {
            // 身長
            bool heightOk = CheckHeight();
            // 体重
            bool weightOk = CheckWeight();
            return heightOk && weightOk;
        }
        private bool CheckHeight() 
        {
            ClearErrors(nameof(HeightCm));
            if (!HeightCm.HasValue)
            {
                AddError(nameof(HeightCm), "身長を入力してください。");
                return false;
            }
            if(HeightCm.Value < 1 || 999 < HeightCm.Value) 
            {
                AddError(nameof(HeightCm), "身長は1～999で入力してください。");
                return false;
            }
            return true;

        }
        private bool CheckWeight() 
        {
            ClearErrors(nameof(WeightKg));
            if (!WeightKg.HasValue)
            {
                AddError(nameof(WeightKg), "体重を入力してください。");
                return false;
            }
            if (WeightKg.Value < 1 || 999 < WeightKg.Value)
            {
                AddError(nameof(WeightKg), "体重は1～999で入力してください。");
                return false;
            }
            return true;

        }
        #endregion

    }
}
