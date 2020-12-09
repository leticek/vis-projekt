using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DTO.DTOs
{
    [FirestoreData]
    public class TreninkDTO
    {
        public TreninkDTO(int id, int trenerId, string nazev, List<int> cviky)
        {
            this.Id = id;
            this.TrenerId = trenerId;
            this.Nazev = nazev;
            this.Cviky = cviky;
        }
        public TreninkDTO()
        {

        }
        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public int TrenerId { get; set; }
        [FirestoreProperty]
        public string Nazev { get; set; }
        [FirestoreProperty]
        public List<int> Cviky { get; set; }

    }
}
