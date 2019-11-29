using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entradas
{
    public class PacienteRemedioEntrada
    {
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }
        [Required]
        public string  DescricaoRemedio { get; set; }

    }
}
