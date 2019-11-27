
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IPerguntaNegocio
    {

        Task<PerguntaSaida> Insert(PerguntaEntrada obj);
        
        Task Delete(int id);
        
    }
}
