using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.BaseDados.Repositorios
{
    public class PacienteRemedioRepositorio : Repositorio<PacienteRemedio>, IPacienteRemedioRepositorio 
    {
        private readonly Contexto _context;

        public PacienteRemedioRepositorio(Contexto context) : base(context)
        {
        }
    }
}
