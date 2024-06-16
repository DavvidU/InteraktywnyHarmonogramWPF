using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    class DostepDoDanych
    {
        private static Macierz macierz = Macierz.GetMacierz();
        public static ObservableCollection<Zadanie> GetZadania(string kategoria)
        {
            if (kategoria == "PW")
                return macierz.PilneWazne;
            else if (kategoria == "NW")
                return macierz.NiepilneWazne;
            else if (kategoria == "PN")
                return macierz.PilneNiewazne;
            else if (kategoria == "NN")
                return macierz.NiepilneNiewazne;
            else
                return macierz.PilneWazne;
        }
        public static List<Zadanie> GetZadania(int dzien, int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadan tw = TworzenieEdycjaUsuwanieZadan.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].GetZadania();
        }

        public static Dzien GetDzien(int dzien, int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadan tw = TworzenieEdycjaUsuwanieZadan.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1];
        }

        public static Miesiac GetMiesiac(int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadan tw = TworzenieEdycjaUsuwanieZadan.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1];
        }

        public static void AddZadanie(string kategoria, Zadanie zadanie)
        {
            if (kategoria == "PW")
                macierz.PilneWazne.Add(zadanie);
            else if (kategoria == "NW")
                macierz.NiepilneWazne.Add(zadanie);
            else if (kategoria == "PN")
                macierz.PilneNiewazne.Add(zadanie);
            else if (kategoria == "NN")
                macierz.NiepilneNiewazne.Add(zadanie);
        }
    }
}
