using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repo) : base(repo) { }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
                if(string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, "must ends in .ca , .com, or .biz"));
                }
                else if (!poco.CompanyWebsite.EndsWith(".ca") || !poco.CompanyWebsite.EndsWith(".com") 
                    || !poco.CompanyWebsite.EndsWith(".biz"))
                {
                    exceptions.Add(new ValidationException(600, "must ends in .ca , .com, or .biz"));
                }
                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, "phone number must mach XXX-XXX-XXXX"));
                }
                else if (!Regex.Match(poco.ContactPhone, @"^(\+[0-9]{10})$").Success)
                {
                    exceptions.Add(new ValidationException(601, "phone number must mach XXX-XXX-XXXX"));
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
