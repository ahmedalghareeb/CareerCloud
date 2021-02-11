using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/{applicantEducationId}")]
        [ResponseType(typeof(ApplicantEducationPoco))]
        public ActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            
            ApplicantEducationPoco poco = _logic.Get(applicantEducationId);

            if (poco == null)
            {
                return NotFound();
            }
                
            return Ok(poco);
            
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]
        public ActionResult GetAllApplicantEducation()
        {

            List<ApplicantEducationPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("education")]
        public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducationPocos)
        {
                _logic.Add(applicantEducationPocos);
                return Ok();
        }

        [HttpPut]
        [Route("education")]
        public ActionResult PutApplicantEducation([FromBody]  ApplicantEducationPoco[] applicantEducationPocos)
        {
            _logic.Update(applicantEducationPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("education")]
        public ActionResult DeleteApplicantEducation([FromBody]  ApplicantEducationPoco[] applicantEducationPocos)
        {
            _logic.Delete(applicantEducationPocos);
            return Ok();
        }




    }
}
