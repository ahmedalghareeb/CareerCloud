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
    public class CompanyJobsDescriptionController : ControllerBase
    {

        private readonly CompanyJobDescriptionLogic _logic;

        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobDescription/{companyJobDescriptionId}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public ActionResult GetCompanyJobsDescription(Guid companyJobDescriptionId)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(companyJobDescriptionId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobDescription")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public ActionResult GetCompanyJobsDescription()
        {

            List<CompanyJobDescriptionPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("jobDescription")]
        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            _logic.Add(companyJobDescriptionPocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobDescription")]
        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            _logic.Update(companyJobDescriptionPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("jobDescription")]
        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            _logic.Delete(companyJobDescriptionPocos);
            return Ok();
        }
    }
}
