using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class TreninkovyPlanDTO
    {
        public TreninkovyPlanDTO(int id, int trenerId, string nazevPlanu, DateTime platnyDo, ObtiznostTreninkovehoPlanu obtiznost, CilPlanu cilPlanu, string poznamka, List<int> treninky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.NazevPlanu = nazevPlanu;
            this.PlatnyDo = platnyDo;
            this.Obtiznost = obtiznost;
            this.CilPlanu = cilPlanu;
            this.Poznamka = poznamka;
        }   
        public int Id { get; set; }
        public int TrenerId { get; set; }
        public string NazevPlanu { get; set; }
        public DateTime PlatnyDo { get; set; }
        public ObtiznostTreninkovehoPlanu Obtiznost { get; set; }
        public CilPlanu CilPlanu { get; set; }
        public string Poznamka { get; set; }
        public List<int> Treninky { get; set; }
    }
}
