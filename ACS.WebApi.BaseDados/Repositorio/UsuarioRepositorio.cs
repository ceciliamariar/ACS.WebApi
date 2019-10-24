using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Enumeradores;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.BaseDados.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Contexto _context;

        public UsuarioRepositorio(Contexto context) : base(context)
        {
        }
    }
}
