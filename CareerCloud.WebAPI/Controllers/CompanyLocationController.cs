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
    public class CompanyLocationController : ControllerBase
    {

        private readonly CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("location/{companyLocationId}")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public ActionResult GetCompanyLocation(Guid companyLocationId)
        {
            CompanyLocationPoco poco = _logic.Get(companyLocationId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("location")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public ActionResult GetAllCompanyLocation()
        {

            List<CompanyLocationPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("location")]
        public ActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] companyLocationPocos)
        {
            _logic.Add(companyLocationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("location")]
        public ActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] companyLocationPocos)
        {
            _logic.Update(companyLocationPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("location")]
        public ActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] companyLocationPocos)
        {
            _logic.Delete(companyLocationPocos);
            return Ok();
        }
    }
}
