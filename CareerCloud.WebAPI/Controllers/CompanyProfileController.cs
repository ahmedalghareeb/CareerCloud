using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/{companyProfileId")]

        public ActionResult GetCompanyProfile(Guid companyProfileId)
        {
            CompanyProfilePoco poco = _logic.Get(companyProfileId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("profile/}")]
        public ActionResult GetAllCompanyProfile()
        {

            List<CompanyProfilePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("profile/")]
        public ActionResult PostCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            _logic.Add(companyProfilePocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile/")]
        public ActionResult PutCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            _logic.Update(companyProfilePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("profile/")]
        public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            _logic.Delete(companyProfilePocos);
            return Ok();
        }
    }
}
