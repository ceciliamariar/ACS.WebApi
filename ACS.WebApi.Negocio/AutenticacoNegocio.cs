using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Excecoes;
using ACS.WebApi.Util;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class AutenticacoNegocio : IAutenticacaoNegocio
    {
        private readonly IUsuarioNegocio _usuarioNegocio;
        private readonly Configuracoes _configuraracao;


        public AutenticacoNegocio(IOptions<Configuracoes> configuraracao,
                                    IUsuarioNegocio usuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
            _configuraracao = configuraracao.Value;

        }
        public async Task<string> SolicitarToken(LoginEntrada login)
        {

            return await Task<string>.Run(async () =>
            {

                var usuarioValido = await _usuarioNegocio.VerificaUsuario(login);
                if (usuarioValido)
                {
                    var credencial = new[]
                    {
                            new Claim(ClaimTypes.Name, login.Login),
                            new Claim(ClaimTypes.Role, login.Perfil.ToString()),
                    };

                    var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuraracao.ChaveSecreta));


                    var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _configuraracao.Emissor,
                        audience: _configuraracao.ValidoEm,
                        claims: credencial,
                        expires: DateTime.UtcNow.AddMinutes(_configuraracao.ValidadeMinutos),
                        signingCredentials: signingCredentials);

                    return string.Concat("Bearer ", new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    throw new UsuarioouSenhaInvalidoExcecao();
                }
            });
        }
        
    }
}
