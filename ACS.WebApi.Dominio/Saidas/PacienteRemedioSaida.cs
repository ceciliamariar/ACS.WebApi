using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Saidas
{
    public class PacienteRemedioSaida
    {
        public int IdRemedio { get; set; }
        public int IdPaciente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataVisita { get; set; }
        public string DescricaoRemedio { get; set; }

    }
}
