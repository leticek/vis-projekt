using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTOs;

namespace DataLayer
{
    public class KlientDataMapper : ISQLDataMapper<KlientDTO>
    {
        private readonly string connectionString = "server=dbsys.cs.vsb.cz\\STUDENT;database=smi0114;user=smi0114;password=rMLsTuYdah;";
        public bool Delete(int id)
        {
            string queryText = "DELETE FROM Klient WHERE klient_id = @klient_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("klient_id", id);
                
                int result = sqlCommand.ExecuteNonQuery();
                if (result >= 1) return true;
            }
            return false;
        }

        public KlientDTO GetById(int id)
        {
            string queryText = "SELECT * FROM Klient WHERE klient_id = @klient_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("klient_id", id);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    return new KlientDTO(
                        reader.GetInt32(reader.GetOrdinal("klient_id")),
                        reader.GetString(reader.GetOrdinal("jmeno")),
                        reader.GetString(reader.GetOrdinal("prijmeni")),
                        reader.GetDateTime(reader.GetOrdinal("datum_narozeni")),
                        reader.GetString(reader.GetOrdinal("email")),
                        reader.GetString(reader.GetOrdinal("telefon")),
                        reader.GetInt32(reader.GetOrdinal("spoluprace_id")),
                        reader.GetInt32(reader.GetOrdinal("trener_id")));
                }
                return null;
            }

        }

        public List<KlientDTO> GetAll()
        {
            string queryText = "SELECT * FROM Klient";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                

                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<KlientDTO> result = new List<KlientDTO>();
                while (reader.Read())
                {
                    result.Add( new KlientDTO(
                        reader.GetInt32(reader.GetOrdinal("klient_id")),
                        reader.GetString(reader.GetOrdinal("jmeno")),
                        reader.GetString(reader.GetOrdinal("prijmeni")),
                        reader.GetDateTime(reader.GetOrdinal("datum_narozeni")),
                        reader.GetString(reader.GetOrdinal("email")),
                        reader.GetString(reader.GetOrdinal("telefon")),
                        reader.GetInt32(reader.GetOrdinal("trener_id")),
                    reader.GetInt32(reader.GetOrdinal("spoluprace_id"))));
                }
                return result;
            }
        }

        public bool Insert(KlientDTO value)
        {
            string queryText = "INSERT INTO Klient(klient_id, jmeno, prijmeni, datum_narozeni, email, telefon, trener_id, spoluprace_id) VALUES(@klient_id, @jmeno, @prijmeni, @datum_narozeni, @email, @telefon, @trener_id, @spoluprace_id)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("klient_id", value.Id);
                sqlCommand.Parameters.AddWithValue("jmeno", value.Jmeno);
                sqlCommand.Parameters.AddWithValue("prijmeni", value.Prijmeni);
                sqlCommand.Parameters.AddWithValue("datum_narozeni", value.DatumNarozeni.ToString());
                sqlCommand.Parameters.AddWithValue("email", value.Email);
                sqlCommand.Parameters.AddWithValue("telefon", value.Telefon);
                sqlCommand.Parameters.AddWithValue("trener_id", value.TrenerId);
                sqlCommand.Parameters.AddWithValue("spoluprace_id", value.SpolupraceId);
                int result = sqlCommand.ExecuteNonQuery();
                if (result == 1) return true;
            }
            return false;
        }

        public bool Update(KlientDTO value)
        {
            string queryText = "UPDATE Klient SET klient_id = @klient_id, jmeno = @jmeno, prijmeni = @prijmeni, datum_narozeni = @datum_narozeni, email = @email, telefon = @telefon, trener_id = @trener_id, spoluprace_id = @spoluprace_id" +
                " WHERE klient_id = @klient_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("klient_id", value.Id);
                sqlCommand.Parameters.AddWithValue("jmeno", value.Jmeno);
                sqlCommand.Parameters.AddWithValue("prijmeni", value.Prijmeni);
                sqlCommand.Parameters.AddWithValue("datum_narozeni", value.DatumNarozeni.ToString());
                sqlCommand.Parameters.AddWithValue("email", value.Email);
                sqlCommand.Parameters.AddWithValue("telefon", value.Telefon);
                sqlCommand.Parameters.AddWithValue("trener_id", value.TrenerId);
                sqlCommand.Parameters.AddWithValue("spoluprace_id", value.SpolupraceId);
                int result = sqlCommand.ExecuteNonQuery();
                if (result >= 1) return true;
            }
            return false;
        }
    }
}

