using Evolent.Demo.Data.Entity;
using Evolent.Demo.Data.Entity.Master;
using Evolent.Demo.Domain.Services.Master;
using Evolent.Demo.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace Evolent.Demo.Web.Area.Masters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : BaseController
    {
        ILogger _logger = null;
        IContactMasterService contactMasterService = null;
        public ContactController(IContactMasterService _contactMasterService, ILogger logger)
        {
            _logger = logger;
            contactMasterService = _contactMasterService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContactMaster contactMaster)
        {
            if (contactMaster != null)
            {
                var result = contactMasterService.Add(contactMaster);
                return Ok(contactMaster);
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }


        [HttpPut("{contactId:int}")]
        public IActionResult Create(int contactId, [FromBody] ContactMaster contactMaster)
        {
            if (contactMaster != null)
            {
                var result = contactMasterService.Update(contactMaster);
                return Ok(contactMaster);
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }

        [HttpGet("{contactId:int}")]
        public IActionResult Get(int contactId)
        {
            if (contactId > 0)
            {
                var result = contactMasterService.Get(contactId);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Contact not found");
                }
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(contactMasterService.GetAll());
        }

        [HttpDelete("{contactId:int}")]
        public IActionResult Delete(int contactId)
        {
            if (contactId > 0)
            {
                var result = contactMasterService.Delete(contactId);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Contact not found");
                }
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }
    }
}
