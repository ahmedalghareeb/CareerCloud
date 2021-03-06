﻿using CareerCloud.BusinessLogicLayer;
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
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("description/{companyDescriptionId}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public ActionResult GetCompanyDescription(Guid companyDescriptionId)
        {
            CompanyDescriptionPoco poco = _logic.Get(companyDescriptionId);

            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        
        [HttpGet]
        [Route("description")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]
        public ActionResult GetAllCompanyDescription()
        {

            List<CompanyDescriptionPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);

        }

        [HttpPost]
        [Route("description")]
        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            _logic.Add(companyDescriptionPocos);
            return Ok();
        }

        [HttpPut]
        [Route("description")]
        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            _logic.Update(companyDescriptionPocos);
            return Ok();
        }
        [HttpDelete]
        [Route("description")]
        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            _logic.Delete(companyDescriptionPocos);
            return Ok();
        }


    }
}
