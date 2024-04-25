using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Models
{
    class Rok
    {
        private int rok;
        private Miesiac[] miesiace = new Miesiac[12];
        public Rok(int rok)
        {
            this.rok = rok;
            for (int i = 1; i < 13; ++i)
            {
                miesiace[i - 1] = new Miesiac(i, rok);
            }
        }
        public int GetRok() { return rok; }
        public Miesiac[] GetMiesiace() { return miesiace; }
    }
}
