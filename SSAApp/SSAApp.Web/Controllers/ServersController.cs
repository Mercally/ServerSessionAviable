using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Services.Interfaces;

namespace SSAApp.Web.Controllers
{
    /// <summary>
    /// Controlador de operaciones con entidad de servidores.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IServerAppService api;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="api"></param>
        public ServersController(IServerAppService api)
        {
            this.api = api;
        }

        /// <summary>
        /// Listar todos los servidores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ServerModel>> List()
        {
            return Ok(api.GetAll());
        }

        /// <summary>
        /// Obtener un servidor por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ServerModel> GetItem(int id)
        {
            var model = api.GetById(id);

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
        public ActionResult<ServerModel> Create([FromBody]ServerModel model)
        {
            api.Add(model);
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
        public ActionResult Edit([FromBody] ServerModel item)
        {
            try
            {
                api.Modify(item);
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
            var model = api.Delete(id);

            if (model == null)
                return NotFound();

            return Ok();
        }
    }
}