using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IEnderecoNegocio
    {

        Task<EnderecoSaida> Insert(EnderecoEntrada obj, string token);
        
        Task<bool> Update(EnderecoEntrada obj, string token);
        
    }
}
