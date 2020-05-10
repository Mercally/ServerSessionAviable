using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Interfaces;

namespace SSAApp.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServersStatusController : ControllerBase
    {
        private readonly IServerStatusAppService app;

        public ServersStatusController(IServerStatusAppService app)
        {
            this.app = app;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ServerStatus>> List()
        {
            return Ok(app.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ServerStatus> GetItem(int id)
        {
            var model = app.GetById(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ServerStatus> Create([FromBody]ServerStatus model)
        {
            app.Add(model);
            return CreatedAtAction(nameof(GetItem), new { model.IdServer }, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] ServerStatus item)
        {
            try
            {
                app.Modify(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while editing item");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            var model = app.Delete(id);

            if (model == null)
                return NotFound();

            return Ok();
        }
    }
}