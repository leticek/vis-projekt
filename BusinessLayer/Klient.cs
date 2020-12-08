using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Klient : Uzivatel
    {
        public Klient(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, string telefon, int trenerId, int spolupraceId)
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


        private int TrenerId { get; set; }
        public Trener Trener { get; set; }
        public int SpolupraceId { get; set; }


        public override string ToString()
        {
            return $"ID: {this.Id} Jmeno: {this.Jmeno} Prijmeni: {this.Prijmeni} DatumNarozeni: {this.DatumNarozeni} Email: {this.Id} Telefon: {this.Telefon} TrenerId: {this.TrenerId}" +
                    $" TrenerId: {this.TrenerId} SpolupraceId: {this.SpolupraceId}";
        }
    }
}
