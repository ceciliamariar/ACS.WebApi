using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;

namespace ACS.WebApi.Negocio
{
    public class PacienteNegocio : Negocio<Paciente>
    {
        public PacienteNegocio(IPacienteRepositorio pacienteRepositorio) : base(pacienteRepositorio)
        {

        }

    }
}
