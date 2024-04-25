using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktywnyHarmonogramWPF.Models
{
    class Kalendarz
    {
        private static Kalendarz kalendarz = new Kalendarz();
        public LinkedList<Rok> lata = new LinkedList<Rok>();

        private Kalendarz() { }
        public static Kalendarz GetKalendarz()
        {
            return kalendarz;
        }
    }
}
