using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2005_majus
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] sorok = File.ReadAllLines("lottosz.dat");
            List<Szam> szamok = new List<Szam>();
            int[] Ertek = new int[255];
            int paros = 0;
            int paratlan = 0;

            foreach (string sor in sorok)
            {
                //szamok.Add(new Szam(sor));
                string[] s = sor.Split(' ');
                int vege = s.Length;

                for (int i = 0; i < vege; i++)//mindig az első ötöt írja felül, mert miután beolvassa a kövit, a for ciklusban reseteli az "i"-t
                { 
                    Ertek[i] = int.Parse(s[i]);

                    if (Ertek[i] % 2 == 0)
                    {
                        paros++;
                    }

                    if (Ertek[i] % 2 == 1)
                    {
                        paratlan++;
                    }
                }
            }
 
            /* 1 - kérje be az 52.hét lottószámait */
            Console.WriteLine("Adj meg 5 számot, szóközzel elválasztva!");
            string valasz = Console.ReadLine();

            /* 2- Rendezze a bekért számokat emelkedő sorrendbe, a rendezett számokat írja ki! */
            string[] valaszok = valasz.Split(' ');
            int h = valaszok.Length;
            int[] tomb = new int[h];
            for (int i = 0; i < h; i++)
            {
                int szam = int.Parse(valaszok[i]);
                tomb[i] = szam;
            }
            Array.Sort(tomb);

            foreach (var item in tomb)
            {
                Console.Write($"{item}" + " ");
            }

            /* 3- Kérjen be a felhasználótól egy egész számot 1-51 között! */
            Console.WriteLine("\nAdj meg 1 db egész számot!");
            int megadott = int.Parse(Console.ReadLine());

            /* 4- Írja ki a képernyőre a bekért számnak megfelelő sorszámú hét lottószámait, a
               lottosz.dat állományban lévő adatok alapján! */
            Console.WriteLine($"\nA {megadott}. heti lottószámok a következőek voltak: {sorok[megadott]}");

            /* 5. A lottosz.dat állományból beolvasott adatok alapján döntse el, hogy volt-e olyan
            szám, amit egyszer sem húztak ki az 51 hét alatt! A döntés eredményét (Van/Nincs) írja ki
            a képernyőre! 0-90 vannak a számok */
            
         

            /* 6  A lottosz.dat állományban lévő adatok alapján
             * állapítsa meg, hogy hányszor volt páratlan szám a
             * kihúzott lottószámok között! Az eredményt a képernyőre írja ki! */
            Console.WriteLine($"{paros} db páros van, és {paratlan} db páratlan van");

            /* 7 Fűzze hozzá a lottosz.dat állományból beolvasott lottószámok után a felhasználótól
            bekért, és rendezett 52. hét lottószámait, majd írja ki az összes lottószámot a lotto52.ki
            szöveges fájlba! A fájlban egy sorba egy hét lottószámai kerüljenek, szóközzel elválasztva
            egymástól!  */
            //string valasz - beirt számok

            List<string> ki = new List<string>();
            foreach (string sorozatok in sorok)
            {
                ki.Add(sorozatok);
            }
            ki.Add(valasz);
            File.WriteAllLines("lotto52.ki", ki, Encoding.UTF8);

            /* 8. Határozza meg a lotto52.ki állomány adatai alapján, hogy az egyes számokat hányszor
            húzták ki 2003-ban. Az eredményt írja ki a képernyőre a következő formában: az első sor
            első eleme az a szám legyen ahányszor az egyest kihúzták! Az első sor második eleme az
            az érték legyen, ahányszor a kettes számot kihúzták stb.! 
            (Annyit biztosan tudunk az értékekről, hogy mindegyikük egyjegyű.)  */

            string[] sorok2 = File.ReadAllLines("lotto52.ki");
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < 254; i++)
            {
                int kulcs = Ertek[i];
                if (dict.ContainsKey(kulcs))
                {
                    dict[kulcs]++;
                }
                else
                {
                    dict.Add(kulcs, 1);
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}  { item.Value}");
            }

            Console.ReadKey();

        }
    }
}
