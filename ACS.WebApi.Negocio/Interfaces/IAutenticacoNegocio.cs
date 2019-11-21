using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IAutenticacaoNegocio
    {
        Task<string> SolicitarToken(LoginEntrada login);
    }
}
