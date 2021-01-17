using DataLayer.Interfaces;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.FirestoreMappers
{
    
        public class FirestoreDataMapper<T> : IFSDataMapper<T>
        {
            private readonly FirestoreDb database = FirestoreSingleton.Instance;

            public async Task<bool> Delete(int id)
            {
                try
                {
                    QuerySnapshot query = await database.Collection(typeof(T).Name.Substring(0, typeof(T).Name.Length - 3)).WhereEqualTo("Id", id).GetSnapshotAsync();
                    foreach (DocumentSnapshot documentSnapshot in query.Documents)
                    {
                        await documentSnapshot.Reference.DeleteAsync();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public async Task<T> GetById(int id)
            {
                try
                {
                    QuerySnapshot query = await database.Collection(typeof(T).Name.Substring(0, typeof(T).Name.Length - 3)).WhereEqualTo("Id", id).GetSnapshotAsync();
                    foreach (DocumentSnapshot documentSnapshot in query.Documents)
                    {
                        return documentSnapshot.ConvertTo<T>();
                    }
                    return default;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public async Task<List<T>> GetByParameter(string parameter, object value)
            {
                try
                {
                    QuerySnapshot query = await database.Collection(typeof(T).Name.Substring(0, typeof(T).Name.Length - 3)).WhereEqualTo(parameter, value).GetSnapshotAsync();
                    List<T> result = new List<T>();
                    foreach (DocumentSnapshot documentSnapshot in query.Documents)
                    {
                        result.Add(documentSnapshot.ConvertTo<T>());
                    }
                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public async Task<bool> Insert(T value)
            {
                try
                {
                    CollectionReference cvikyCollectionReference = database.Collection(typeof(T).Name.Substring(0, typeof(T).Name.Length - 3));
                    DocumentReference result = await cvikyCollectionReference.AddAsync(value);
                    if (result.GetSnapshotAsync().Result.Exists)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public async Task<bool> Update(T value)
            {
                try
                {

                    PropertyInfo[] propertyInfos;
                    propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    Dictionary<FieldPath, object> updates = new Dictionary<FieldPath, object>();
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        string propName = propertyInfo.Name;
                        updates.Add(new FieldPath(propName), value.GetType().GetProperty(propName).GetValue(value, null));
                    }

                    QuerySnapshot query = await database.Collection(typeof(T).Name.Substring(0, typeof(T).Name.Length - 3)).WhereEqualTo("Id", value.GetType().GetProperty("Id").GetValue(value, null)).GetSnapshotAsync();
                    foreach (DocumentSnapshot documentSnapshot in query.Documents)
                    {
                        await documentSnapshot.Reference.UpdateAsync(updates);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    
}
