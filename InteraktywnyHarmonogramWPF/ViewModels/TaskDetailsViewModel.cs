using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.Helpers;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class TaskDetailsViewModel : INotifyPropertyChanged
    {
        private readonly string _kategoria;
        private readonly EisenhowerMatrixViewModel _matrixViewModel;

        public Zadanie SelectedTask { get; set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand MarkAsCompletedCommand { get; private set; }

        public event Action ActionCompleted;

        public TaskDetailsViewModel(Zadanie task, string kategoria, EisenhowerMatrixViewModel matrixViewModel)
        {
            SelectedTask = task;
            _kategoria = kategoria;
            _matrixViewModel = matrixViewModel;
            SaveCommand = new RelayCommand(SaveTask);
            DeleteCommand = new RelayCommand(DeleteTask);
            MarkAsCompletedCommand = new RelayCommand(MarkAsCompleted);
        }

        private void SaveTask()
        {
            _matrixViewModel.UpdateZadanie(SelectedTask, _kategoria);
            ActionCompleted?.Invoke();
        }

        private void DeleteTask()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć to zadanie?", "Potwierdzenie usunięcia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                _matrixViewModel.RemoveZadanie(SelectedTask, _kategoria);
                MessageBox.Show("Zadanie zostało usunięte.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                ActionCompleted?.Invoke();
            }
        }

        private void MarkAsCompleted()
        {
            SelectedTask.Wykonane = true;
            _matrixViewModel.RemoveZadanie(SelectedTask, _kategoria);
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
