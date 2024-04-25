using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using InteraktywnyHarmonogramWPF.Helpers;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly Frame mainContent;

        public MainWindowViewModel(Frame mainContent)
        {
            this.mainContent = mainContent;
        }

        public ICommand NavigateCommand => new RelayCommand<string>(Navigate);

        private void Navigate(string viewName)
        {
            switch (viewName)
            {
                case "EisenhowerMatrix":
                    mainContent.Navigate(new EisenhowerMatrixPage());
                    break;
                case "Calendar":
                    mainContent.Navigate(new CalendarPage());
                    break;
                case "Settings":
                    mainContent.Navigate(new SettingsPage());
                    break;
                case "Save":
                    ZapisywanieDanych zD = ZapisywanieDanych.GetInstance();
                    zD.ZapiszKalendarz();
                    zD.ZapiszMacierz();
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
