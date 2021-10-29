using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21majus_Pars2012
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("Selejtezo2012.txt");
            List<Versenyző> adatok = new List<Versenyző>();
            foreach (string sor in sorok.Skip(1))
            {
                adatok.Add(new Versenyző(sor));
            }

            /* 5 */
            int versenyzokSzama = adatok.Count();
            Console.WriteLine($"5.feladat: Hány atléta adata található a forrásban? Válasz: {versenyzokSzama} fő");

            /* 6 */
            int nagydobas = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                if (adatok[i].Dobas1 == 78 || adatok[i].Dobas1 > 78 || adatok[i].Dobas2 == 78 ||
                    adatok[i].Dobas2 > 78 || adatok[i].Dobas3 == 78 || adatok[i].Dobas3 > 78)
                {
                    nagydobas++;
                }
            }
            Console.WriteLine($"6. Feladat: A 78,00 méter felett dobott, így automatikusan tovább jutott versenyzők száma: {nagydobas}");

            
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"{adatok[i].Nev}-- {adatok[i].Kód} -- legnagyobb dobása: {adatok[i].Eredmény}");
            }

            double max = 0;
            int maxi = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                if (adatok[i].Eredmény > max)
                {
                    max = adatok[i].Eredmény;
                    maxi = i;
                }
            }



            Console.WriteLine($"9. Feladat: lejobb eredményt elért atléta: " +
                $"\n Név: {adatok[maxi].Nev, 10} " +
                $"\n Csoport: {adatok[maxi].Csoport,10}" +
                $"\n Nemzet: {adatok[maxi].Nemzet,10}" +
                $"\n Nemzet Kód: {adatok[maxi].Kód,10}" +
                $"\n Sorozat: {adatok[maxi].Dobas1};{adatok[maxi].Dobas2};{adatok[maxi].Dobas3}" +
                $"\n Eredmény: {adatok[maxi].Eredmény}");

            /* 10 */

            List<string> ki = new List<string>();
            ki.Add($"Helyezés;Név;Csoport;Nemzet;NemzetKód;Sorozat;Eredmény");
            for (int i = 0; i < 12; i++)
            {
                Versenyző legjobb = adatok.First();
                foreach (var v in adatok.Skip(1))
                {
                    if (v.Eredmény > adatok[i].Eredmény) legjobb = v;
                }
                ki.Add($"{i};{legjobb.Nev};{legjobb.Csoport};{legjobb.Nemzet};{legjobb.Kód};{legjobb.Dobas1};{legjobb.Dobas2};{legjobb.Dobas3};{legjobb.Eredmény}");
                adatok.Remove(legjobb);
            }
            File.WriteAllLines("Dontos2012.txt", ki, Encoding.UTF8);

            Console.ReadLine();

        }
    }
}
