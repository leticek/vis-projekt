using DataLayer.FirestoreMappers;
using DataLayer.MSSQLMappers;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TrenerModel : Uzivatel
    {
        public TrenerModel()
        {

        }
        public TrenerModel(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, string telefon, string specializace)
        {
            this.Id = id;
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.DatumNarozeni = datumNarozeni;
            this.Email = email;
            this.Telefon = telefon;
            this.Specializace = specializace;
            loadTrenink();

        }
        public TrenerModel(TrenerDTO trenerDTO)
        {
            this.Id = trenerDTO.Id;
            this.Jmeno = trenerDTO.Jmeno;
            this.Prijmeni = trenerDTO.Prijmeni;
            this.DatumNarozeni = trenerDTO.DatumNarozeni;
            this.Email = trenerDTO.Email;
            this.Telefon = trenerDTO.Telefon;
            this.Specializace = trenerDTO.Specializace;
            loadTrenink();

        }
        public string Specializace { get; set; }
        public List<TreninkModel> Treninky;

        private async void loadTrenink()
        {

            FirestoreDataMapper<TreninkDTO> firestoreDataMapper = new FirestoreDataMapper<TreninkDTO>();
            List<TreninkDTO> result = await firestoreDataMapper.GetByParameter("TrenerId", Id);
            Treninky = result.Select(x => new TreninkModel(x)).ToList();
        }

        public TrenerDTO toDTO() => new TrenerDTO(Id, Jmeno, Prijmeni, DatumNarozeni, Email, Telefon, Specializace);

        public static TrenerModel GetById(int id)
        {
            TrenerDataMapper trenerDataMapper = new TrenerDataMapper();
            TrenerDTO result = trenerDataMapper.GetById(id);
            return new TrenerModel(result);
        }

        public override string ToString() => $"ID: {this.Id} Jmeno: {this.Jmeno} Prijmeni: {this.Prijmeni} DatumNarozeni: {this.DatumNarozeni} Email: {this.Id} Telefon: {this.Telefon}  Specializace: {this.Specializace}";

    }
}
