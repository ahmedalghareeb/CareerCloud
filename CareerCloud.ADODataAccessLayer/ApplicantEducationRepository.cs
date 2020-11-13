using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq.Expressions;
using System.Text;


namespace CareerCloud.ADODataAccessLayer
{
  public  class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {

        protected readonly string _connStr = string.Empty;

        public ApplicantEducationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;

        }
        public void Add(params ApplicantEducationPoco[] items)
        {
            
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantEducationPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                                   ([Id]
                                   ,[Applicant]
                                   ,[Major]
                                   ,[Certificate_Diploma]
                                   ,[Start_Date]
                                   ,[Completion_Date]
                                   ,[Completion_Percent])
                                   VALUES
                                   (@Id,
                                    @Applicant, 
                                    @Major,
                                    @CertificateDiploma,
                                    @StartDate, 
                                    @CompletionDate,
                                    @CompletionPercent)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }


        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();

        }

        public void Remove(params ApplicantEducationPoco[] items)
        {

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantEducationPoco item in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Educations]
                                    WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                
                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantEducationPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                    SET [Id] = @Id
                                   ,[Applicant] = @Applicant
                                   ,[Major] = @Major
                                   ,[Certificate_Diploma] = @CertificateDiploma
                                   ,[Start_Date] = @StartDate
                                   ,[Completion_Date] = @CompletionDate
                                   ,[Completion_Percent] = @CompletionPercent
                                    WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
    }
}
