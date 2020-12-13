using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTO.DTOs;


namespace BusinessLayer
{
    public class TreninkModel
    {
        public TreninkModel(int id, int trenerId, string nazev, List<int> cviky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.Nazev = nazev;
            this.Cviky = cviky;
        }

        public TreninkModel(TreninkDTO treninkDTO)
        {
            this.Id = treninkDTO.Id;
            this.TrenerId = treninkDTO.TrenerId;
            this.Nazev = treninkDTO.Nazev;
            this.Cviky = treninkDTO.Cviky;
        }

        public TreninkModel()
        {

        }

        public int Id { get; set; }
     
        public int TrenerId { get; set; }
        public string Nazev { get; set; }
        public List<int> Cviky { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id} TrenerId: {this.TrenerId} Nazev: {this.Nazev} Cviky: {this.Cviky}";
        }

        public async Task<TreninkModel> loadFromFirestore(string name, int trenerId)
        {
            FirestoreDataMapper<TreninkDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkDTO>();
            List<TreninkDTO> fsResult = await firestoreDataMapper.GetByParameter("TrenerId", trenerId);
            fsResult = fsResult.Where(x => x.Nazev == name).ToList();
            Id = fsResult[0].Id;
            TrenerId = fsResult[0].TrenerId;
            Nazev = fsResult[0].Nazev;
            Cviky = fsResult[0].Cviky;
            return this;
        }
    }
}
