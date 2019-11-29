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
        public IUsuarioNegocio _UsuarioNegocio { get; set; }
        public IMedicaoNegocio _MedicaoNegocio { get; set; }

        public UsuariosController(IUsuarioNegocio usuarioNegocio, IMedicaoNegocio medicaoNegocio)
        {
            _UsuarioNegocio = usuarioNegocio;
            _MedicaoNegocio = medicaoNegocio;
        }
        
        [HttpGet]
        [Route("{login}")]
        public async Task<ActionResult<UsuarioSaida>> GetAsync(string login)
        {
            try
            {
                var retorno = await Task<UsuarioSaida>.Run(() => _UsuarioNegocio.RetornaUsuario(login));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioSaida>> Post([FromBody] UsuarioEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<UsuarioSaida>>.Run(() => _UsuarioNegocio.Insert(value, HttpContext.Request.Headers["Authorization"].ToString()));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsuarioEntrada value)
        {
            try
            {
                await _UsuarioNegocio.Update(value, HttpContext.Request.Headers["Authorization"].ToString());

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("/Medicoes/Pedentes")]
        public async Task<ActionResult<UsuarioSaida>> RecuperaPendentesValidacao()
        {
            try
            {
                var retorno = await Task<UsuarioSaida>.Run(() => _MedicaoNegocio.RecuperaPendentesValidacao(HttpContext.Request.Headers["Authorization"].ToString()));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("/Medicoes/{idMedicao}/Validada/{comentario}")]
        public async Task<ActionResult<UsuarioSaida>> ValidarMedicao(int idMedicao, string comentario)
        {
            try
            {
                var retorno = await Task<UsuarioSaida>.Run(() => _MedicaoNegocio.ValidarMedicao(idMedicao, comentario, HttpContext.Request.Headers["Authorization"].ToString()));

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

        //GET -> SELECT
        //DELETE -> DELETE
        //POST -> INSERT
        //PUT -> UPDATE
    }
}
