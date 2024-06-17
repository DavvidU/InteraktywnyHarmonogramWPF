using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.Helpers;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class TaskDetailsForDayViewModel : INotifyPropertyChanged
    {
        private readonly DayViewModel _dayViewModel;

        public Zadanie SelectedTask { get; set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand MarkAsCompletedCommand { get; private set; }

        public event Action ActionCompleted;

        public TaskDetailsForDayViewModel(Zadanie task, DayViewModel dayViewModel)
        {
            SelectedTask = task;
            _dayViewModel = dayViewModel;
            SaveCommand = new RelayCommand(SaveTask);
            DeleteCommand = new RelayCommand(DeleteTask);
            MarkAsCompletedCommand = new RelayCommand(MarkAsCompleted);
        }

        private void SaveTask()
        {
            var existingTask = DostepDoDanych.GetDzien(_dayViewModel.SelectedDate.Day, _dayViewModel.SelectedDate.Month, _dayViewModel.SelectedDate.Year)
                .GetZadania().FirstOrDefault(z => z.Equals(SelectedTask));

            if (existingTask != null)
            {
                existingTask.Naglowek = SelectedTask.Naglowek;
                existingTask.Opis = SelectedTask.Opis;
                existingTask.Pilne = SelectedTask.Pilne;
                existingTask.Wazne = SelectedTask.Wazne;
                existingTask.Wykonane = SelectedTask.Wykonane;
            }

            ActionCompleted?.Invoke();
        }

        private void DeleteTask()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć to zadanie?", "Potwierdzenie usunięcia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                _dayViewModel.TasksInSelectedDay.Remove(SelectedTask);
                DostepDoDanych.GetDzien(_dayViewModel.SelectedDate.Day, _dayViewModel.SelectedDate.Month, _dayViewModel.SelectedDate.Year).UsunZadanie(SelectedTask);
                MessageBox.Show("Zadanie zostało usunięte.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                ActionCompleted?.Invoke();
            }
        }

        private void MarkAsCompleted()
        {
            SelectedTask.Wykonane = true;
            SaveTask();
            MessageBox.Show("Zadanie ukończono pomyślnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            ActionCompleted?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
