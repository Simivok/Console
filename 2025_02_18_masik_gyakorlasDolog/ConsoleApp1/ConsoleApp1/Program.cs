using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sorok = new List<string>(File.ReadAllLines("rovidprogram.csv"));
            List<Rovidpontok> rpontok = new List<Rovidpontok>();
            foreach (var s in sorok.Skip(1))
            {
                rpontok.Add(new Rovidpontok(s));
            }
            List<string> sorok2 = new List<string>(File.ReadAllLines("donto.csv"));
            List<Dontopontok> dpontok = new List<Dontopontok>();
            foreach (var s in sorok2.Skip(1))
            {
                dpontok.Add(new Dontopontok(s));
            }
            Console.WriteLine("2.Feladat:");
            Console.WriteLine(rpontok.Count());

            Console.WriteLine("3.Feladat:");
            foreach (var v in dpontok)
            {
                if (v.Orszag == "HUN")
                {
                    Console.WriteLine("Igen bejutott");
                    break;
                }
            }
            Console.WriteLine("4.Feladat:");
            OsszPontszam("Dasa GRM",rpontok,dpontok);
            Console.WriteLine("5.Feladat:");
            Console.WriteLine("Adja meg egy versenyző nevét!: ");
            string versenyzo = Console.ReadLine();
            bool indult = false;
            foreach (var rp in rpontok)
            {
                if (rp.Nev==versenyzo)
                {
                    indult = true;
                    break;
                }
            }
            Console.WriteLine(indult ? "Indult a versenyző":"Nem indult a versenyző");

            Console.WriteLine("6.Feladat:");
            OsszPontszam(versenyzo, rpontok, dpontok);

            Console.WriteLine("7.Feladat:");
            Dictionary<string, int> orszagok = new Dictionary<string, int>();
            foreach (var dp in dpontok)
            {
                if (orszagok.ContainsKey(dp.Orszag))
                {
                    orszagok[dp.Orszag]++;
                }
                else
                {
                    orszagok.Add(dp.Orszag, 1);
                }
            }
            foreach (var orszag in orszagok)
            {
                if (orszag.Value>1)
                {
                    Console.WriteLine($"{ orszag.Key} több mint egy játékosa jutott tovább");
                }
            }
        }

            static void OsszPontszam(string nev,List<Rovidpontok>rp,List<Dontopontok>dp)
       {
            Dictionary<string, double> osszpontok = new Dictionary<string, double>();
            foreach (var v in rp)
            {
                osszpontok.Add(v.Nev, (v.TechPont + v.KompPont) - v.HibaPont);
            }
            foreach (var vk in dp)
            {
                if (osszpontok.ContainsKey(vk.Nev))
                {
                    osszpontok[vk.Nev]+= (vk.TechPont + vk.KompPont) - vk.HibaPont;
                }
            }
            foreach (var v in osszpontok)
            {
                if (v.Key == nev)
                {
                    Console.WriteLine($"{v.Key} - {v.Value}");
                }
            }
       }
    }
}
