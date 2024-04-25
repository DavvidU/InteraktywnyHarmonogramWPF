using InteraktywnyHarmonogramWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Helpers
{
    class Inicjalizacja
    {
        private Kalendarz kalendarz;
        private Macierz macierz;
        private DateTime aktualna_data;
        public Inicjalizacja()
        {
            Initialize();
        }
        public bool Initialize()
        {
            aktualna_data = DateTime.Now;
            kalendarz = Kalendarz.GetKalendarz();
            macierz = Macierz.GetMacierz();

            ZainicjujPustyKalendarz();
            WypelnijStartowyKalendarz();
            WypelnijStartowaMacierz();

            return true;
        }

        private void ZainicjujPustyKalendarz()
        {
            //dodaj rok ubiegy, aktualny i 8 lat do przodu
            for (int i = 1; i > -9; --i)
            {
                kalendarz.lata.AddLast(new Rok(aktualna_data.Year - i));
            }
        }
        private void WypelnijStartowyKalendarz()
        {
            WczytywanieDanych kontroler = WczytywanieDanych.GetInstance();
            foreach (Rok rok in kalendarz.lata)
            {
                kontroler.ZaladujRokLubMacierz(rok, "rok");
            }
        }
        private void WypelnijStartowaMacierz()
        {
            WczytywanieDanych kontroler = WczytywanieDanych.GetInstance();
            kontroler.ZaladujRokLubMacierz(null, "macierz");
        }
        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
