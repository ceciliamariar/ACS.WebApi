using System;

namespace ACS.WebApi.Excecoes
{
    public class UsuarioouSenhaInvalidoExcecao : Exception
    {
        public UsuarioouSenhaInvalidoExcecao() : base("Usuario ou senha inválidos")
        {
        }
    }
}
