using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.WebApi.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        [Required]
        public DateTime DataCriacao { get; set; }
        [Required]
        public DateTime DataUltimaAtulizacao { get; set; }
        [Required]
        [ForeignKey("UsuarioUltimaAtualizacao")]
        public int IdUsuarioUltimaAtualicao { get; set; }
        public Usuario UsuarioUltimaAtualizacao { get; set; }

    }
}
