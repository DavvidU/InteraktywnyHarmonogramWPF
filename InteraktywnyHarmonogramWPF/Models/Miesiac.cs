using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Models
{
    class Miesiac
    {
        private int miesiac;
        private Dzien[] dni;
        public Miesiac(int miesiac, int rok)
        {
            this.miesiac = miesiac;
            if (miesiac % 2 == 1 && miesiac < 8)
                dni = new Dzien[31];
            if (miesiac % 2 == 0 && miesiac < 8 && miesiac != 2)
                dni = new Dzien[30];
            if (miesiac % 2 == 0 && miesiac > 7)
                dni = new Dzien[31];
            if (miesiac % 2 == 1 && miesiac > 7)
                dni = new Dzien[30];
            if (miesiac == 2)
            {
                if (rok % 4 == 0 && rok % 100 != 0 || rok % 400 == 0)
                    dni = new Dzien[29];
                else
                    dni = new Dzien[28];
            }
            for (int i = 1; i <= dni.Length; ++i)
                dni[i - 1] = new Dzien(i);

        }
        public int GetMiesiac() { return miesiac; }
        public Dzien[] GetDni() { return dni; }
    }
}
