using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IEnderecoNegocio
    {

        Task<EnderecoSaida> Insert(EnderecoEntrada obj);
        
        Task Update(EnderecoEntrada obj);
        
    }
}
