using System;

namespace ACS.WebApi.Excecoes
{
    public class UsuarioouSenhaInvalidoExcecao : Exception
    {
        public UsuarioouSenhaInvalidoExcecao(string mensagem) : base(mensagem)
        {
        }
    }
}
