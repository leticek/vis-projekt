using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Cvik
    {
        public Cvik(int id, string nazev, int pocetOpakovani, int pocetSerii, string poznamka)
        {
            this.Id = id;
            this.Nazev = nazev;
            this.pocetOpakovani = pocetOpakovani;
            this.pocetSerii = pocetSerii;
            this.Poznamka = poznamka;
        }

        public int Id { get; set; }
        public string Nazev { get; set; }
        public int pocetOpakovani { get; set; }
        public int pocetSerii { get; set; }
        public string Poznamka { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id} Nazev: {this.Nazev} Opakovani: {this.pocetOpakovani} Serie: {this.pocetSerii} Poznamka: {this.Poznamka}";
        }
    }
}
