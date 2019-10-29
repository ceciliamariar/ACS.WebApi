using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Entradas
{
    public class Pergunta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        [Required]
        public string Descricao { get; set; }
        
    }
}
