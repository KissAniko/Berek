using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berek
{
    internal class Program
    {
        static List<Ber> berek = new List<Ber>();
        static void Main(string[] args)
        {
            /*  var ellen = File.ReadAllLines("berek2020.txt");
              foreach (var el in ellen)
              {
                  Console.WriteLine(el);
              }*/

            List<Ber> berek = new List<Ber>();
            string[] sorok = File.ReadAllLines("berek2020.txt").Skip(1).ToArray();
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] adat = sorok[i].Split(';');

                string nev = adat[0];
                string nem = adat[1];
                string reszleg = adat[2];
                int belepes = Convert.ToInt32(adat[3]);
                int dolgozoBer = Convert.ToInt32(adat[4]);

                Ber ber = new Ber(nev, nem, reszleg, belepes, dolgozoBer);
                berek.Add(ber);
            }

            //-----------------------------------------------------------------------


            // 3. feladat: Hány dolgozója van a cégnek?
            Console.WriteLine($"3. feladat: Dolgozok száma: {berek.Count}");
            var atlagfizetes = berek.Average(x => x.DolgozoBer);

            // 4. feladat: Mennyi az átlagfizetés ezer (e) Ft ra lebontva, egy tizedesjeggyel kiíratva?          (paraméter?)
            Console.WriteLine($"4. feladat: Bérek átlaga: {Math.Round(atlagfizetes / 1000, 1)} eFT");

            // 5. feladat: Kérejen be a felhasználótól egy részleg megnevezért.

            Console.Write("5. feladat: Kérem adja meg a  részleg nevét: ");
            string bekertReszleg = Console.ReadLine();


            // 6. feladat: A legtöbbet kereső dolgozó adatai,  az 5. feladatban  megadott részlegen. 
            //             Használja a kivételkezelést is.Ha nincs a felhasználó által bekért részleg
            //             a listában, akkor jelenjen meg, hogy nincs ilyen részleg.


            if (berek.Any(x => x.Reszleg == bekertReszleg))
            {
                Console.WriteLine("6. feladat: A legtöbbet kereső dolgozó a megadott részlegen:");
                var maxBer = berek.OrderByDescending(x => x.DolgozoBer).Where(x => x.Reszleg == bekertReszleg).First();
                Console.WriteLine($"\tNév: {maxBer.Nev}\n\tNeme: {maxBer.Nem}\n\tBelépés éve: {maxBer.Belepes}\n\tBér: {maxBer.DolgozoBer}");
            }
            else
            {
                Console.WriteLine("A megadott részleg nem létezik a cégnél!");
            }

            // 7.feladat: Statisztika... részlegekre lebontva - dolgozók száma/fő.

            Console.WriteLine("7. feladat: Statisztika: ");

            Dictionary<string, int> statisztika = berek.GroupBy(x => x.Reszleg).ToDictionary(x => x.Key, x => x.Count());

            foreach (var item in statisztika)
            {
                Console.WriteLine($"\t {item.Key} - {item.Value} fő");
            }

        }
    }

}

/*    3. feladat: Dolgozok száma: 170
      4. feladat: Bérek átlaga: 250,3 eFT
      5. feladat: Kérem adja meg a  részleg nevét: beszerzés
      6. feladat: A legtöbbet kereső dolgozó a megadott részlegen:
            Név: Czeczei Zsolt
            Neme: férfi
            Belépés éve: 1981
            Bér: 452042
      7. feladat: Statisztika:
            beszerzés - 17 fő
            pénzügy - 36 fő
            asztalosműhely - 18 fő
            értékesítés - 16 fő
            lakatosműhely - 15 fő
            karbantartás - 26 fő
            szerelőműhely - 30 fő
            személyzeti - 12 fő
      Press any key to continue . . .
 */