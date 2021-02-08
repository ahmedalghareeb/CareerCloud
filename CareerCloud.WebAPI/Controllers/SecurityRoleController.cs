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
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/{securityRoleId")]

        public ActionResult GetSecurityRole(Guid securityRoleId)
        {
            SecurityRolePoco poco = _logic.Get(securityRoleId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("role/}")]
        public ActionResult GetAllSecurityRole()
        {

            List<SecurityRolePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("role/")]
        public ActionResult PostSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            _logic.Add(securityRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("role/")]
        public ActionResult PutSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            _logic.Update(securityRolePocos);
            return Ok();
        }
        [HttpDelete]
        [Route("role/")]
        public ActionResult DeleteSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            _logic.Delete(securityRolePocos);
            return Ok();
        }

    }
}
