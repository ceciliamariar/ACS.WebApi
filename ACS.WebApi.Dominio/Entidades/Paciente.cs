using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entidades
{
    public class Paciente : EntidadeBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }

        [Required]
        [ForeignKey("UsuarioResponsavel")]
        public int IdUsuario { get; set; }

        [Required]
        public Endereco Endereco { get; set; }
        [Required]
        public Usuario UsuarioResponsavel { get; set; }


        public List<PacienteRemedio> PacienteRemedios { get; set; }
        public List<Resposta> Respostas { get; set; }



    }
}
