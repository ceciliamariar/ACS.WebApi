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
    //[Authorize()]
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

                LoginEntrada usuLogado  = await Task.Run(() => UsuarioNegocio.RetornaUsuarioLogado(HttpContext.Request.Headers["Authorization"].ToString()));


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
        public void Put(int id, [FromBody] UsuarioEntrada value)
        {
            Task<IEnumerable<UsuarioSaida>>.Run(() => UsuarioNegocio.Update(value));

            //return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
