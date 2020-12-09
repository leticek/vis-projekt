using BusinessLayer;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    [FirestoreData]
    public class TreninkovyPlanDTO
    {
        public TreninkovyPlanDTO(int id, int trenerId, string nazevPlanu, DateTime platnyDo, ObtiznostTreninkovehoPlanu obtiznost, CilPlanu cilPlanu, string poznamka, List<int> treninky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.NazevPlanu = nazevPlanu;
            this.PlatnyDo = platnyDo.ToUniversalTime();
            this.Obtiznost = obtiznost;
            this.CilPlanu = cilPlanu;
            this.Poznamka = poznamka;
        }
        public TreninkovyPlanDTO()
        {

        }
        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public int TrenerId { get; set; }
        [FirestoreProperty]
        public string NazevPlanu { get; set; }
        [FirestoreProperty]
        public DateTime PlatnyDo { get; set; }
        [FirestoreProperty]
        public ObtiznostTreninkovehoPlanu Obtiznost { get; set; }
        [FirestoreProperty]
        public CilPlanu CilPlanu { get; set; }
        [FirestoreProperty]
        public string Poznamka { get; set; }
        [FirestoreProperty]
        public List<int> Treninky { get; set; } = new List<int>();
    }
}
