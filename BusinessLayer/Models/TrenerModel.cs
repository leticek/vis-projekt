using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class TrenerModel : Uzivatel
    {
        public TrenerModel(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, string telefon, string specializace)
        {
            this.Id = id;
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.DatumNarozeni = datumNarozeni;
            this.Email = email;
            this.Telefon = telefon;
            this.Specializace = specializace;

        }
        public string Specializace { get; set; }
        public List<TreninkModel> Treninky;

        private void loadTrenink()
        {
            
        }

        public override string ToString()
        {
            return $"ID: {this.Id} Jmeno: {this.Jmeno} Prijmeni: {this.Prijmeni} DatumNarozeni: {this.DatumNarozeni} Email: {this.Id} Telefon: {this.Telefon}  Specializace: {this.Specializace}";
        }
    }
}
