using ACS.WebApi.Dominio.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entradas
{
    public class UsuarioEntrada
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        public string Senha { get; set; }
        [Required]
        public PerfilUsuarioEnum Perfil { get; set; }

    }
}
