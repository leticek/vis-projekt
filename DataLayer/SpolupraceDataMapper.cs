using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SpolupraceDataMapper : ISQLDataMapper<Spoluprace>
    {
        private readonly string connectionString = "server=dbsys.cs.vsb.cz\\STUDENT;database=smi0114;user=smi0114;password=rMLsTuYdah;";
        public bool Delete(int id)
        {
            string queryText = "DELETE FROM Spoluprace WHERE spoluprace_id = @spoluprace_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = conn.CreateCommand();
                    sqlCommand.CommandText = queryText;
                    sqlCommand.Parameters.AddWithValue("spoluprace_id", id);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result >= 1) return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return false;
        }
        public Spoluprace GetById(int id)
        {
            string queryText = "SELECT * FROM Spoluprace WHERE spoluprace_id = @spoluprace_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = conn.CreateCommand();
                    sqlCommand.CommandText = queryText;
                    sqlCommand.Parameters.AddWithValue("spoluprace_id", id);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Spoluprace(
                            reader.GetInt32(reader.GetOrdinal("spoluprace_id")),
                            reader.GetInt32(reader.GetOrdinal("trener_id")),
                            reader.GetDateTime(reader.GetOrdinal("platnost")),
                            (decimal)reader.GetSqlMoney(reader.GetOrdinal("cena")));
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool Insert(Spoluprace value)
        {
            string queryText = "INSERT INTO Spoluprace(spoluprace_id, cena, platnost, trener_id) VALUES(@spoluprace_id, @cena, @platnost, @trener_id)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = conn.CreateCommand();
                    sqlCommand.CommandText = queryText;
                    sqlCommand.Parameters.AddWithValue("spoluprace_id", value.SpolupraceId);
                    sqlCommand.Parameters.AddWithValue("cena", value.Cena);
                    sqlCommand.Parameters.AddWithValue("platnost", value.Platnost);
                    sqlCommand.Parameters.AddWithValue("trener_id", value.TrenerId);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        sqlCommand.Dispose();
                        conn.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return false;
        }

        public bool Update(Spoluprace value)
        {
            string queryText = "UPDATE Spoluprace SET spoluprace_id = @spoluprace_id, cena = @cena, platnost = @platnost, trener_id = @trener_id WHERE spoluprace_id = @spoluprace_id";
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = conn.CreateCommand();
                    sqlCommand.CommandText = queryText;
                    sqlCommand.Parameters.AddWithValue("spoluprace_id", value.SpolupraceId);
                    sqlCommand.Parameters.AddWithValue("cena", value.Cena);
                    sqlCommand.Parameters.AddWithValue("platnost", value.Platnost);
                    sqlCommand.Parameters.AddWithValue("trener_id", value.TrenerId);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result >= 1) return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return false;
        }
    }
}
