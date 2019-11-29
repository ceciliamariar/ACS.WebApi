using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entradas
{
    public class PacienteEntrada 
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [StringLength(14)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(1)]
        public char Sexo { get; set; }

        [Required]
        public int IdEndereco { get; set; }

        public int Id { get; set; }


    }
}
