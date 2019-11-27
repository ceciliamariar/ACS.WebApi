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
    public class RespostasController : ControllerBase
    {
        public IRespostaNegocio RespostaNegocio { get; set; }

        public RespostasController(IRespostaNegocio _IRespostaNegocio)
        {
            RespostaNegocio = _IRespostaNegocio;
        }
        
        [HttpPost]
        public async Task<ActionResult<RespostaSaida>> Post([FromBody] RespostaEntrada value)
        {
            try
            {
                var retorno = await Task<RespostaSaida>.Run(() => RespostaNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


         }
}
