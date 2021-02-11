using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> repo = new EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("skill/{applicantSkillId}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public ActionResult GetApplicantSkill(Guid applicantSkillId)
        {

            ApplicantSkillPoco poco = _logic.Get(applicantSkillId);

            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        [HttpGet]
        [Route("skill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public ActionResult GetAllApplicantSkill()
        {

            List<ApplicantSkillPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("skill")]
        public ActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkillPocos)
        {
            _logic.Add(applicantSkillPocos);
            return Ok();
        }

        [HttpPut]
        [Route("skill")]
        public ActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkillPocos)
        {
            _logic.Update(applicantSkillPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("skill")]
        public ActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkillPocos)
        {
            _logic.Delete(applicantSkillPocos);
            return Ok();
        }
    }
}
