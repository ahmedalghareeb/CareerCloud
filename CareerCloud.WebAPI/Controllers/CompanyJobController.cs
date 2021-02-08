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
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic _logic;

        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("job/{companyJobId")]

        public ActionResult GetCompanyJob(Guid companyDescriptionId)
        {
            CompanyJobPoco poco = _logic.Get(companyDescriptionId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("job/}")]
        public ActionResult GetAllCompanyJob()
        {

            List<CompanyJobPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("job/")]
        public ActionResult PostCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            _logic.Add(companyJobPocos);
            return Ok();
        }

        [HttpPut]
        [Route("job/")]
        public ActionResult PutCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            _logic.Update(companyJobPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("job/")]
        public ActionResult DeleteCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            _logic.Delete(companyJobPocos);
            return Ok();
        }


    }
}
