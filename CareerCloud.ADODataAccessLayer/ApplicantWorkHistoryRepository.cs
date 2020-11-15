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
    public class ApplicantWorkHistoryRepository : ConnectionADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
                                                   ([Id]
                                                   ,[Applicant]
                                                   ,[Company_Name]
                                                   ,[Country_Code]
                                                   ,[Location]
                                                   ,[Job_Title]
                                                   ,[Job_Description]
                                                   ,[Start_Month]
                                                   ,[Start_Year]
                                                   ,[End_Month]
                                                   ,[End_Year])
                                             VALUES
                                                   (@Id
                                                   ,@Applicant
                                                   ,@CompanyName
                                                   ,@CountryCode
                                                   ,@Location
                                                   ,@JobTitle
                                                   ,@JobDescription
                                                   ,@StartMonth
                                                   ,@StartYear
                                                   ,@EndMonth
                                                   ,@EndYear)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
                    cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                    cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                    cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                    cmd.Parameters.AddWithValue("@EndYear", item.EndYear);
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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from [dbo].[Applicant_Work_History]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1000];
                int counter = 0;
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.Applicant = (Guid)reader["Applicant"];
                    poco.CompanyName = (string)reader["Company_Name"];
                    poco.CountryCode = (string)reader["Country_Code"];
                    poco.Location = (string)reader["Location"];
                    poco.JobTitle = (string)reader["Job_Title"];
                    poco.JobDescription = (string)reader["Job_Description"];
                    poco.StartMonth = (short)reader["Start_Month"];
                    poco.StartYear = (int)reader["Start_Year"];
                    poco.EndMonth = (short)reader["End_Month"];
                    poco.EndYear = (int)reader["End_Year"];
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();

                return pocos.Where(p => p != null).ToList();
            }

        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Work_History]
                                    WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                                               SET
                                                    [Applicant] = @Applicant
                                                   ,[Company_Name] = @CompanyName
                                                   ,[Country_Code] = @CountryCode
                                                   ,[Location] = @Location
                                                   ,[Job_Title] = @JobTitle
                                                   ,[Job_Description] = @JobDescription
                                                   ,[Start_Month] = @StartMonth
                                                   ,[Start_Year] = @StartYear
                                                   ,[End_Month] = @EndMonth
                                                   ,[End_Year] = @EndYear
                                             WHERE
                                                  [Id] =  @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
                    cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                    cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                    cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                    cmd.Parameters.AddWithValue("@EndYear", item.EndYear);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
