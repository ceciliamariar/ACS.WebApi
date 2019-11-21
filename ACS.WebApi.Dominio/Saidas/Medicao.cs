using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Saidas
{
    public class Medicao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdPaciente { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public bool Rotina { get; set; }

        [Required]
        public bool Pedido { get; set; }

        [Required]
        public int PAsist { get; set; }

        [Required]
        public int PAdist { get; set; }

        [Required]
        public int FC { get; set; }

        [StringLength(500)]
        public string Comentario { get; set; }
        
    }
}
