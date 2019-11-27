using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Saidas
{
    public class RespostaSaida
    {
        public int IdPaciente { get; set; }

        public PerguntaSaida Pergunta { get; set; }

        [Required]
        public bool Resposta { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }

    }
}
