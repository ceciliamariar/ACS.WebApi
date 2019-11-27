using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Saidas
{
    public class PerguntaSaida
    {
        public int Id { get; set; }

        [StringLength(500)]
        [Required]
        public string Descricao { get; set; }
        
    }
}
