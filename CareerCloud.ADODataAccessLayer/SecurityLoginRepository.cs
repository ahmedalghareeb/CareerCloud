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
    public class SecurityLoginRepository : ConnectionADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                                   ([Id]
                                                   ,[Login]
                                                   ,[Password]
                                                   ,[Created_Date]
                                                   ,[Password_Update_Date]
                                                   ,[Agreement_Accepted_Date]
                                                   ,[Is_Locked]
                                                   ,[Is_Inactive]
                                                   ,[Email_Address]
                                                   ,[Phone_Number]
                                                   ,[Full_Name]
                                                   ,[Force_Change_Password]
                                                   ,[Prefferred_Language])
                                             VALUES
                                                   (@Id
                                                   ,@Login
                                                   ,@Password
                                                   ,@CreatedDate
                                                   ,@PasswordUpdateDate
                                                   ,@AgreementAcceptedDate
                                                   ,@IsLocked
                                                   ,@IsInactive
                                                   ,@EmailAddress
                                                   ,@PhoneNumber
                                                   ,@FullName
                                                   ,@ForceChangePassword
                                                   ,@PrefferredLanguage)
                                        ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", item.Created);
                    cmd.Parameters.AddWithValue("@PasswordUpdateDate", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AgreementAcceptedDate", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLocked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddress", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@ForceChangePassword", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PrefferredLanguage", item.PrefferredLanguage);
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from [dbo].[Security_Logins]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                SecurityLoginPoco[] pocos = new SecurityLoginPoco[1000];
                int counter = 0;
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.Login = (string)reader["Login"];
                    poco.Password = (string)reader["Password"];
                    poco.Created = (DateTime)reader["Created_Date"];
                    poco.PasswordUpdate = reader.IsDBNull(4) ? (DateTime?) null : (DateTime?)reader["Password_Update_Date"];
                    poco.AgreementAccepted = reader.IsDBNull(5) ? (DateTime?)null : (DateTime?)reader["Agreement_Accepted_Date"];
                    poco.IsLocked = (bool)reader["Is_Locked"];
                    poco.IsInactive = (bool)reader["Is_Inactive"];
                    poco.EmailAddress = (string)reader["Email_Address"];
                    poco.PhoneNumber = reader.IsDBNull(9) ? (string) null : (string)reader["Phone_Number"];
                    poco.FullName = (string)reader["Full_Name"];
                    poco.ForceChangePassword = (bool)reader["Force_Change_Password"];
                    poco.PrefferredLanguage = reader.IsDBNull(12) ? (string) null : (string)reader["Prefferred_Language"];
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();

                return pocos.Where(p => p != null).ToList();
            }

        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins]
                                    WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                                              SET
                                                    [Login] = @Login
                                                   ,[Password] = @Password
                                                   ,[Created_Date] = @CreatedDate
                                                   ,[Password_Update_Date] = @PasswordUpdateDate
                                                   ,[Agreement_Accepted_Date] = @AgreementAcceptedDate
                                                   ,[Is_Locked] = @IsLocked
                                                   ,[Is_Inactive] = @IsInactive
                                                   ,[Email_Address] = @EmailAddress
                                                   ,[Phone_Number] = @PhoneNumber
                                                   ,[Full_Name] = @FullName
                                                   ,[Force_Change_Password] = @ForceChangePassword
                                                   ,[Prefferred_Language] = @PrefferredLanguage
                                             WHERE [Id] = @Id ";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", item.Created);
                    cmd.Parameters.AddWithValue("@PasswordUpdateDate", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AgreementAcceptedDate", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLocked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddress", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@ForceChangePassword", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PrefferredLanguage", item.PrefferredLanguage);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
