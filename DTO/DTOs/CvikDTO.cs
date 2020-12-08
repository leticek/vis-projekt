using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CvikDTO
    {
        public CvikDTO() { }

        public CvikDTO(int id, string nazev, int pocetOpakovani, int pocetSerii, string poznamka)
        {
            this.Id = id;
            this.Nazev = nazev;
            this.PocetOpakovani = pocetOpakovani;
            this.PocetSerii = pocetSerii;
            this.Poznamka = poznamka;
        }

        public int Id { get; set; }
        public string Nazev { get; set; }
        public int PocetOpakovani { get; set; }
        public int PocetSerii { get; set; }
        public string Poznamka { get; set; }
    }
}
