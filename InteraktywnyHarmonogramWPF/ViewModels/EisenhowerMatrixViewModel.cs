using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktywnyHarmonogramWPF.Helpers;
using InteraktywnyHarmonogramWPF.Models;

namespace InteraktywnyHarmonogramWPF.ViewModels
{
    public class EisenhowerMatrixViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Zadanie> PilneWazneZadania { get; set; }
        public ObservableCollection<Zadanie> NiepilneWazneZadania { get; set; }
        public ObservableCollection<Zadanie> PilneNiewazneZadania { get; set; }
        public ObservableCollection<Zadanie> NiepilneNiewazneZadania { get; set; }

        public EisenhowerMatrixViewModel()
        {
            PilneWazneZadania = DostepDoDanych.GetZadania("PW");
            NiepilneWazneZadania = DostepDoDanych.GetZadania("NW");
            PilneNiewazneZadania = DostepDoDanych.GetZadania("PN");
            NiepilneNiewazneZadania = DostepDoDanych.GetZadania("NN");
        }

        public void RegisterAddTaskViewModel(AddTaskViewModel addTaskViewModel)
        {
            addTaskViewModel.TaskSaved += AddZadanie;
        }

        private void AddZadanie(string category,Zadanie zadanie)
        {
            switch (category)
            {
                case "PW":
                    PilneWazneZadania.Add(zadanie);
                    break;
                case "NW":
                    NiepilneWazneZadania.Add(zadanie);
                    break;
                case "PN":
                    PilneNiewazneZadania.Add(zadanie);
                    break;
                case "NN":
                    NiepilneNiewazneZadania.Add(zadanie);
                    break;
            }
        }
        public void RemoveZadanie(Zadanie zadanie, string category)
        {
            switch (category)
            {
                case "PW":
                    PilneWazneZadania.Remove(zadanie);
                    break;
                case "NW":
                    NiepilneWazneZadania.Remove(zadanie);
                    break;
                case "PN":
                    PilneNiewazneZadania.Remove(zadanie);
                    break;
                case "NN":
                    NiepilneNiewazneZadania.Remove(zadanie);
                    break;
            }
            OnPropertyChanged(nameof(PilneWazneZadania));
            OnPropertyChanged(nameof(NiepilneWazneZadania));
            OnPropertyChanged(nameof(PilneNiewazneZadania));
            OnPropertyChanged(nameof(NiepilneNiewazneZadania));
        }

        public void UpdateZadanie(Zadanie task, string category)
        {
            RemoveZadanie(task, category);
            AddZadanie(category, task);
            OnPropertyChanged(nameof(PilneWazneZadania));
            OnPropertyChanged(nameof(NiepilneWazneZadania));
            OnPropertyChanged(nameof(PilneNiewazneZadania));
            OnPropertyChanged(nameof(NiepilneNiewazneZadania));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

