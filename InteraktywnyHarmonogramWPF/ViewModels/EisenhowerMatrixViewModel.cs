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
    class EisenhowerMatrixViewModel : INotifyPropertyChanged
    {
        public List<Zadanie> PilneWazneZadania { get; set; }
        public List<Zadanie> NiepilneWazneZadania { get; set; }
        public List<Zadanie> PilneNiewazneZadania { get; set; }
        public List<Zadanie> NiepilneNiewazneZadania { get; set; }

        public EisenhowerMatrixViewModel()
        {
            PilneWazneZadania = DostepDoDanych.GetZadania("PW");
            NiepilneWazneZadania = DostepDoDanych.GetZadania("NW");
            PilneNiewazneZadania = DostepDoDanych.GetZadania("PN");
            NiepilneNiewazneZadania = DostepDoDanych.GetZadania("NN");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Tutaj dodaj metody do zarządzania zadaniami
    }
}
