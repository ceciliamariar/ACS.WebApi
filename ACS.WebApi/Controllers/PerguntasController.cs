using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        public IPerguntaNegocio PerguntaNegocio { get; set; }

        public PerguntasController(IPerguntaNegocio _IPerguntaNegocio)
        {
            PerguntaNegocio = _IPerguntaNegocio;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<PerguntaSaida>> Post([FromBody] PerguntaEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<PerguntaSaida>>.Run(() => PerguntaNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // POST api/values
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete( int id)
        {
            try
            {
                await PerguntaNegocio.Delete(id);

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        //GET -> SELECT
        //DELETE -> DELETE
        //POST -> INSERT
        //PUT -> UPDATE
    }
}
