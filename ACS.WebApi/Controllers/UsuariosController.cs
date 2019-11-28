using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [Route("{login}")]
        public async Task<ActionResult<UsuarioSaida>> GetAsync(string login)
        {
            try
            {

                //   LoginEntrada usuLogado  = await Task.Run(() => UsuarioNegocio.RetornaUsuarioLogado(HttpContext.Request.Headers["Authorization"].ToString()));


                var retorno = await Task<UsuarioSaida>.Run(() => UsuarioNegocio.RetornaUsuario(login));

                return Ok(retorno);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<UsuarioSaida>> Post([FromBody] UsuarioEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<UsuarioSaida>>.Run(() => UsuarioNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // POST api/values
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsuarioEntrada value)
        {
            try
            {
                await UsuarioNegocio.Update(value);

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
