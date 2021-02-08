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
    public class CompanyJobEducationController : ControllerBase
    {
        private readonly CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/{companyJobEducationId")]

        public ActionResult GetCompanyJobEducation(Guid companyJobEducationId)
        {
            CompanyJobEducationPoco poco = _logic.Get(companyJobEducationId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("education/}")]
        public ActionResult GetAllCompanyJobEducation()
        {

            List<CompanyJobEducationPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("education/")]
        public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            _logic.Add(companyJobEducationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("education/")]
        public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            _logic.Update(companyJobEducationPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("education/")]
        public ActionResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            _logic.Delete(companyJobEducationPocos);
            return Ok();
        }
    }
}
