using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnderecosController : ControllerBase
    {
        public IEnderecoNegocio _EnderecoNegocio { get; set; }

        public EnderecosController(IEnderecoNegocio enderecoNegocio)
        {
            _EnderecoNegocio = enderecoNegocio;
        }
        /// <summary>
        /// Serviço responsável por cadastrar um endereço 
        /// </summary>
        /// <param name="endereco">Entidade de Endereço</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EnderecoSaida>> Post([FromBody] EnderecoEntrada endereco)
        {
            try
            {
                var retorno = await Task<IEnumerable<EnderecoSaida>>.Run(() => _EnderecoNegocio.Insert(endereco, HttpContext.Request.Headers["Authorization"].ToString()));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Serviço responsável por atulizar um endereço
        /// </summary>
        /// <param name="endereco">Entidade de Endereço</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EnderecoEntrada endereco)
        {
            try
            {
                var retorno = await Task.Run(() => _EnderecoNegocio.Update(endereco, HttpContext.Request.Headers["Authorization"].ToString()));

                if (!retorno)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
