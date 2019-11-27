using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Entradas
{
    public class RespostaEntrada 
    {
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        public int IdPergunta { get; set; }
        [Required]
        public bool Resposta { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }

    }
}
