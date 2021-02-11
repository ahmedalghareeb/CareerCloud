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
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/{applicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public ActionResult GetApplicantProfile(Guid applicantProfileId)
        {

            ApplicantProfilePoco poco = _logic.Get(applicantProfileId);

            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]
        public ActionResult GetAllApplicantProfile()
        {

            List<ApplicantProfilePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("profile")]
        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfilePocos)
        {
            _logic.Add(applicantProfilePocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfilePocos)
        {
            _logic.Update(applicantProfilePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("profile")]
        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfilePocos)
        {
            _logic.Delete(applicantProfilePocos);
            return Ok();
        }
    }
}
