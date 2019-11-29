using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entidades
{
    public class PacienteRemedio : EntidadeBase
    {
        [Key]
        [ForeignKey("Remedio")]
        public int IdRemedio { get; set; }
        [Key]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }
        [Required]
        public string Descricao { get; set; }

        public Remedio Remedio { get; set; }
        public Paciente Paciente { get; set; }
    }
}
