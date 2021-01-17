using DataLayer.FirestoreMappers;
using DTO.DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TreninkovyPlanModel
    {
        public TreninkovyPlanModel(int id, int trenerId, string nazevPlanu, DateTime platnyDo, ObtiznostTreninkovehoPlanuEnum obtiznost, CilPlanu cilPlanu, string poznamka, List<int> treninky)
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

        public TreninkovyPlanModel(TreninkovyPlanDTO treninkovyPlanDTO)
        {
            this.Id = treninkovyPlanDTO.Id;
            this.TrenerId = treninkovyPlanDTO.TrenerId;
            this.NazevPlanu = treninkovyPlanDTO.NazevPlanu;
            this.PlatnyDo = treninkovyPlanDTO.PlatnyDo;
            this.Obtiznost = treninkovyPlanDTO.Obtiznost;
            this.CilPlanu = treninkovyPlanDTO.CilPlanu;
            this.Poznamka = treninkovyPlanDTO.Poznamka;
            this.Treninky = treninkovyPlanDTO.Treninky;
        }

        public TreninkovyPlanModel()
        {

        }


        public int Id { get; set; }

        public int TrenerId { get; set; }

        public string NazevPlanu { get; set; }

        public DateTime PlatnyDo { get; set; }

        public ObtiznostTreninkovehoPlanuEnum Obtiznost { get; set; }

        public CilPlanu CilPlanu { get; set; }

        public string Poznamka { get; set; }

        public List<int> Treninky { get; set; } = new List<int>();
        public List<TreninkModel> TreninkModels { get; set; } = new List<TreninkModel>();

        public async void Save()
        {
            FirestoreDataMapper<TreninkovyPlanDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkovyPlanDTO>();
            TreninkovyPlanDTO tmp = this.ToDTO();
            foreach (TreninkModel treninkModel in TreninkModels)
            {
                tmp.Treninky.Add(treninkModel.Id);
            }
            await firestoreDataMapper.Insert(tmp);
        }

        static public async Task<List<TreninkovyPlanModel>> GetByTrenerId(int id)
        {
            FirestoreDataMapper<TreninkovyPlanDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkovyPlanDTO>();
            List<TreninkovyPlanDTO> result = await firestoreDataMapper.GetByParameter("TrenerId", id);
            List<TreninkovyPlanModel> list = result.Select(x => new TreninkovyPlanModel(x)).ToList();
            return list;
        }

        public static async Task<bool> Remove(PlanovanyTreninkModel currentSelection)
        {
            FirestoreDataMapper<TreninkovyPlanDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkovyPlanDTO>();
            return await firestoreDataMapper.Delete(currentSelection.Id);
        }

        static public async Task<TreninkovyPlanModel> GetByName(int id, string name)
        {
            List<TreninkovyPlanModel> byName = await GetByTrenerId(id);
            return byName.Where(x => x.NazevPlanu.Equals(name)).ToList()[0];
        }

        public TreninkovyPlanDTO ToDTO() => new TreninkovyPlanDTO(Id, TrenerId, NazevPlanu, PlatnyDo, Obtiznost, CilPlanu, Poznamka, Treninky);

        public override string ToString()
        {
            return $"ID: {Id} NAZEV: {NazevPlanu} OBTIZNOST: {Obtiznost} CIL: {CilPlanu} DATUM: {PlatnyDo} POZNAMKY: {Poznamka} ";
        }
    }
}
