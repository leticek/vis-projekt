using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    [FirestoreData]
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
        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public string Nazev { get; set; }
        [FirestoreProperty]
        public int PocetOpakovani { get; set; }
        [FirestoreProperty]
        public int PocetSerii { get; set; }
        [FirestoreProperty]
        public string Poznamka { get; set; }
    }
}
