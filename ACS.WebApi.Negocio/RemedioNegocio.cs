using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;

namespace ACS.WebApi.Negocio
{
    public class RemedioNegocio : Negocio<Remedio> 
    {


        public RemedioNegocio(IRemedioRepositorio remedioRepositorio) : base(remedioRepositorio)
        {

        }
    }
}
