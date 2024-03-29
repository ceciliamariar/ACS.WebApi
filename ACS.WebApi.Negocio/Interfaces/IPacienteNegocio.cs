﻿using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IPacienteNegocio
    {
        Task<IList<PacienteSaida>> RecuperaPacientesPorNome(string nome);

        Task<PacienteSaida> Insert(PacienteEntrada obj, string token);

        Task<bool> Update(PacienteEntrada obj);

        Task<PacienteDetalheSaida> RecuperaPaciente(int idPaciente);

        Task<PacienteRemedioSaida> CadastrarRemedio(PacienteRemedioEntrada pacienteRemedioEntrada, string token);

    }
}
