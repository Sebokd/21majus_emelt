using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars2021GUI
{
    public class Versenyző
    {
        public string Nev { get; set; }
        public string Csoport { get; set; }
        public string NemzetKód { get; set; }
        public double Dobas1 { get; set; } //double lesz majd
        public double Dobas2 { get; set; }
        public double Dobas3 { get; set; }
        public double Eredmény { get; set; }
        public string Nemzet
        {
            get
            {
                string[] m = NemzetKód.Split(' ');
                return String.Join(" ", m.Take(m.Length - 1));
            }
        }
        public string Kód => NemzetKód.Split(' ').Last().Replace("(", "").Replace(")", "");

        public Versenyző(string sor)
        {
            string[] s = sor.Split(';');
            Nev = s[0];
            Csoport = s[1];
            NemzetKód = s[2];

            if (s[3] == "X")
            {
                Dobas1 = -1.0;
            }
            else if (s[3] == "-")
            {
                Dobas1 = -2.0;
            }
            else
            {
                Dobas1 = double.Parse(s[3]);
            }

            if (s[4] == "X")
            {
                Dobas2 = -1.0;
            }
            else if (s[4] == "-")
            {
                Dobas2 = -2.0;
            }
            else
            {
                Dobas2 = Convert.ToDouble(s[4]);
            }

            if (s[5] == "X")
            {
                Dobas3 = -1.0;
            }
            else if (s[5] == "-")
            {
                Dobas3 = -2.0;
            }
            else
            {
                Dobas3 = Convert.ToDouble(s[5]);
            }

            Eredmény = Math.Max(Dobas1, Dobas2);
            if (Eredmény < Dobas3)
            {
                Eredmény = Dobas3;
            }
        }
    }
}
