using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ContosoMedicalUtilities
{
    public class ContosoMedicalDAC
    {
        public int GetNumberOfDoctors()
        {
            int result = 0;

            SqlConnection connection = null;
            try
            {
                connection = GetConnection();
                string sql = "select count(*) from Doctors";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                result = (int)command.ExecuteScalar();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public SqlDataReader GetAllDoctors()
        {
            SqlConnection connection = GetConnection();
            string sql =
            "select DoctorID, FirstName, LastName, Speciality from Doctors";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(
            CommandBehavior.CloseConnection);
            return reader;
        }

        public List<Doctor> GetDoctorsForSpecialty(string specialty, out int doctorCount, out int specialtyCount)
        {
            List<Doctor> doctors = new List<Doctor>();
            doctorCount = 0;
            specialtyCount = 0;

            SqlConnection connection = null;
            try
            {
                connection = GetConnection();
                SqlCommand command = new SqlCommand("uspGetDoctorsForSpeciality", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@speciality", specialty);

                SqlParameter doctorCountParam = new SqlParameter("@doctorCount", SqlDbType.Int);
                doctorCountParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(doctorCountParam);

                SqlParameter returnValueParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                returnValueParam.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnValueParam);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        doctors.Add(doctor);
                    }
                }
                doctorCount = (int)command.Parameters["@doctorCount"].Value;
                specialtyCount = (int)command.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }


            return doctors;
        }

        private SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ContosoMedicalDBConnectionString"];
            if (settings != null)
            {
                string ConnectionString = settings.ConnectionString;
                connection = new SqlConnection(ConnectionString);
            }
            return connection;
        }
    }

}

