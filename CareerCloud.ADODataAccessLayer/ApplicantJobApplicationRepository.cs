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
    public class ApplicantJobApplicationRepository : ConnectionADO, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"
                                    INSERT INTO [dbo].[Applicant_Job_Applications]
                                               ([Id]
                                               ,[Applicant]
                                               ,[Job]
                                               ,[Application_Date])
                                         VALUES
                                               (@Id
                                                ,@Applicant
                                               ,@Job
                                               ,@ApplicationDate)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", item.ApplicationDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
               

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from [dbo].[Applicant_Job_Applications]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1000];
                int counter = 0;

                while (reader.Read())
                {
                    ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.Applicant = (Guid)reader["Applicant"];
                    poco.Job = (Guid)reader["Job"];
                    poco.ApplicationDate = (DateTime)reader["Application_Date"];
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();
                return pocos.Where(pocos => pocos != null).ToList();
            }



        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantJobApplicationPoco item in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Job_Applications]
                                    WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);

                conn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.CommandText = @"update [dbo].[Applicant_Job_Applications]
                                    SET
                                               [Applicant] = @Applicant
                                               ,[Job] = @Job
                                               ,[Application_Date] = @ApplicationDate
                                    WHERE       [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", item.ApplicationDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
                


        }
    }
}
