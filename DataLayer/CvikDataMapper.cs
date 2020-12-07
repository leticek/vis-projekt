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
            try
            {
                QuerySnapshot query = await database.Collection("cviky").WhereEqualTo("Id", id).GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in query.Documents)
                {
                    await documentSnapshot.Reference.DeleteAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Cvik> GetById(int id)
        {
            try
            {
                QuerySnapshot query = await database.Collection("cviky").WhereEqualTo("Id", id).GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in query.Documents)
                {
                    return documentSnapshot.ConvertTo<Cvik>();
                }
                return null;
            }
            catch
            {
                return null;
            }


        }

        public async Task<bool> Insert(Cvik value)
        {
            try
            {
                CollectionReference cvikyCollectionReference = database.Collection("cviky");
                DocumentReference result = await cvikyCollectionReference.AddAsync(value);
                if (result.GetSnapshotAsync().Result.Exists)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }



        public async Task<bool> Update(Cvik value)
        {
            try
            {
                QuerySnapshot query = await database.Collection("cviky").WhereEqualTo("Id", value.Id).GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in query.Documents)
                {
                    Dictionary<FieldPath, object> updates = new Dictionary<FieldPath, object>
                    {
                        { new FieldPath("Id"), value.Id },
                        { new FieldPath("Nazev"), value.Nazev },
                        { new FieldPath("Poznamka"), value.Poznamka },
                        { new FieldPath("PocetOpakovani"), value.PocetOpakovani },
                        { new FieldPath("PocetSerii"), value.PocetSerii }
                    };
                    await documentSnapshot.Reference.UpdateAsync(updates);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
