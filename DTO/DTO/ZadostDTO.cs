using DTO.Enums;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    [FirestoreData]
    public class ZadostDTO
    {
        public ZadostDTO(int id, int spolupraceId, TypZadosti typZadosti, DateTime datum)
        {
            Id = id;
            SpolupraceId = spolupraceId;
            TypZadosti = typZadosti;
            Datum = datum.ToUniversalTime();
        }

        public ZadostDTO()
        {

        }

        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public int SpolupraceId { get; private set; }
        [FirestoreProperty]
        public TypZadosti TypZadosti { get; set; }
        [FirestoreProperty]
        public DateTime Datum { get; set; }
    }
}
