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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{securityLoginId")]

        public ActionResult GetSecurityLogin(Guid securityLoginId)
        {
            SecurityLoginPoco poco = _logic.Get(securityLoginId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("login/}")]
        public ActionResult GetAllSecurityLogin()
        {

            List<SecurityLoginPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("login/")]
        public ActionResult PostSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            _logic.Add(securityLoginPocos);
            return Ok();
        }

        [HttpPut]
        [Route("login/")]
        public ActionResult PutSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            _logic.Update(securityLoginPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("login/")]
        public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            _logic.Delete(securityLoginPocos);
            return Ok();
        }


    }
}
