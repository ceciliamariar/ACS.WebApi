using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entradas
{
    public class PacienteRemedio
    {
        [Key]
        public int IdRemedio { get; set; }
        [Key]
        public int IdPaciente { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }

        public Remedio Remedio { get; set; }
        public Paciente Paciente { get; set; }
    }
}
