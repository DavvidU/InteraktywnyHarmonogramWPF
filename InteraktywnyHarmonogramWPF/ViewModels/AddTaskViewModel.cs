using InteraktywnyHarmonogramWPF.Models;
using System.ComponentModel;
using System.Windows.Input;
using InteraktywnyHarmonogramWPF.Helpers;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Navigation;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class AddTaskViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public string Sender { get; set; }
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
        public ICommand MarkAsCompletedCommand { get; set; }

        public AddTaskViewModel(string sender)
        {
            Sender = sender;

            if (sender == "PW" || sender == "PN")
                Pilne = true;
            else
                Pilne = false;

            if (sender == "PW" || sender == "NW")
                Wazne = true;
            else
                Wazne = false;

            SaveCommand = new RelayCommand(SaveTask);
        }

        public event Action<string, Zadanie> TaskSaved;

        private void SaveTask()
        {
            if (!IsNaglowekValid())
            {
                MessageBox.Show("Nagłówek może zawierać tylko litery i nie może być pusty.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newTask = new Zadanie(Naglowek, Opis, Pilne, Wazne, false);
            DostepDoDanych.AddZadanie(Sender, newTask);

            TaskSaved?.Invoke(Sender, newTask);
        }
        public string this[string columnName]
        {   
            get
            {
                if (columnName == nameof(Naglowek))
                {
                    if (string.IsNullOrWhiteSpace(Naglowek))
                        return "Nagłówek nie może być pusty.";
                    if (!Regex.IsMatch(Naglowek, @"^[a-zA-Z\s]+$"))
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
            if (!Regex.IsMatch(Naglowek, @"^[a-zA-Z\s]+$"))
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
