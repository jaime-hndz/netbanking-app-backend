using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Entity;
using Business;

namespace Presentacion.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuarioBusiness usuariobusiness = new UsuarioBusiness();
        // GET: api/USUARIOs
        public IQueryable<USUARIO> GetUSUARIOs()
        {
            return usuariobusiness.GetUSUARIOs();
        }

        // GET: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult GetUSUARIO(int id)
        {
            USUARIO usuario = usuariobusiness.GetUSUARIO(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/USUARIOs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSUARIO(int id, USUARIO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.ID_USUARIO)
            {
                return BadRequest();
            }

            try
            {
                usuariobusiness.PutUSUARIO(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/USUARIOs
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult PostUSUARIO(USUARIO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuariobusiness.PostUSUARIO(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.ID_USUARIO }, usuario);
        }

        // DELETE: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteUSUARIO(int id)
        {
            USUARIO usuario = usuariobusiness.GetUSUARIO(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuariobusiness.DeleteUSUARIO(id);
            return Ok(usuario);
        }

        [Route("api/Usuarios/login/{user}/{pass}")]
        [HttpGet]
        public IHttpActionResult LOG_IN(String user, String pass)
        {
            IQueryable<USUARIO> usuario = usuariobusiness.Log_in(user, pass);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        private bool USUARIOExists(int id)
        {
            return usuariobusiness.USUARIOexists(id);
        }
    }
}