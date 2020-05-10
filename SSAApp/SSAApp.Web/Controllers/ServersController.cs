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
    /// <summary>
    /// Controlador de operaciones con entidad de servidores.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IServerAppService app;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="app"></param>
        public ServersController(IServerAppService app)
        {
            this.app = app;
        }

        /// <summary>
        /// Listar todos los servidores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Server>> List()
        {
            return Ok(app.GetAll());
        }

        /// <summary>
        /// Obtener un servidor por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Server> GetItem(int id)
        {
            var model = app.GetById(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        /// <summary>
        /// Crear una nueva entidad de servidor.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Server> Create([FromBody]Server model)
        {
            app.Add(model);
            return CreatedAtAction(nameof(GetItem), new { model.IdServer }, model);
        }

        /// <summary>
        /// Editar una entidad de servidor existentes.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Server item)
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

        /// <summary>
        /// Elimina un servidor por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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