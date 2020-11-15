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
    public class ApplicantSkillRepository : ConnectionADO, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Skills]
                                                   ([Id]
                                                   ,[Applicant]
                                                   ,[Skill]
                                                   ,[Skill_Level]
                                                   ,[Start_Month]
                                                   ,[Start_Year]
                                                   ,[End_Month]
                                                   ,[End_Year])
                                             VALUES
                                                   (@Id
                                                   ,@Applicant
                                                   ,@Skill
                                                   ,@SkillLevel
                                                   ,@StartMonth
                                                   ,@StartYear
                                                   ,@EndMonth
                                                   ,@EndYear)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@SkillLevel", item.SkillLevel);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from [dbo].[Applicant_Skills]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1000];
                int counter = 0;

                while (reader.Read())
                {
                   
                    ApplicantSkillPoco poco = new ApplicantSkillPoco();
                    poco.Id = (Guid)reader["Id"];
                    poco.Applicant = (Guid)reader["Applicant"];
                    poco.Skill = (string)reader["Skill"];
                    poco.SkillLevel = (string)reader["Skill_Level"];
                    poco.StartMonth = (byte)reader["Start_Month"];
                    poco.StartYear = (int)reader["Start_Year"];
                    poco.EndMonth = (byte)reader["End_Month"];
                    poco.EndYear = (int)reader["End_Year"];
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];
                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();

                return pocos.Where(p => p != null).ToList();
            }


        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Skills]
                                    WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Skills]
                                             SET    [Applicant] = @Applicant
                                                   ,[Skill] = @Skill
                                                   ,[Skill_Level] = @SkillLevel
                                                   ,[Start_Month] = @StartMonth
                                                   ,[Start_Year] = @StartYear
                                                   ,[End_Month] = @EndMonth
                                                   ,[End_Year] = @EndYear
                                             WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@SkillLevel", item.SkillLevel);
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
