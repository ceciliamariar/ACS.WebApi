using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Excecoes;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly IAutenticacaoNegocio _autenticacao;

        public AutenticacaoController(IAutenticacaoNegocio autenticacao )
        {
            _autenticacao = autenticacao;
        }


        // POST: api/Autenticacao
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SolicitarToken([FromBody] LoginEntrada usuario)
        {
            try
            {
                var token = _autenticacao.SolicitarToken(usuario);

                return Ok(new { token });

            }
            catch(UsuarioouSenhaInvalidoExcecao)
            {
                return Unauthorized();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }


        }

        // PUT: api/Autenticacao/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
