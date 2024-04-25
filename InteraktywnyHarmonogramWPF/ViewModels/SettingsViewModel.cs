using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private string selectedFont;

        public string SelectedFont
        {
            get { return selectedFont; }
            set
            {
                if (selectedFont != value)
                {
                    selectedFont = value;
                    OnPropertyChanged(nameof(SelectedFont));
                }
            }
        }

        public SettingsViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
