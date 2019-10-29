using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UsuariosController : ControllerBase
    {
        public IUsuarioNegocio UsuarioNegocio { get; set; }

        public UsuariosController(IUsuarioNegocio _IUsuarioNegocio)
        {
            UsuarioNegocio = _IUsuarioNegocio;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioSaida>> Get()
        {
            try
            {
                return Ok( Task<IEnumerable<UsuarioSaida>>.Run(() => UsuarioNegocio.RetornaUsuarios()));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioEntrada value)
        {
            try
            {
                Task<IEnumerable<UsuarioSaida>>.Run(() => UsuarioNegocio.Insert(value));

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
