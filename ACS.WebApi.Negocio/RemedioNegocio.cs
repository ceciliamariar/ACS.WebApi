using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class RemedioNegocio : Negocio<Remedio> , IRemedioNegocio
    {


        public RemedioNegocio(IRemedioRepositorio remedioRepositorio) : base(remedioRepositorio)
        {

        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RemedioSaida> Insert(RemedioEntrada obj)
        {
            throw new NotImplementedException();
        }
    }
}
