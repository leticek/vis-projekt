using DataLayer;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KlientModel : Uzivatel
    {
        public KlientModel(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, string telefon, int trenerId, int spolupraceId)
        {
            this.Id = id;
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.DatumNarozeni = datumNarozeni;
            this.Email = email;
            this.Telefon = telefon;
            this.TrenerId = trenerId;
            this.SpolupraceId = spolupraceId;
        }

        public KlientModel(KlientDTO klientDTO)
        {
            this.Id = klientDTO.Id;
            this.Jmeno = klientDTO.Jmeno;
            this.Prijmeni = klientDTO.Prijmeni;
            this.DatumNarozeni = klientDTO.DatumNarozeni;
            this.Email = klientDTO.Email;
            this.Telefon = klientDTO.Telefon;
            this.TrenerId = klientDTO.TrenerId;
            this.SpolupraceId = klientDTO.SpolupraceId;
        }


        public int TrenerId { get; set; }
        public TrenerModel Trener { get; set; }
        public int SpolupraceId { get; set; }

        KlientDTO ToDTO() => new KlientDTO(Id, Jmeno, Prijmeni, DatumNarozeni, Email, Telefon, TrenerId, SpolupraceId);

        public static List<KlientModel> GetByTrenerId(int id)
        {
            KlientDataMapper mapper = new KlientDataMapper();
            List<KlientDTO> mapperResult = new List<KlientDTO>();
            mapperResult = mapper.GetAll();
            mapperResult = mapperResult.Where(x => x.TrenerId == id).ToList();
            List<KlientModel> result = mapperResult.Select(x => new KlientModel(x)).ToList();
            return result;
        }

        public override string ToString()
        {
            return $"ID: {this.Id} Jmeno: {this.Jmeno} Prijmeni: {this.Prijmeni} DatumNarozeni: {this.DatumNarozeni} Email: {this.Id} Telefon: {this.Telefon} TrenerId: {this.TrenerId}" +
                    $" TrenerId: {this.TrenerId} SpolupraceId: {this.SpolupraceId}";
        }

        public static void DeleteById(int id)
        {
            KlientDataMapper klientDataMapper = new KlientDataMapper();
            klientDataMapper.Delete(id);
        }
    }
}
