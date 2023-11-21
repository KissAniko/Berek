using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berek
{

     //  Név;            Neme;     Részleg;      Belépés;     Bér
     //  Beri Dániel;   férfi;     beszerzés;    1979;        222943
    internal class Ber
    {
        string nev;
        string nem;
        string reszleg;
        int belepes;
        int dolgozoBer;

        public Ber(string nev, string nem, string reszleg, int belepes, int dolgozoBer)
        {
            this.Nev = nev;
            this.Nem = nem;
            this.Reszleg = reszleg;
            this.Belepes = belepes;
            this.DolgozoBer = dolgozoBer;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Nem { get => nem; set => nem = value; }
        public string Reszleg { get => reszleg; set => reszleg = value; }
        public int Belepes { get => belepes; set => belepes = value; }
        public int DolgozoBer { get => dolgozoBer; set => dolgozoBer = value; }
    }
}
