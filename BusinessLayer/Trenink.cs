using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Trenink
    {
        public Trenink(int id, int trenerId, string nazev, List<int> cviky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.Nazev = nazev;
            this.Cviky = cviky;
        }

        public int Id { get; set; }
        public int TrenerId { get; set; }
        public string Nazev { get; set; }
        public List<int> Cviky { get; set; }
    }
}
