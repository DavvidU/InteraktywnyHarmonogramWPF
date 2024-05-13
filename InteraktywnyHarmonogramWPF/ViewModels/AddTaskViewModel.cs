using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    class AddTaskViewModel
    {
        public string sender;

        public ICommand SaveCommand { get; private set; }

        public AddTaskViewModel(string sender)
        {
            sender = this.sender;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
