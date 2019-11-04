using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;

namespace ACS.WebApi.Negocio
{
    public class PacienteRemedioNegocio : Negocio<PacienteRemedio>
    {
        public PacienteRemedioNegocio(IPacienteRemedioRepositorio pacienteRemedioRepositorio) : base(pacienteRemedioRepositorio)
        {

        }

    }
}
