using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSAApp.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public ActionResult Get()
        {
            var response = new { Status = "Aviable" };
            return Ok(response);
        }
    }
}