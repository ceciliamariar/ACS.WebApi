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
    public class MedicoesController : ControllerBase
    {
        public IMedicaoNegocio MedicaoNegocio { get; set; }

        public MedicoesController(IMedicaoNegocio _IMedicaoNegocio)
        {
            MedicaoNegocio = _IMedicaoNegocio;
        }
        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<MedicaoSaida>> Post([FromBody] MedicaoEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<MedicaoSaida>>.Run(() => MedicaoNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // POST api/values
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MedicaoEntrada value)
        {
            try
            {
                await MedicaoNegocio.Update(value);

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
