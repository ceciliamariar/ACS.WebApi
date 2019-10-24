using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Saidas
{
    public class Endereco 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        public int Numero { get; set; }

        [StringLength(100)]
        public string Bairro { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(100)]
        [Required]
        public string CEP { get; set; }

        [StringLength(1000)]
        public string GeoLocalizacao { get; set; }


        public List<Paciente> Pacientes { get; set; }
    }
}
