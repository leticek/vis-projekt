using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using Google.Cloud.Firestore;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CvikDataMapper : IFSDataMapper<Cvik>
    {
        private readonly FirestoreDb database = FirestoreSingleton.Instance;
        public CvikDataMapper()
        {

        }

        public async Task<bool> Delete(int id)
        {
            WriteResult result = await database.Collection("cviky").Document(id.ToString()).DeleteAsync();
            return true;
        }

        public async Task<Cvik> GetById(int id)
        {
            DocumentSnapshot document = await database.Collection("cviky").Document(id.ToString()).GetSnapshotAsync();
            if (document.Exists)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                return new Cvik(Int32.Parse(document.Id), documentDictionary["nazev"].ToString(), (int)documentDictionary["pocetOpakovani"], (int)documentDictionary["pocetSerii"], documentDictionary["poznamka"].ToString());
            }
            return null;


        }

        public async Task<bool> Insert(Cvik value)
        {
            DocumentReference docRef = database.Collection("cviky").Document(value.Id.ToString());
            Dictionary<string, object> cvik = new Dictionary<string, object>
            {
                { "nazev", value.Nazev },
                { "pocetOpakovani", value.pocetOpakovani },
                { "pocetSerii", value.pocetSerii },
                { "poznamka", value.Poznamka },
            };
            await docRef.CreateAsync(cvik);
            return true;
        }



        public async Task<bool> Update(Cvik value)
        {
            DocumentReference docRef = database.Collection("cviky").Document(value.Id.ToString());
            Dictionary<string, object> cvik = new Dictionary<string, object>
            {
                {"nazev", value.Nazev },
                { "pocetOpakovani", value.pocetOpakovani },
                { "pocetSerii", value.pocetSerii },
                { "poznamka", value.Poznamka },
            };
            await docRef.SetAsync(cvik);
            return true;
        }
    }
}
