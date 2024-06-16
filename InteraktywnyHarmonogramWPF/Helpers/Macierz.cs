using InteraktywnyHarmonogramWPF.Models;
using System.Collections.ObjectModel;
using InteraktywnyHarmonogramWPF.ViewModels;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    public class Macierz
    {
        public static Macierz instance;

        public static Macierz GetMacierz()
        {
            if (instance == null)
                instance = new Macierz();
            return instance;
        }

        public ObservableCollection<Zadanie> PilneWazne { get; set; }
        public ObservableCollection<Zadanie> NiepilneWazne { get; set; }
        public ObservableCollection<Zadanie> PilneNiewazne { get; set; }
        public ObservableCollection<Zadanie> NiepilneNiewazne { get; set; }

        private Macierz()
        {
            PilneWazne = new ObservableCollection<Zadanie>();
            NiepilneWazne = new ObservableCollection<Zadanie>();
            PilneNiewazne = new ObservableCollection<Zadanie>();
            NiepilneNiewazne = new ObservableCollection<Zadanie>();
        }
        public void DodajZadanie(string[] dane, string kategoria)
        {
            var zadanie = new Zadanie(dane[1], dane[2], dane[3] == "1", dane[4] == "1", dane[5] == "1");

            if (kategoria == "PW")
                PilneWazne.Add(zadanie);
            else if (kategoria == "NW")
                NiepilneWazne.Add(zadanie);
            else if (kategoria == "PN")
                PilneNiewazne.Add(zadanie);
            else if (kategoria == "NN")
                NiepilneNiewazne.Add(zadanie);
        }

        public void UsunZadanie(Zadanie zadanieDoUsuniecia, string kategoria)
        {
            if (kategoria == "PW")
                PilneWazne.Remove(zadanieDoUsuniecia);
            else if (kategoria == "NW")
                NiepilneWazne.Remove(zadanieDoUsuniecia);
            else if (kategoria == "PN")
                PilneNiewazne.Remove(zadanieDoUsuniecia);
            else if (kategoria == "NN")
                NiepilneNiewazne.Remove(zadanieDoUsuniecia);
        }

        public void EdytujZadanie(string[] noweDane, Zadanie zadanieDoEdycji, string kategoria)
        {
            UsunZadanie(zadanieDoEdycji, kategoria);
            DodajZadanie(noweDane, kategoria);
        }
    }
}
