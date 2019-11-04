using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;

namespace ACS.WebApi.Negocio
{
    public class MedicaoNegocio : Negocio<Medicao>
    {
        public MedicaoNegocio(IMedicaoRepositorio medicaoRepositorio) : base(medicaoRepositorio)
        {

        }

    }
}
