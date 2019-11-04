using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;

namespace ACS.WebApi.Negocio
{
    public class RespostaNegocio : Negocio<Resposta>
    {

        public RespostaNegocio(IRespostaRepositorio respostaRepositorio) : base(respostaRepositorio)
        {

        }
    }
}
