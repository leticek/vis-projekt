using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Spoluprace
    {
        public Spoluprace(int spolupraceId, int trenerId, DateTime platnost, decimal cena)
        {
            this.SpolupraceId = spolupraceId;
            this.TrenerId = trenerId;
            this.Platnost = platnost;
            this.Cena = cena;
        }

        public int SpolupraceId { get; set; }
        public int TrenerId { get; set; }
        public DateTime Platnost { get; set; }
        public decimal Cena { get; set; }

        public override string ToString()
        {
            return $"ID: {this.SpolupraceId} TrenerID: {this.TrenerId} Platnost: {this.Platnost} Cena: {this.Cena}";
        }
    }
}
