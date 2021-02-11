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
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> repo = new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("resume/{applicantResumeId}")]
        [ResponseType(typeof(ApplicantResumePoco))]
        public ActionResult GetApplicantResume(Guid applicantResumeId)
        {

            ApplicantResumePoco poco = _logic.Get(applicantResumeId);

            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        [HttpGet]
        [Route("resume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]
        public ActionResult GetAllApplicantResume()
        {

            List<ApplicantResumePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("resume")]
        public ActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] applicantResumePocos)
        {
            _logic.Add(applicantResumePocos);
            return Ok();
        }

        [HttpPut]
        [Route("resume")]
        public ActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] applicantResumePocos)
        {
            _logic.Update(applicantResumePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("resume")]
        public ActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] applicantResumePocos)
        {
            _logic.Delete(applicantResumePocos);
            return Ok();
        }

    }
}
