using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext: DbContext
    {
        ConnectionEF connection = new ConnectionEF();
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobs { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection._connStr); //@"Data Source=DESKTOP-E6QJ4KL\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany<CompanyDescriptionPoco>(slc => slc.CompanyDescriptions)
                .WithOne(cd => cd.SystemLanguageCode)
                .HasForeignKey(sc => sc.LanguageId);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany<CompanyDescriptionPoco>(cp => cp.CompanyDescriptions)
                .WithOne(cd => cd.CompanyProfile)
                .HasForeignKey(cp => cp.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany<CompanyJobPoco>(cp => cp.CompanyJobs)
                .WithOne(cj => cj.CompanyProfile)
                .HasForeignKey(cp => cp.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
               .HasMany<CompanyLocationPoco>(cp => cp.CompanyLocations)
               .WithOne(cd => cd.CompanyProfile)
               .HasForeignKey(cp => cp.Company);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany<CompanyJobDescriptionPoco>(cp => cp.CompanyJobDescriptions)
                .WithOne(cjd => cjd.CompanyJob)
                .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany<CompanyLocationPoco>(scc => scc.CompanyLocations)
                .WithOne(cl => cl.SystemCountryCode)
                .HasForeignKey(scc => scc.CountryCode);

            modelBuilder.Entity<SystemCountryCodePoco>()
              .HasMany<ApplicantProfilePoco>(scc => scc.ApplicantProfiles)
              .WithOne(ap => ap.SystemCountryCode)
              .HasForeignKey(scc => scc.Country);

            modelBuilder.Entity<SystemCountryCodePoco>()
              .HasMany<ApplicantWorkHistoryPoco>(scc => scc.ApplicantWorkHistorys)
              .WithOne(awh => awh.SystemCountryCode)
              .HasForeignKey(scc => scc.CountryCode);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany<ApplicantEducationPoco>(ap => ap.ApplicantEducations)
                .WithOne(ae => ae.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany<ApplicantJobApplicationPoco>(ap => ap.ApplicantJobApplications)
                .WithOne(ae => ae.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany<ApplicantResumePoco>(ap => ap.ApplicantResumes)
                .WithOne(ar => ar.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany<ApplicantSkillPoco>(ap => ap.ApplicantSkills)
               .WithOne(asp => asp.ApplicantProfile)
               .HasForeignKey(ap => ap.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
              .HasMany<ApplicantWorkHistoryPoco>(ap => ap.ApplicantWorkHistorys)
              .WithOne(awh => awh.ApplicantProfile)
              .HasForeignKey(ap => ap.Applicant);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany<ApplicantJobApplicationPoco>(cj => cj.ApplicantJobApplications)
                .WithOne(aja => aja.CompanyJob)
                .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany<CompanyJobEducationPoco>(cj => cj.CompanyJobEducations)
                .WithOne(aja => aja.CompanyJob)
                .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany<CompanyJobSkillPoco>(cj => cj.CompanyJobSkills)
                .WithOne(aja => aja.CompanyJob)
                .HasForeignKey(cj => cj.Job);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany<SecurityLoginsLogPoco>(sl => sl.SecurityLoginsLogs)
                .WithOne(sll => sll.SecurityLogin)
                .HasForeignKey(sl => sl.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany<SecurityLoginsRolePoco>(sl => sl.SecurityLoginsRoles)
                .WithOne(sll => sll.SecurityLogin)
                .HasForeignKey(sl => sl.Login);

            modelBuilder.Entity<SecurityRolePoco>()
                 .HasMany<SecurityLoginsRolePoco>(sr => sr.SecurityLoginsRoles)
                 .WithOne(sll => sll.SecurityRole)
                 .HasForeignKey(sl => sl.Role);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany<ApplicantProfilePoco>(sl => sl.ApplicantProfiles)
                .WithOne(ap => ap.SecurityLogin)
                .HasForeignKey(sl => sl.Login);

            base.OnModelCreating(modelBuilder);
        }
    }
}
