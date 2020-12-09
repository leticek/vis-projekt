using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTO.DTOs;
using Google.Cloud.Firestore;

namespace BusinessLayer
{
    [FirestoreData]
    public class TreninkovyPlanModel
    {
        public TreninkovyPlanModel(int id, int trenerId, string nazevPlanu, DateTime platnyDo, ObtiznostTreninkovehoPlanu obtiznost, CilPlanu cilPlanu, string poznamka, List<int> treninky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.NazevPlanu = nazevPlanu;
            this.PlatnyDo = platnyDo;
            this.Obtiznost = obtiznost;
            this.CilPlanu = cilPlanu;
            this.Poznamka = poznamka;
            this.Treninky = treninky;
        }

        public TreninkovyPlanModel()
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
        public List<TreninkModel> TreninkModels { get; set; } = new List<TreninkModel>();

        public async void Save()
        {
            FirestoreDataMapper<TreninkovyPlanDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkovyPlanDTO>();
            TreninkovyPlanDTO tmp = this.toDTO();
            foreach(TreninkModel treninkModel in TreninkModels)
            {
                tmp.Treninky.Add(treninkModel.Id);
            }
            await firestoreDataMapper.Insert(tmp);
        }

        public TreninkovyPlanDTO toDTO() => new TreninkovyPlanDTO(Id, TrenerId, NazevPlanu, PlatnyDo, Obtiznost, CilPlanu, Poznamka, Treninky);

    }
}
