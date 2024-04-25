using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Models
{
    class Zadanie : IEquatable<Zadanie>
    {
        public string Naglowek { get; set; }
        public string Opis { get; set; }
        public bool Pilne { get; set; }
        public bool Wazne { get; set; }
        public bool Wykonane { get; set; }

        //konstruktor tworzacy
        public Zadanie(string naglowek, string opis,
            bool pilne, bool wazne, bool wykonane)
        {
            this.Naglowek = naglowek;
            this.Opis = opis;
            this.Pilne = pilne;
            this.Wazne = wazne;
            this.Wykonane = wykonane;
        }
        public bool Equals(Zadanie? other)
        {
            if (other == null)
                return false;
            if (other.Naglowek != Naglowek || other.Opis != Opis
                || other.Pilne != Pilne || other.Wazne != Wazne || other.Wykonane != Wykonane)
                return false;
            return true;
        }
    }
}
