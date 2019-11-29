using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Entidades
{
    public class Resposta : EntidadeBase
    {

        [Key]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }

        [Key]
        [ForeignKey("Pergunta")]
        public int IdPergunta { get; set; }

        [Required]
        public bool Respost { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }

        [Required]
        public bool Validado { get; set; } 

        public Pergunta Pergunta { get; set; }
        public Paciente Paciente { get; set; }

        [Required]
        [ForeignKey("UsuarioResponsavelCadastro")]
        public int IdResponsavelCadastro { get; set; }

        [Required]
        public Usuario UsuarioResponsavelCadastro { get; set; }

    }
}
