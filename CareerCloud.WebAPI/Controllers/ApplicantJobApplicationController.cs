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
    public class ApplicantJobApplicationController : ControllerBase
    {
        private readonly ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("application/{applicantJobApplicationId}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public ActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        {

            ApplicantJobApplicationPoco poco = _logic.Get(applicantJobApplicationId);

            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        [HttpGet]
        [Route("application")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public ActionResult GetAllApplicantJobApplication()
        {

            List<ApplicantJobApplicationPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("application")]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            _logic.Add(applicantJobApplicationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("application")]
        public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            _logic.Update(applicantJobApplicationPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("application")]
        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            _logic.Delete(applicantJobApplicationPocos);
            return Ok();
        }

    }
}
