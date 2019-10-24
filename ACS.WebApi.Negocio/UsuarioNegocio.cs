using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.WebApi.Negocio
{
    public class UsuarioNegocio :  Negocio<Usuario>, IUsuarioNegocio
    {

        public UsuarioNegocio(IUsuarioRepositorio _Repositorio)
        {
            Repositorio = _Repositorio;
        }

        public IEnumerable<UsuarioSaida> RetornaUsuarios()
        {
            var usu = this.Select().ToList();

            List<UsuarioSaida> saida = new List<UsuarioSaida>();


             usu.ForEach(a=> saida.Add( new UsuarioSaida()
                                                    {
                                                    Email = a.Email,
                                                    Id = a.Id,
                                                    Login = a.Login,
                                                    Nome = a.Nome,
                                                    Perfil = a.Perfil
                                                        }));
            return saida;
        }
    }
}
