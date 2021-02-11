using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System.Web.Http.Description;

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
        [Route("education/{companyJobEducationId}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]
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
        [Route("education")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
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
        [Route("education")]
        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            _logic.Add(companyJobEducationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            _logic.Update(companyJobEducationPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("education")]
        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            _logic.Delete(companyJobEducationPocos);
            return Ok();
        }
    }
}
