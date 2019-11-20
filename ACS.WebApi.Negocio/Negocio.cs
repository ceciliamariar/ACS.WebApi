using ACS.WebApi.BaseDados.Repositorios;
using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class Negocio<TEntidade>  where TEntidade : EntidadeBase
    {
        public IRepositorio<TEntidade> _Repositorio { get; set; }

        public Negocio(IRepositorio<TEntidade> repositorio)
        {
            _Repositorio = repositorio;
        }
        
    }
}