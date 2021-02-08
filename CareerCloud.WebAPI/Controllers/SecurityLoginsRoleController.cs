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
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            EFGenericRepository<SecurityLoginsRolePoco> repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginRole/{securityLoginsRoleId")]

        public ActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
        {
            SecurityLoginsRolePoco poco = _logic.Get(securityLoginsRoleId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("loginRole/}")]
        public ActionResult GetAllSecurityLoginsRole()
        {

            List<SecurityLoginsRolePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("loginRole/")]
        public ActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            _logic.Add(securityLoginsRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginRole/")]
        public ActionResult PutSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            _logic.Update(securityLoginsRolePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("loginRole/")]
        public ActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            _logic.Delete(securityLoginsRolePocos);
            return Ok();
        }

    }
}
