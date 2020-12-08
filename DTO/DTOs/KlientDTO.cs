using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class KlientDTO
    {
        public KlientDTO(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, string telefon, int trenerId, int spolupraceId)
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
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int TrenerId { get; set; }
        public int SpolupraceId { get; set; }
    }
}
