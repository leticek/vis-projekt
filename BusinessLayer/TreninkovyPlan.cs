using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace BusinessLayer
{
    [FirestoreData]
    public class TreninkovyPlan

    {
        public TreninkovyPlan(int id, int trenerId, string nazevPlanu, DateTime platnyDo, ObtiznostTreninkovehoPlanu obtiznost, CilPlanu cilPlanu, string poznamka, List<int> treninky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.NazevPlanu = nazevPlanu;
            this.PlatnyDo = platnyDo;
            this.Obtiznost = obtiznost;
            this.CilPlanu = cilPlanu;
            this.Poznamka = poznamka;
        }

        public TreninkovyPlan()
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
        public List<int> Treninky { get; set; }
        //public List<Trenink> Treninky { get; set; }

    }
}
