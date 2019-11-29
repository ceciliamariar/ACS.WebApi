using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Excecoes;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACS.WebApi.Controllers
{

    /// <summary>
    /// Controlador responsável pela autenticação
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly IAutenticacaoNegocio _Autenticacao;
        
        public AutenticacaoController(IAutenticacaoNegocio autenticacao)
        {
            _Autenticacao = autenticacao;
        }

        /// <summary>
        /// Serviço responsável por gerar token de acesso com duração de 2 horas
        /// </summary>
        /// <param name="usuario">Usuário que deseja logar no sistemas</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SolicitarTokenAsync([FromBody] LoginEntrada usuario)
        {
            try
            {
                var token = await _Autenticacao.SolicitarToken(usuario);

                return Ok(token);

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
