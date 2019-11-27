
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IRespostaNegocio
    {

        Task<RespostaSaida> Insert(RespostaEntrada obj);
        
        Task Delete(int id);
        
    }
}
