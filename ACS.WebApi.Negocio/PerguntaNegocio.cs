using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using System;

namespace ACS.WebApi.Negocio
{
    public class PerguntaNegocio : Negocio<Pergunta>
    {

        public PerguntaNegocio(IPerguntaRepositorio perguntaRepositorio) : base(perguntaRepositorio)
        {

        }
    }
}
