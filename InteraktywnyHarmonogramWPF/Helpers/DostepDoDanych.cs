using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    class DostepDoDanych
    {
        public static List<Zadanie> GetZadania(int dzien, int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadan tw = TworzenieEdycjaUsuwanieZadan.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].GetZadania();
        }
        public static List<Zadanie> GetZadania(string kategoria)
        {
            Macierz macierz = Macierz.GetMacierz();

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
    }
}
