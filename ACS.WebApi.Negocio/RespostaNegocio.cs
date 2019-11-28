using System.Threading.Tasks;
using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;

namespace ACS.WebApi.Negocio
{
    public class RespostaNegocio : Negocio<Resposta>, IRespostaNegocio
    {

        public RespostaNegocio(IRespostaRepositorio respostaRepositorio) : base(respostaRepositorio)
        {

        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RespostaSaida> Insert(RespostaEntrada obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
