using DataLayer.FirestoreMappers;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class PlanovanyTreninkModel
    {
        public PlanovanyTreninkModel(int id, int idTrenera, int idKlienta, string mistoKonani, bool potvrzen, string poznamka, DateTime casKonani)
        {
            Id = id;
            IdTrenera = idTrenera;
            IdKlienta = idKlienta;
            MistoKonani = mistoKonani;
            Potvrzen = potvrzen;
            Poznamka = poznamka;
            CasKonani = casKonani;

        }
        public PlanovanyTreninkModel(PlanovanyTreninkDTO planovanyTreninkDTO)
        {
            Id = planovanyTreninkDTO.Id;
            IdTrenera = planovanyTreninkDTO.IdTrenera;
            IdKlienta = planovanyTreninkDTO.IdKlienta;
            MistoKonani = planovanyTreninkDTO.MistoKonani;
            Potvrzen = planovanyTreninkDTO.Potvrzen;
            Poznamka = planovanyTreninkDTO.Poznamka;
            CasKonani = planovanyTreninkDTO.CasKonani;

        }

        public int Id { get; set; }
        public int IdTrenera { get; set; }
        public int IdKlienta { get; set; }
        public string MistoKonani { get; set; }
        public bool Potvrzen { get; set; }
        public string Poznamka { get; set; }
        public DateTime CasKonani { get; set; }

        public static async Task<List<PlanovanyTreninkModel>> GetAllByKlientId(int id)
        {
            FirestoreDataMapper<PlanovanyTreninkDTO> firestoreDataMapper = new FirestoreDataMapper<PlanovanyTreninkDTO>();
            List<PlanovanyTreninkDTO> mapperResult = await firestoreDataMapper.GetByParameter("IdKlienta", id);
            List<PlanovanyTreninkModel> result = mapperResult.Select(x => new PlanovanyTreninkModel(x)).ToList();
            return result;
        }

        public static async Task<bool> Remove(PlanovanyTreninkModel currentSelection)
        {
            FirestoreDataMapper<PlanovanyTreninkDTO> firestoreDataMapper = new FirestoreDataMapper<PlanovanyTreninkDTO>();
            return await firestoreDataMapper.Delete(currentSelection.Id);
        }

        public override string ToString()
        {
            return $"ID: {Id} Misto: {MistoKonani}";
        }
        public static async Task Save(PlanovanyTreninkModel currentSelection)
        {
            FirestoreDataMapper<PlanovanyTreninkDTO> firestoreDataMapper = new FirestoreDataMapper<PlanovanyTreninkDTO>();
            PlanovanyTreninkDTO planovanyTreninkDTO = new PlanovanyTreninkDTO(currentSelection.Id, 
                                                                                currentSelection.IdTrenera,
                                                                                currentSelection.IdKlienta,
                                                                                currentSelection.MistoKonani,
                                                                                currentSelection.Potvrzen,
                                                                                currentSelection.Poznamka,
                                                                                currentSelection.CasKonani.ToUniversalTime());
            await firestoreDataMapper.Update(planovanyTreninkDTO);
        }
    }
}
