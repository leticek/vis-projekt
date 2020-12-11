﻿using System;
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

        static public async Task<List<TreninkovyPlanModel>> GetByTrenerId(int id)
        {
            FirestoreDataMapper<TreninkovyPlanDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkovyPlanDTO>();
            List<TreninkovyPlanDTO> result = await firestoreDataMapper.GetByParameter("TrenerId",id);
            List<TreninkovyPlanModel> list =  result.Select(x => new TreninkovyPlanModel(x)).ToList();
            return list;
        }

        static public async Task<TreninkovyPlanModel> GetByName(int id, string name)
        {
            List<TreninkovyPlanModel> byName = await GetByTrenerId(id);
            return byName.Where(x => x.NazevPlanu.Equals(name)).ToList()[0];
        }

        public TreninkovyPlanDTO toDTO() => new TreninkovyPlanDTO(Id, TrenerId, NazevPlanu, PlatnyDo, Obtiznost, CilPlanu, Poznamka, Treninky);

        public override string ToString()
        {
            return $"ID: {Id} NAZEV: {NazevPlanu} OBTIZNOST: {Obtiznost} CIL: {CilPlanu} DATUM: {PlatnyDo} POZNAMKY: {Poznamka} ";
        }
    }
}
