using System;
using System.Data;
using System.Data.SqlClient;


namespace ContactsDataAccessLayer
{
    public class clsCountriesDataAccess
    {
        public static bool GetCountriesInfoByID(int ID, ref string CountryName, ref string Code, ref string PhoneCode)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string query = "select * from Countries where CountryID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
           
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    if (reader["CountryName"] != DBNull.Value)
                    {
                        CountryName = (string)reader["CountryName"];
                    }
                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }
                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close(); 
            }

            return IsFound;
        }

        public static int AddNewCountry(string CountryName, string Code, string PhoneCode)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string query = @"insert into Countries(CountryName, Code, PhoneCode)
                              values (@CountryName, @Code, @PhoneCode); select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@PhoneCode", PhoneCode);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }
            catch (Exception ex)
            {
                ///later;
            }
            finally
            {
                connection.Close(); 
            }

            return ID;
        }

        public static bool UpdateCountry(int ID, string CountryName, string Code, string PhoneCode)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection (clsConnection.ConnectionString);
            string query = @"update Countries set CountryName = @CountryName, Code = @Code, PhoneCode = @PhoneCode
                            where CountryID = @ID";

            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            if (CountryName != "")
            {
                command.Parameters.AddWithValue("@CountryName", CountryName);
            }
            else
            {
                command.Parameters.AddWithValue("@CountryName",System.DBNull.Value);
            }
            if(Code != null)
            {
                command.Parameters.AddWithValue("@Code", Code);
            }
            else
            {
                command.Parameters.AddWithValue("@Code", System.DBNull.Value);
            }
            if(Code != null)
            {
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            }
            else
            {
                command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);
            }

                try
                {
                    connection.Open();

                    AffectedRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }

            return (AffectedRows > 0);
        }

        public static bool DeleteCountry(int ID)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string query = "delete from Countries where CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            { 
                return false;
            }
            finally 
            {
                connection.Close();
            }

            return (AffectedRows > 0);

        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string query = "select * from Countries;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool IsCountryExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            string query = "select Found = 1 from Countries where CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

    }
}
