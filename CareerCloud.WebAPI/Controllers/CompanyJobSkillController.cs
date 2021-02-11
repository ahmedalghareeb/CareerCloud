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
    public class CompanyJobSkillController : ControllerBase
    {
        private readonly CompanyJobSkillLogic _logic;

        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("jobSkill/{companyJobSkillId}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]
        public ActionResult GetCompanyJobSkill(Guid companyJobSkillId)
        {
            CompanyJobSkillPoco poco = _logic.Get(companyJobSkillId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobSkill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]
        public ActionResult GetAllCompanyJobSkill()
        {

            List<CompanyJobSkillPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("jobSkill")]
        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            _logic.Add(companyJobSkillPocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobSkill")]
        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            _logic.Update(companyJobSkillPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("jobSkill")]
        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            _logic.Delete(companyJobSkillPocos);
            return Ok();
        }

    }
}
