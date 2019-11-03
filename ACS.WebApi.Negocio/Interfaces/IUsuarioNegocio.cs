using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;

namespace ACS.WebApi.Negocio
{
    public interface IUsuarioNegocio : INegocio<Usuario> 
    {
        IEnumerable<UsuarioSaida> RetornaUsuarios();
        
        void Insert(UsuarioEntrada obj);

        bool VerificaUsuario(LoginEntrada loginEntrada);
    }
}
