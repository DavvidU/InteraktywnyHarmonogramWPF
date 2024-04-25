using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    class WczytywanieDanych
    {
        private static WczytywanieDanych instance = new WczytywanieDanych();
        private WczytywanieDanych() { }
        public bool ZaladujRokLubMacierz(Rok? rok, string typPliku)
        {
            if (rok == null && typPliku == "rok") { return false; }
            if (typPliku == null) { return false; };

            Macierz macierz = Macierz.GetMacierz();
            string sciezkaPliku;
            if (typPliku == "rok")
                sciezkaPliku = rok.GetRok() + ".txt";
            else
                sciezkaPliku = "macierz.txt";

            try
            {

                using (StreamReader sr = new StreamReader(sciezkaPliku))
                {
                    string wierszFizyczny; //rzeczywisty jeden wiersz w pliku
                    string wierszLogiczny = ""; //blok wierszy rzeczywistych obejmujacy jedno zadanie

                    string miesiac = "";
                    string dzien = "";
                    string kategorie = "";

                    string[] daneDoZapisu = new string[6];

                    // Czytanie calego pliku wiersz po wierszu (fizycznym)
                    while ((wierszFizyczny = sr.ReadLine()) != null)
                    {
                        // Sprawdz czy przeczytano date lub kategorie macierzy
                        if (wierszFizyczny.StartsWith("%%$#!"))
                        {
                            /* 
                             * jesli przeczytano date, ustal odpowiedni miesiac i dzien do modelu kalendarza
                             * lub jesli przeczytano kategorie, ustal odpowiednia kategorie do modelu macierzy;
                             * nastepnie przejdz do przeczytania kolejnego wiersza (zadania lub kolejnego dnia/kat.)
                             */
                            if (typPliku == "rok")
                            {
                                miesiac = "";
                                dzien = "";

                                miesiac += wierszFizyczny[5];
                                miesiac += wierszFizyczny[6];
                                dzien += wierszFizyczny[8];
                                dzien += wierszFizyczny[9];
                            }
                            else //dla macierzy Eisenhowera:
                            {
                                kategorie = "";
                                kategorie += wierszFizyczny[5];
                                kategorie += wierszFizyczny[6];
                            }

                            continue;
                        }
                        //od tad znany jest miesiac i dzien / kategoria

                        wierszLogiczny += wierszFizyczny;
                        // Sprawdzenie czy przeczytano logicznie pelny wiersz
                        if (!wierszFizyczny.EndsWith("%%@@"))
                        {
                            wierszLogiczny += System.Environment.NewLine;
                            continue;
                        }
                        // Tu przeczytano logicznie pelny wiersz + znana data/ kategoria

                        // Sformatowanie wiersza logicznego i zapis zadania do modelu
                        daneDoZapisu = wierszLogiczny.Split("%%+!", StringSplitOptions.None);
                        daneDoZapisu[5] = daneDoZapisu[5].Remove(1); //usun ciag konca wiersza logicznego

                        if (typPliku == "rok")
                            rok.GetMiesiace()[WyznaczInt(miesiac) - 1].GetDni()[WyznaczInt(dzien) - 1].
                                DodajZadanie(daneDoZapisu);
                        else
                            macierz.DodajZadanie(daneDoZapisu, kategorie);

                        wierszLogiczny = "";
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var nowy_plik = File.Create(sciezkaPliku);
                nowy_plik.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // TO DO
            }

            return true;
        }
        public void ZaladujKonfiguracje()
        {

        }
        private int WyznaczInt(string s)
        {
            if (s[0] == '0')
                s = s.Remove(0, 1);
            int i = Int32.Parse(s);
            return i;

        }
        public static WczytywanieDanych GetInstance() { return instance; }
    }
}
