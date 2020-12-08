using DTO;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TrenerDataMapper : ISQLDataMapper<TrenerDTO>
    {
        private readonly string connectionString = "server=dbsys.cs.vsb.cz\\STUDENT;database=smi0114;user=smi0114;password=rMLsTuYdah;";
        public bool Delete(int id)
        {
            string queryText = "DELETE FROM Trener WHERE trener_id = @trener_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("trener_id", id);

                int result = sqlCommand.ExecuteNonQuery();
                if (result >= 1) return true;
            }
            return false;
        }

        public TrenerDTO GetById(int id)
        {
            string queryText = "SELECT * FROM Trener WHERE trener_id = @trener_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("klient_id", id);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    return new TrenerDTO(
                        reader.GetInt32(reader.GetOrdinal("trener_id")),
                        reader.GetString(reader.GetOrdinal("jmeno")),
                        reader.GetString(reader.GetOrdinal("prijmeni")),
                        reader.GetDateTime(reader.GetOrdinal("datum_narozeni")),
                        reader.GetString(reader.GetOrdinal("email")),
                        reader.GetString(reader.GetOrdinal("telefon")),
                        reader.GetString(reader.GetOrdinal("specializace")));
                }
                return null;
            }
        }

        public bool Insert(TrenerDTO value)
        {
            string queryText = "INSERT INTO Trener(trener_id, jmeno, prijmeni, datum_narozeni, email, telefon, specializace) VALUES(@trener_id, @jmeno, @prijmeni, @datum_narozeni, @email, @telefon, @specializace)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = queryText;
                sqlCommand.Parameters.AddWithValue("trener_id", value.Id);
                sqlCommand.Parameters.AddWithValue("jmeno", value.Jmeno);
                sqlCommand.Parameters.AddWithValue("prijmeni", value.Prijmeni);
                sqlCommand.Parameters.AddWithValue("datum_narozeni", value.DatumNarozeni.ToString());
                sqlCommand.Parameters.AddWithValue("email", value.Email);
                sqlCommand.Parameters.AddWithValue("telefon", value.Telefon);
                sqlCommand.Parameters.AddWithValue("specializace", value.Specializace);
                int result = sqlCommand.ExecuteNonQuery();
                if (result == 1)
                {
                    sqlCommand.Dispose();
                    conn.Close(); 
                    return true;  
                }
            }
            return false;
        }

        public bool Update(TrenerDTO value)
        {
            string queryText = "UPDATE Trener SET trener_id = @trener_id, jmeno = @jmeno, prijmeni = @prijmeni, datum_narozeni = @datum_narozeni, email = @email, telefon = @telefon, specializace = @specializace" +
                " WHERE trener_id = @trener_id";

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
                sqlCommand.Parameters.AddWithValue("specialiazce", value.Specializace);
                int result = sqlCommand.ExecuteNonQuery();
                if (result >= 1) return true;
            }
            return false;
        }
    }
}
