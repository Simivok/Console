using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Rovidpontok
    {
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public double TechPont { get; set; }
        public double KompPont { get; set; }
        public int HibaPont { get; set; }
        public Rovidpontok(string sor)
        {
            string[] sorSplit = sor.Split(";");
            Nev = sorSplit[0];
            Orszag = sorSplit[1];
            TechPont = double.Parse(sorSplit[2], CultureInfo.InvariantCulture);
            KompPont = double.Parse(sorSplit[3], CultureInfo.InvariantCulture);
            HibaPont = int.Parse(sorSplit[4]);
        }
    }
}
