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
    public class SecurityLoginsLogRepository : ConnectionADO, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                                   ([Id]
                                                   ,[Login]
                                                   ,[Source_IP]
                                                   ,[Logon_Date]
                                                   ,[Is_Succesful])
                                             VALUES
                                                   (@Id
                                                   ,@Login
                                                   ,@SourceIP
                                                   ,@LogonDate
                                                   ,@IsSuccesful)       ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@SourceIP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@LogonDate", item.LogonDate);
                    cmd.Parameters.AddWithValue("@IsSuccesful", item.IsSuccesful);

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

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from [dbo].[Security_Logins_Log]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[10000];
                int counter = 0;

                while (reader.Read())
                {
                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.Login = (Guid)reader["Login"];
                    poco.LogonDate = (DateTime)reader["Logon_Date"];
                    poco.SourceIP = (string)reader["Source_IP"];
                    poco.IsSuccesful = (bool)reader["Is_Succesful"];
                    

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();

                return pocos.Where(p => p != null).ToList();
            }

        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins_Log]
                                    WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Log]
                                               SET
                                                    [Login] = @Login
                                                   ,[Source_IP] = @SourceIP
                                                   ,[Logon_Date] = @LogonDate
                                                   ,[Is_Succesful] = @IsSuccesful
                                             WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@SourceIP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@LogonDate", item.LogonDate);
                    cmd.Parameters.AddWithValue("@IsSuccesful", item.IsSuccesful);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
