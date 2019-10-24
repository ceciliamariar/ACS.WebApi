using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Saidas
{
    public class Remedio 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        public List<PacienteRemedio> PacientesRemedio { get; set; }
    }
}
