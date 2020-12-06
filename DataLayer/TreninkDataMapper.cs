using BusinessLayer;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TreninkDataMapper : IFSDataMapper<Trenink>
    {
        private readonly FirestoreDb database = FirestoreSingleton.Instance;
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Trenink> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(Trenink value)
        {
            DocumentReference docRef = database.Collection("treninky").Document(value.Id.ToString());
            Dictionary<string, object> trenink = new Dictionary<string, object>
            {
                { "nazev", value.Nazev },
                { "trener_id", value.TrenerId },
            };
            List<DocumentReference> cviky = new List<DocumentReference>();
            foreach(int i in value.Cviky)
            {
                cviky.Add(database.Collection("cviky").Document(i.ToString()));
            }
            trenink.Add("cviky", cviky);
            await docRef.CreateAsync(trenink);
            return true;
        }

        public Task<bool> Update(Trenink value)
        {
            throw new NotImplementedException();
        }
    }
}
