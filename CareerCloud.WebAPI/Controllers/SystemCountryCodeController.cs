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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private readonly SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("country/{systemCountryCodeId")]

        public ActionResult GetSystemCountryCode(String systemCountryCodeId)
        {
            SystemCountryCodePoco poco = _logic.Get(systemCountryCodeId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("country/}")]
        public ActionResult GetAllSystemCountryCode()
        {

            List<SystemCountryCodePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("country/")]
        public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            _logic.Add(systemCountryCodePocos);
            return Ok();
        }

        [HttpPut]
        [Route("country/")]
        public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            _logic.Update(systemCountryCodePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("country/")]
        public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            _logic.Delete(systemCountryCodePocos);
            return Ok();
        }
    }
}
