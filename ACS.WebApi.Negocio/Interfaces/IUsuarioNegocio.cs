using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IUsuarioNegocio : INegocio<Usuario> 
    {
        Task<IEnumerable<UsuarioSaida>> RetornaUsuarios(string login);
        
        void Insert(UsuarioEntrada obj);

        bool VerificaUsuario(LoginEntrada loginEntrada);
        void Update(UsuarioEntrada obj);
    }
}
