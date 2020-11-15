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
    public class CompanyProfileRepository :ConnectionADO, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                                   ([Id]
                                                   ,[Registration_Date]
                                                   ,[Company_Website]
                                                   ,[Contact_Phone]
                                                   ,[Contact_Name]
                                                   ,[Company_Logo])
                                             VALUES
                                                   (@Id
                                                   ,@RegistrationDate
                                                   ,@CompanyWebsite
                                                   ,@ContactPhone
                                                   ,@ContactName
                                                   ,@CompanyLogo)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsite", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@ContactPhone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@ContactName", item.ContactName);
                    cmd.Parameters.AddWithValue("@CompanyLogo", item.CompanyLogo);
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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from  [dbo].[Company_Profiles]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                CompanyProfilePoco[] pocos = new CompanyProfilePoco[10000];
                int counter = 0;

                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.RegistrationDate = (DateTime)reader["Registration_Date"];
                    poco.CompanyWebsite = reader.IsDBNull(2) ? (string) null : (string)reader["Company_Website"];
                    poco.ContactPhone = (string)reader["Contact_Phone"];
                    poco.ContactName = reader.IsDBNull(4) ? (string) null : (string)reader["Contact_Name"];
                    poco.CompanyLogo = reader.IsDBNull(5) ? (byte[]) null : (byte[])reader["Company_Logo"];
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();

                return pocos.Where(p => p != null).ToList();
            }

        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Profiles]
                                    WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                                               SET
                                                    [Registration_Date] = @RegistrationDate
                                                   ,[Company_Website] = @CompanyWebsite
                                                   ,[Contact_Phone] = @ContactPhone
                                                   ,[Contact_Name] = @ContactName
                                                   ,[Company_Logo] = @CompanyLogo
                                             WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsite", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@ContactPhone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@ContactName", item.ContactName);
                    cmd.Parameters.AddWithValue("@CompanyLogo", item.CompanyLogo);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
