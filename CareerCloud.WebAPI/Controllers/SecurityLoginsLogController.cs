﻿using Microsoft.AspNetCore.Http;
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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private readonly SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginLog/{securityLoginsLogId}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]
        public ActionResult GetSecurityLoginLog(Guid securityLoginsLogId)
        {
            SecurityLoginsLogPoco poco = _logic.Get(securityLoginsLogId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("loginLog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public ActionResult GetAllSecurityLoginLog()
        {

            List<SecurityLoginsLogPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("loginLog")]
        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            _logic.Add(securityLoginsLogPocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginLog")]
        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            _logic.Update(securityLoginsLogPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("loginLog")]
        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            _logic.Delete(securityLoginsLogPocos);
            return Ok();
        }

    }
}
