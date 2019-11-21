using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Excecoes;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACS.WebApi.Controllers
{

    /// <summary>
    /// Controlador responsável pela autenticação
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly IAutenticacaoNegocio _autenticacao;

        public AutenticacaoController(IAutenticacaoNegocio autenticacao)
        {
            _autenticacao = autenticacao;
        }

        /// <summary>
        ///  Soliciar token de acesso com duração de 1 hora
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        // POST: api/Autenticacao
        [AllowAnonymous]
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> SolicitarTokenAsync([FromBody] LoginEntrada usuario)
        {
            try
            {
                var token = await _autenticacao.SolicitarToken(usuario);

                return Ok(new { token });

            }
            catch (UsuarioouSenhaInvalidoExcecao)
            {
                return Unauthorized();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }


        }
    }
}
