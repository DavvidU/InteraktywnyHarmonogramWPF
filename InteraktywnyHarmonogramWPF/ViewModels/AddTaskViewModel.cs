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

        public bool Pilne { get; set; }

        public bool Wazne { get; set; }

        public ICommand SaveCommand { get; private set; }

        public AddTaskViewModel(string sender)
        {
            this.sender = sender;

            if (sender == "PW" || sender == "PN")
                Pilne = true;
            else
                Pilne = false;

            if (sender == "PW" || sender == "NW")
                Wazne = true;
            else
                Wazne = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
