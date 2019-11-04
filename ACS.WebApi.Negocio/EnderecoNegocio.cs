using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;

namespace ACS.WebApi.Negocio
{
    public class EnderecoNegocio : Negocio<Endereco>
    {
        public EnderecoNegocio(IEnderecoRepositorio enderecoRepositorio) : base(enderecoRepositorio)
        {

        }

    }
}
