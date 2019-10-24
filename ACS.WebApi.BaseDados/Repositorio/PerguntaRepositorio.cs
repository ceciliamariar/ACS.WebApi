using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.BaseDados.Repositorios
{
    public class PerguntaRepositorio : Repositorio<Pergunta>, IPerguntaRepositorio
    {
        private readonly Contexto _context;

        public PerguntaRepositorio(Contexto context) : base(context)
        {
        }
    }
}
