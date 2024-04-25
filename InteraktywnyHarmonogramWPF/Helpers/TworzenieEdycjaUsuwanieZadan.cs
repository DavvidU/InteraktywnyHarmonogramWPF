using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    class TworzenieEdycjaUsuwanieZadan
    {
        private static TworzenieEdycjaUsuwanieZadan instance = new TworzenieEdycjaUsuwanieZadan();
        private TworzenieEdycjaUsuwanieZadan() { }
        public void DodajZadanieDoMacierzy(string[] daneZadania, string kategorie)
        {
            /* Dynamiczne dodanie zadania poelga na:
             * a) dodaniu zadania do pamieci programu
             * b) zapisania pamieci (macierzy) programu do pliku
             */

            // Dodanie zadania do pamieci programu
            Macierz macierz = Macierz.GetMacierz();
            macierz.DodajZadanie(daneZadania, kategorie);

            //Zapisanie pamieci do pliku
            ZapisywanieDanych ZDController = ZapisywanieDanych.GetInstance();
            ZDController.ZapiszMacierz();
        }
        public void DodajZadanieDoKalendarza(string[] daneZadania, int dzien, int miesiac, int rok)
        {
            /* Dynamiczne dodanie zadania polega na:
             * a) dodaniu zadania do pamieci programu
             * b) zpaisania pamieci (roku) do pliku
             */

            // Zlokalizuj rok w pamieci programu
            Rok rokZapisu = ZlokalizujRokWPamieci(rok);

            // Dodaj zadanie do pamieci programu
            rokZapisu.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].DodajZadanie(daneZadania);

            // Zapisz rok z RAM do pliku
            ZapisywanieDanych ZDController = ZapisywanieDanych.GetInstance();
            ZDController.ZapiszRok(rokZapisu);
        }
        public void UsunZadanieZMacierzy(Zadanie templateZadaniaDoUsuniecia, string kategorie)
        {
            Macierz macierz = Macierz.GetMacierz();

            //Usun zadanie z pamieci
            macierz.UsunZadanie(templateZadaniaDoUsuniecia, kategorie);

            // Zapisz macierz z RAM do pliku
            ZapisywanieDanych ZDController = ZapisywanieDanych.GetInstance();
            ZDController.ZapiszMacierz();
        }
        public void UsunZadanieZKalendarza(Zadanie templateZadaniaDoUsuniecia, int dzien, int miesiac, int rok)
        {
            Rok rokUsuniecia = ZlokalizujRokWPamieci(rok);

            // Usun zadanie z pamieci
            rokUsuniecia.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].UsunZadanie(templateZadaniaDoUsuniecia);

            // Zapisz rok z RAM do pliku
            ZapisywanieDanych ZDController = ZapisywanieDanych.GetInstance();
            ZDController.ZapiszRok(rokUsuniecia);
        }
        public void EdytujZadanieWMacierzy(string[] noweDaneZadania, Zadanie templateZadaniaDoEdycji, string kategorie)
        {
            Macierz macierz = Macierz.GetMacierz();

            // Edytuj zadanie w pamieci
            macierz.EdytujZadanie(noweDaneZadania, templateZadaniaDoEdycji, kategorie);

            // Zapisz macierz z RAM do pliku
            ZapisywanieDanych ZDController = ZapisywanieDanych.GetInstance();
            ZDController.ZapiszMacierz();
        }
        public void EdytujZadanieWKalendarzu(string[] noweDaneZadania, Zadanie templateZadaniaDoEdycji,
            int dzien, int miesiac, int rok)
        {
            Rok rokUsuniecia = ZlokalizujRokWPamieci(rok);

            // Edytuj zadanie w pamieci
            rokUsuniecia.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].EdytujZadanie(noweDaneZadania,
                templateZadaniaDoEdycji);

            // Zapisz rok z RAM do pliku
            ZapisywanieDanych ZDController = ZapisywanieDanych.GetInstance();
            ZDController.ZapiszRok(rokUsuniecia);
        }
        public Rok ZlokalizujRokWPamieci(int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            LinkedList<Rok> lata = kalendarz.lata;
            LinkedListNode<Rok> rokZapisuNode = lata.First;
            for (int i = 0; i < kalendarz.lata.Count; ++i)
            {
                if (rokZapisuNode.Value.GetRok() == rok)
                    break;
                rokZapisuNode = rokZapisuNode.Next;
            }
            Rok rokZapisu = rokZapisuNode.Value;

            return rokZapisu;
        }
        public static TworzenieEdycjaUsuwanieZadan GetInstance() { return instance; }
    }
}
