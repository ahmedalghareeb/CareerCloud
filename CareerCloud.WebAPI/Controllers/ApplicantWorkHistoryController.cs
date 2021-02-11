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
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()

        {
            EFGenericRepository<ApplicantWorkHistoryPoco> repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("work/{applicantWorkId}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public ActionResult GetApplicantWorkHistory(Guid applicantWorkId)
        {

            ApplicantWorkHistoryPoco poco = _logic.Get(applicantWorkId);

            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        [HttpGet]
        [Route("work")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public ActionResult GetAllApplicantWorkHistory()
        {

            List<ApplicantWorkHistoryPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("work")]
        public ActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
        {
            _logic.Add(applicantWorkHistoryPocos);
            return Ok();
        }

        [HttpPut]
        [Route("work")]
        public ActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
        {
            _logic.Update(applicantWorkHistoryPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("work")]
        public ActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
        {
            _logic.Delete(applicantWorkHistoryPocos);
            return Ok();
        }
    }
}
