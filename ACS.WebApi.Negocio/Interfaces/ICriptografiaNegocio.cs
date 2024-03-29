﻿using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;

namespace ACS.WebApi.Negocio
{
    public interface ICriptografiaNegocio
    {

        string Criptografa(string valor);
        bool ComparaValor(string valorDescriptografado, string valorCriptografado);

    }
}
