using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrenerDTO
    {
        public TrenerDTO(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, string telefon, string specializace)
        {
            this.Id = id;
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.DatumNarozeni = datumNarozeni;
            this.Email = email;
            this.Telefon = telefon;
            this.Specializace = specializace;

        }
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Specializace { get; set; }
    }
}
