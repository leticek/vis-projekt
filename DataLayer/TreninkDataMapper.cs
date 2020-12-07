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

        public async Task<Trenink> GetById(int id)
        {
            try
            {
                DocumentSnapshot document = await database.Collection("treninky").Document(id.ToString()).GetSnapshotAsync();
                if (document.Exists)
                {
                    Dictionary<string, object> documentDictionary = document.ToDictionary();
                    List<DocumentReference> cvikyRefs = new List<DocumentReference>();
                    cvikyRefs = (List<DocumentReference>)documentDictionary["cviky"];
                    List<int> cviky = new List<int>();
                    for (int i = 0; i < cvikyRefs.Count - 1; i++)
                    {
                        cviky.Add(Int32.Parse(cvikyRefs[i].Id));
                    }
                    Trenink t = new Trenink(Int32.Parse(document.Id), (int)documentDictionary["trener_id"], documentDictionary["nazev"].ToString(), cviky);
                    Console.WriteLine(t.ToString());
                    return t;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
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
            foreach (int i in value.Cviky)
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
