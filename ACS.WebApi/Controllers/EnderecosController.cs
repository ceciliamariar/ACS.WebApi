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
    public class EnderecosController : ControllerBase
    {
        public IEnderecoNegocio EnderecoNegocio { get; set; }

        public EnderecosController(IEnderecoNegocio _IEnderecoNegocio)
        {
            EnderecoNegocio = _IEnderecoNegocio;
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoSaida>> Post([FromBody] EnderecoEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<EnderecoSaida>>.Run(() => EnderecoNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPut]
        public ActionResult Put([FromBody] EnderecoEntrada value)
        {
            try
            {
                Task.Run(() => EnderecoNegocio.Update(value));

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
    }
}
