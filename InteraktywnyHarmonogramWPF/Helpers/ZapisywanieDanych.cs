using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    class ZapisywanieDanych
    {
        private static ZapisywanieDanych instance = new ZapisywanieDanych();
        private ZapisywanieDanych() { }
        public void ZapiszKalendarz()
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            foreach (Rok rok in kalendarz.lata)
            {
                ZapiszRok(rok);
            }
        }
        public void ZapiszMacierz()
        {
            // Ostatni istniejacy wiersz pliku (kat. "NN") powinien byc zapisany nie "WriteLine()" a "Write()"
            Macierz macierz = Macierz.GetMacierz();

            StreamWriter writer = new StreamWriter("macierz.txt");

            string wierszKategorii;
            string wierszZadania;
            int ktoreZadanieZapisuje;

            string akronimKategorii;

            List<Zadanie> zadaniaTejKategorii;
            for (int i = 0; i < 4; ++i)
            {
                if (i == 0)
                {
                    zadaniaTejKategorii = macierz.PilneWazne;
                    akronimKategorii = "PW";
                }
                else if (i == 1)
                {
                    zadaniaTejKategorii = macierz.NiepilneWazne;
                    akronimKategorii = "NW";
                }
                else if (i == 2)
                {
                    zadaniaTejKategorii = macierz.PilneNiewazne;
                    akronimKategorii = "PN";
                }
                else // i == 3
                {
                    zadaniaTejKategorii = macierz.NiepilneNiewazne;
                    akronimKategorii = "NN";
                }

                //Sformatuj wierszKategorii
                wierszKategorii = "";
                wierszKategorii += "%%$#!";
                wierszKategorii += akronimKategorii;
                wierszKategorii += "%%@@";

                //Zapisz wiersz kategorii (uwzglednij czy to ostatni wiersz w pliku)
                if (i == 3 && zadaniaTejKategorii.Count == 0) //if (ostatnia kat. i nie ma zadan)
                    writer.Write(wierszKategorii);
                else
                    writer.WriteLine(wierszKategorii);

                ktoreZadanieZapisuje = 0;

                //Zapisz naglowek kateegorii i wszystkie jej zadania (z odpowiednim uwzgl. ostatniej linii pliku)
                foreach (Zadanie zadanie in zadaniaTejKategorii)
                {
                    ktoreZadanieZapisuje++;

                    // Sformatuj wierszZadania
                    wierszZadania = "";

                    wierszZadania += "%%+!";
                    wierszZadania += zadanie.Naglowek;

                    wierszZadania += "%%+!";
                    wierszZadania += zadanie.Opis;

                    wierszZadania += "%%+!";
                    if (zadanie.Pilne)
                        wierszZadania += "1";
                    else
                        wierszZadania += "0";

                    wierszZadania += "%%+!";
                    if (zadanie.Wazne)
                        wierszZadania += "1";
                    else
                        wierszZadania += "0";

                    wierszZadania += "%%+!";
                    if (zadanie.Wykonane)
                        wierszZadania += "1";
                    else
                        wierszZadania += "0";

                    wierszZadania += "%%@@";

                    // Zapisz wierszZadania - uzyj write, jesli ma to byc ostatni wiersz w macierzy
                    if (i == 3 && ktoreZadanieZapisuje == zadaniaTejKategorii.Count) //if (ostatnia kat. i ost. zad.)
                        writer.Write(wierszZadania);
                    else
                        writer.WriteLine(wierszZadania);
                }
            }
            writer.Close();
        }
        public void ZapiszRok(Rok rok)
        {
            // Ostatni istniejacy wiersz w pliku nalezy zapisac uzywajac "Write()" a nie "WriteLine()" !
            string sciezkaPliku = "";
            sciezkaPliku += rok.GetRok().ToString();
            sciezkaPliku += ".txt";

            StreamWriter writer = new StreamWriter(sciezkaPliku);

            string wierszDaty;
            string wierszZadania;
            int ktoreZadanieZapisuje;

            //Zawsze istnieje 12 miesiecy w roku
            foreach (Miesiac miesiac in rok.GetMiesiace())
            {
                //Zawsze istnieja dni w miesiacu (moze bez zadan, ale istnieja)
                foreach (Dzien dzien in miesiac.GetDni())
                {
                    wierszDaty = "%%$#!";
                    wierszDaty += WyznaczString(miesiac.GetMiesiac()); // WS(9) == "09"
                    wierszDaty += ".";
                    //wierszDaty == "%%$#!XX."

                    /* Dla kazdego dnia w miesiacu:
                     * najpierw zapisz wierszDaty,
                     * potem zapisz wszystkie zdania (jesli sa)
                     */
                    wierszDaty += WyznaczString(dzien.GetDzien()); // wierszDaty == "%%$#!XX.YY
                    wierszDaty += "%%@@"; // wierszDaty == "%%$#!XX.YY%%@@"

                    // Zapisz wiersz daty (Jesli to ostatni wiersz pliku, zapisz bez znaku nowej linii)
                    if (miesiac.GetMiesiac() == 12 && dzien.GetDzien() == 31
                        && dzien.GetZadania().Count == 0)
                        writer.Write(wierszDaty);
                    else
                        writer.WriteLine(wierszDaty);

                    ktoreZadanieZapisuje = 0;
                    //Zapisz wszystkie zadania (jesli zadanie jest ostatnim wierszem pliku, zapisz bez nowej linii)
                    foreach (Zadanie zadanie in dzien.GetZadania())
                    {
                        ktoreZadanieZapisuje++;

                        // Sformatuj wierszZadania
                        wierszZadania = "";

                        wierszZadania += "%%+!";
                        wierszZadania += zadanie.Naglowek;

                        wierszZadania += "%%+!";
                        wierszZadania += zadanie.Opis;

                        wierszZadania += "%%+!";
                        if (zadanie.Pilne)
                            wierszZadania += "1";
                        else
                            wierszZadania += "0";

                        wierszZadania += "%%+!";
                        if (zadanie.Wazne)
                            wierszZadania += "1";
                        else
                            wierszZadania += "0";

                        wierszZadania += "%%+!";
                        if (zadanie.Wykonane)
                            wierszZadania += "1";
                        else
                            wierszZadania += "0";

                        wierszZadania += "%%@@";

                        // Zapisz wierszZadania - uzyj write, jesli ma to byc ostatni wiersz w roku
                        if (miesiac.GetMiesiac() == 12 && dzien.GetDzien() == 31
                            && ktoreZadanieZapisuje == dzien.GetZadania().Count)
                            writer.Write(wierszZadania);
                        else
                            writer.WriteLine(wierszZadania);
                    }

                }
            }
            writer.Close();
        }
        private string WyznaczString(int i)
        {
            string stringDoWyznaczenia = "";

            if (i < 10)
                stringDoWyznaczenia += "0";

            stringDoWyznaczenia += i.ToString();

            return stringDoWyznaczenia;
        }
        public static ZapisywanieDanych GetInstance() { return instance; }
    }
}
