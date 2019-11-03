using ACS.WebApi.Dominio.Entradas;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ACS.WebApi.Excecoes;

namespace ACS.WebApi.Negocio
{
    public class AutenticacoNegocio  : IAutenticacaoNegocio
    {
        private readonly IUsuarioNegocio _usuarioNegocio;


        private readonly IConfiguration _configuraracao;
        
        public AutenticacoNegocio(IConfiguration configuraracao,
                                    IUsuarioNegocio usuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
            _configuraracao = configuraracao;

        }
        public string SolicitarToken(LoginEntrada login)
        {
            if (_usuarioNegocio.VerificaUsuario(login))
            {
                var credencial = new[]
                {
                    new Claim(ClaimTypes.Name, login.Login),
                    new Claim(ClaimTypes.Role, login.Perfil.ToString()),
                };

                var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuraracao["ChaveSecreta"]));


                var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     claims: credencial,
                     expires: DateTime.Now.AddHours(1),
                     signingCredentials: signingCredentials);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }else
            {
                throw new UsuarioouSenhaInvalidoExcecao("Usuario ou senha inválidos");
            }
        }


        
    }
}
