using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : ConnectionADO, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                                   ([Id]
                                                   ,[Login]
                                                   ,[Current_Salary]
                                                   ,[Current_Rate]
                                                   ,[Currency]
                                                   ,[Country_Code]
                                                   ,[State_Province_Code]
                                                   ,[Street_Address]
                                                   ,[City_Town]
                                                   ,[Zip_Postal_Code])
                                             VALUES
                                                   (@Id 
                                                   ,@Login 
                                                   ,@CurrentSalary
                                                   ,@CurrentRate
                                                   ,@Currency
                                                   ,@Country
                                                   ,@Province
                                                   ,@Street
                                                   ,@City
                                                   ,@PostalCode)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country", item.Country);
                    cmd.Parameters.AddWithValue("@Province", item.Province);
                    cmd.Parameters.AddWithValue("@Street", item.Street);
                    cmd.Parameters.AddWithValue("@City", item.City);
                    cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);
              
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from [dbo].[Applicant_Profiles]";
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
                int counter = 0;

                while (reader.Read())
                {

                    ApplicantProfilePoco poco = new ApplicantProfilePoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.Login = (Guid)reader["Login"];
                    poco.CurrentSalary = (decimal)reader["Current_Salary"];
                    poco.CurrentRate = (decimal)reader["Current_Rate"];
                    poco.Currency = (string)reader["Currency"];
                    poco.Country = (string)reader["Country_Code"];
                    poco.Province = (string)reader["State_Province_Code"];
                    poco.Street = (string)reader["Street_Address"];
                    poco.City = (string)reader["City_Town"];
                    poco.PostalCode = (string)reader["Zip_Postal_Code"];
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];

                    pocos[counter] = poco;
                    counter++;

                }
                conn.Close();
                return pocos.Where(p => p != null).ToList();

            }

        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
           
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Profiles]
                                    WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                                        SET
                                                    [Login] = @Login 
                                                   ,[Current_Salary] = @CurrentSalary
                                                   ,[Current_Rate] = @CurrentRate
                                                   ,[Currency] = @Currency
                                                   ,[Country_Code] = @Country
                                                   ,[State_Province_Code] = @Province
                                                   ,[Street_Address] = @Street
                                                   ,[City_Town] = @City
                                                   ,[Zip_Postal_Code] = @PostalCode
                                        WHERE       [Id] = @Id";
                     
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country", item.Country);
                    cmd.Parameters.AddWithValue("@Province", item.Province);
                    cmd.Parameters.AddWithValue("@Street", item.Street);
                    cmd.Parameters.AddWithValue("@City", item.City);
                    cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
