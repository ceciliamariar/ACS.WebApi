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

        Task<MedicaoSaida> Insert(MedicaoEntrada obj, string token);

        Task<bool> Update(MedicaoEntrada obj);

        Task<IList<MedicaoSaida>> RecuperaPendentesValidacao(string token);

        Task<bool> ValidarMedicao(int idMedicao, string comentario, string token);

    }
}
