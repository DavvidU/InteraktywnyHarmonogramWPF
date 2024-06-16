using InteraktywnyHarmonogramWPF.Helpers;
using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class DayViewModel : INotifyPropertyChanged
    {
        public DateTime SelectedDate { get; set; }
        public ObservableCollection<Zadanie> TasksInSelectedDay { get; set; }

        public DayViewModel(DateTime selectedDate)
        {
            SelectedDate = selectedDate;
            TasksInSelectedDay = new ObservableCollection<Zadanie>();

            // Load tasks from the data source for the selected date
            var day = DostepDoDanych.GetDzien(SelectedDate.Day, SelectedDate.Month, SelectedDate.Year);
            foreach (var task in day.GetZadania())
            {
                TasksInSelectedDay.Add(task);
            }
        }

        public void AddTask(Zadanie newTask)
        {
            var day = DostepDoDanych.GetDzien(SelectedDate.Day, SelectedDate.Month, SelectedDate.Year);
            day.DodajZadanie(new string[] { "", newTask.Naglowek, newTask.Opis, newTask.Pilne ? "1" : "0", newTask.Wazne ? "1" : "0", newTask.Wykonane ? "1" : "0" });

            TasksInSelectedDay.Add(newTask);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
