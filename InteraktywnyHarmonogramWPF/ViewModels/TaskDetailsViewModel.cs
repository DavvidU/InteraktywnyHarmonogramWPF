using InteraktywnyHarmonogramWPF.Models;
using InteraktywnyHarmonogramWPF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    class TaskDetailsViewModel : INotifyPropertyChanged
    {
        public Zadanie SelectedTask { get; set; }

        public ICommand SaveCommand { get; private set; }

        public TaskDetailsViewModel(Zadanie task)
        {
            SelectedTask = task;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
