using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Models
{
    public class Zadanie : IEquatable<Zadanie>
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
            Naglowek = naglowek;
            Opis = opis;
            Pilne = pilne;
            Wazne = wazne;
            Wykonane = wykonane;
        }
        public bool Equals(Zadanie other)
        {
            if (other == null) return false;
            return Naglowek == other.Naglowek && Opis == other.Opis && Pilne == other.Pilne && Wazne == other.Wazne && Wykonane == other.Wykonane;
        }

        public override int GetHashCode()
        {
            return (Naglowek, Opis, Pilne, Wazne, Wykonane).GetHashCode();
        }
    }
}
