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
        [ForeignKey("FKPacienteResposta")]
        public int IdPaciente { get; set; }

        [Key]
        [ForeignKey("FKPerguntaResposta")]
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
    }
}
