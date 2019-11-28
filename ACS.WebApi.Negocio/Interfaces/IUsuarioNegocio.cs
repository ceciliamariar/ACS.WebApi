using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IUsuarioNegocio
    {
        Task<UsuarioSaida> RetornaUsuario(string login);

        Task<UsuarioSaida> Insert(UsuarioEntrada obj);

        Task<bool> VerificaUsuario(LoginEntrada loginEntrada);
        Task Update(UsuarioEntrada obj);

        Task<Login> RetornaUsuarioLogado(string tokenEntrada);
    }
}
