﻿using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.BaseDados.Repositorios
{
    public class RemedioRepositorio : Repositorio<Remedio>, IRemedioRepositorio
    {
        private readonly Contexto _context;

        public RemedioRepositorio(Contexto context) : base(context)
        {
        }
    }
}