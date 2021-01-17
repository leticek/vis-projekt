using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    [FirestoreData]
    public class PlanovanyTreninkDTO
    {

        public PlanovanyTreninkDTO(int id, int idTrenera, int idKlienta, string mistoKonani, bool potvrzen, string poznamka, DateTime casKonani)
        {
            Id = id;
            IdTrenera = idTrenera;
            IdKlienta = idKlienta;
            MistoKonani = mistoKonani;
            Potvrzen = potvrzen;
            Poznamka = poznamka;
            CasKonani = casKonani.ToUniversalTime();

        }

        public PlanovanyTreninkDTO()
        {

        }

        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public int IdTrenera { get; set; }
        [FirestoreProperty]
        public int IdKlienta { get; set; }
        [FirestoreProperty]
        public string MistoKonani { get; set; }
        [FirestoreProperty]
        public bool Potvrzen { get; set; }
        [FirestoreProperty]
        public string Poznamka { get; set; }
        [FirestoreProperty]
        public DateTime CasKonani { get; set; }

    }
}
