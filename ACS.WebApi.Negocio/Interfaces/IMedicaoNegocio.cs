using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public interface IMedicaoNegocio
    {
        Task<IList<MedicaoSaida>> RecuperaPorPaciente(int idPaciente);

        Task<MedicaoSaida> Insert(MedicaoEntrada obj);

        Task Update(MedicaoEntrada obj);
    }
}
