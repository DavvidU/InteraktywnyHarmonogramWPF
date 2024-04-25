using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Models
{
    class Macierz
    {
        private static Macierz macierz = new Macierz();
        public List<Zadanie> PilneWazne = new List<Zadanie>();
        public List<Zadanie> NiepilneWazne = new List<Zadanie>();
        public List<Zadanie> PilneNiewazne = new List<Zadanie>();
        public List<Zadanie> NiepilneNiewazne = new List<Zadanie>();

        private Macierz() { }
        public static Macierz GetMacierz() { return macierz; }
        public void DodajZadanie(string[] daneZadania, string kategorie)
        {
            if (kategorie == "PW")
                PilneWazne.Add(new Zadanie(daneZadania[1], daneZadania[2],
                    daneZadania[3] == "1", daneZadania[4] == "1", daneZadania[5] == "1"));
            if (kategorie == "NW")
                NiepilneWazne.Add(new Zadanie(daneZadania[1], daneZadania[2],
                    daneZadania[3] == "1", daneZadania[4] == "1", daneZadania[5] == "1"));
            if (kategorie == "PN")
                PilneNiewazne.Add(new Zadanie(daneZadania[1], daneZadania[2],
                    daneZadania[3] == "1", daneZadania[4] == "1", daneZadania[5] == "1"));
            if (kategorie == "NN")
                NiepilneNiewazne.Add(new Zadanie(daneZadania[1], daneZadania[2],
                    daneZadania[3] == "1", daneZadania[4] == "1", daneZadania[5] == "1"));
        }
        public void UsunZadanie(Zadanie templateZadaniaDoUsuniecia, string kategorie)
        {
            // Zlokalizuj zadanie
            Zadanie zadanieDoUsuniecia = ZlokalizujZadanie(templateZadaniaDoUsuniecia, kategorie);
            if (zadanieDoUsuniecia == null)
                return;

            // Usun zadanie
            List<Zadanie> listaZZadaniem = PobierzListeZadanKategorii(kategorie);
            listaZZadaniem.Remove(zadanieDoUsuniecia);

        }
        public void EdytujZadanie(string[] noweDaneZadania, Zadanie templateZadaniaDoEdycji, string kategorie)
        {
            // Zlokalizuj zadanie
            Zadanie zadanieDoEdycji = ZlokalizujZadanie(templateZadaniaDoEdycji, kategorie);
            if (zadanieDoEdycji == null)
                return;

            // Edytuj zadanie
            zadanieDoEdycji.Naglowek = noweDaneZadania[1];
            zadanieDoEdycji.Opis = noweDaneZadania[2];
            zadanieDoEdycji.Pilne = noweDaneZadania[3] == "1";
            zadanieDoEdycji.Wazne = noweDaneZadania[4] == "1";
            zadanieDoEdycji.Wykonane = noweDaneZadania[5] == "1";
        }
        private Zadanie ZlokalizujZadanie(Zadanie templateDoZlokalizowania, string kategorie)
        {
            List<Zadanie> zadaniaOdpowiedniejKategorii = PobierzListeZadanKategorii(kategorie);

            Zadanie zadanieDoZlokalizowania = null;
            foreach (Zadanie zadanie in zadaniaOdpowiedniejKategorii)
            {
                if (zadanie.Equals(templateDoZlokalizowania))
                    zadanieDoZlokalizowania = zadanie;
            }
            return zadanieDoZlokalizowania;
        }
        public List<Zadanie> PobierzListeZadanKategorii(string kategorie)
        {
            if (kategorie == "PW")
                return PilneWazne;
            else if (kategorie == "NW")
                return NiepilneWazne;
            else if (kategorie == "PN")
                return PilneNiewazne;
            else
                return NiepilneNiewazne;
        }
    }
}
