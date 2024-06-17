using InteraktywnyHarmonogramWPF.Helpers;
using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class DayViewModel : INotifyPropertyChanged
    {
        public DateTime SelectedDate { get; set; }

        private ObservableCollection<Zadanie> _tasksInSelectedDay;
        public ObservableCollection<Zadanie> TasksInSelectedDay
        {
            get { return _tasksInSelectedDay; }
            set
            {
                if (_tasksInSelectedDay != value)
                {
                    _tasksInSelectedDay = value;
                    OnPropertyChanged(nameof(TasksInSelectedDay));
                }
            }
        }

        private ICollectionView _tasksView;
        public ICollectionView TasksView
        {
            get { return _tasksView; }
            set
            {
                if (_tasksView != value)
                {
                    _tasksView = value;
                    OnPropertyChanged(nameof(TasksView));
                }
            }
        }

        public DayViewModel(DateTime selectedDate)
        {
            SelectedDate = selectedDate;
            TasksInSelectedDay = new ObservableCollection<Zadanie>();

            var day = DostepDoDanych.GetDzien(SelectedDate.Day, SelectedDate.Month, SelectedDate.Year);
            foreach (var task in day.GetZadania())
            {
                TasksInSelectedDay.Add(task);
            }

            TasksView = CollectionViewSource.GetDefaultView(TasksInSelectedDay);
            TasksView.SortDescriptions.Add(new SortDescription(nameof(Zadanie.Pilne), ListSortDirection.Descending));
            TasksView.SortDescriptions.Add(new SortDescription(nameof(Zadanie.Wazne), ListSortDirection.Descending));
        }

        public void AddTask(Zadanie newTask)
        {
            var day = DostepDoDanych.GetDzien(SelectedDate.Day, SelectedDate.Month, SelectedDate.Year);
            day.DodajZadanie(new string[] { "", newTask.Naglowek, newTask.Opis, newTask.Pilne ? "1" : "0", newTask.Wazne ? "1" : "0", newTask.Wykonane ? "1" : "0" });

            TasksInSelectedDay.Add(newTask);
            TasksView.Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
