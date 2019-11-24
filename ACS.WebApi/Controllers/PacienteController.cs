using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public IPacienteNegocio PacienteNegocio { get; set; }

        public PacienteController(IPacienteNegocio _IPacienteNegocio)
        {
            PacienteNegocio = _IPacienteNegocio;
        }
        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<PacienteSaida>> Post([FromBody] PacienteEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<PacienteSaida>>.Run(() => PacienteNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // POST api/values
        [HttpPut]
        public ActionResult Put([FromBody] PacienteEntrada value)
        {
            try
            {
                Task.Run(() => PacienteNegocio.Update(value));

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
    }
}
