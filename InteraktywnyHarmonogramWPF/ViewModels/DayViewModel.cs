using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktywnyHarmonogramWPF.Helpers;
using InteraktywnyHarmonogramWPF.Models;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    class DayViewModel : INotifyPropertyChanged
    {
        public string SelectedDate { get; set; }
        public List<Zadanie> TasksInSelectedDay { get; set; }
        public DayViewModel(DateTime dt) 
        {
            SelectedDate = dt.ToShortDateString();
            TasksInSelectedDay = DostepDoDanych.GetZadania(dt.Day, dt.Month, dt.Year);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
