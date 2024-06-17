using InteraktywnyHarmonogramWPF.Models;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using InteraktywnyHarmonogramWPF.Helpers;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class AddTaskToDayViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public DateTime SelectedDate { get; set; }

        private string _naglowek;
        public string Naglowek
        {
            get { return _naglowek; }
            set
            {
                if (_naglowek != value)
                {
                    _naglowek = value;
                    OnPropertyChanged(nameof(Naglowek));
                }
            }
        }

        private string _opis;
        public string Opis
        {
            get { return _opis; }
            set
            {
                if (_opis != value)
                {
                    _opis = value;
                    OnPropertyChanged(nameof(Opis));
                }
            }
        }

        public bool Pilne { get; set; }
        public bool Wazne { get; set; }

        public ICommand SaveCommand { get; set; }

        public AddTaskToDayViewModel(DateTime selectedDate)
        {
            SelectedDate = selectedDate;
            SaveCommand = new RelayCommand(SaveTask);
        }

        public event Action<Zadanie> TaskSaved;

        private void SaveTask()
        {
            if (!IsNaglowekValid())
            {
                MessageBox.Show("Nagłówek może zawierać tylko litery i nie może być pusty.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newTask = new Zadanie(Naglowek, Opis, Pilne, Wazne, false);
            DostepDoDanych.AddTaskToDay(SelectedDate.Day, SelectedDate.Month, SelectedDate.Year, newTask);

            TaskSaved?.Invoke(newTask);
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Naglowek))
                {
                    if (string.IsNullOrWhiteSpace(Naglowek))
                        return "Nagłówek nie może być pusty.";
                    if (!Regex.IsMatch(Naglowek, @"^[a-zA-Z\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$"))
                        return "Nagłówek może zawierać tylko litery.";
                }
                return null;
            }
        }

        public string Error => null;

        private bool IsNaglowekValid()
        {
            if (string.IsNullOrWhiteSpace(Naglowek))
                return false;
            if (!Regex.IsMatch(Naglowek, @"^[a-zA-Z\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$"))
                return false;
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
