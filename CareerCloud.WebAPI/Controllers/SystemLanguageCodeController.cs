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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemLanguageCodeController : ControllerBase
    {
        private readonly SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("language/{systemLanguageCodeId}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public ActionResult GetSystemLanguageCode(String systemLanguageCodeId)
        {
            SystemLanguageCodePoco poco = _logic.Get(systemLanguageCodeId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("language")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public ActionResult GetAllSystemLanguageCode()
        {

            List<SystemLanguageCodePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("language")]
        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            _logic.Add(systemLanguageCodePocos);
            return Ok();
        }

        [HttpPut]
        [Route("language")]
        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            _logic.Update(systemLanguageCodePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("language")]
        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            _logic.Delete(systemLanguageCodePocos);
            return Ok();
        }

    }
}
