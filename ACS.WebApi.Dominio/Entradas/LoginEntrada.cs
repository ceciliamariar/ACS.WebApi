using ACS.WebApi.Dominio.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entradas
{
    public class LoginEntrada
    {
        [Required]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }

        [Required]
        public PerfilUsuarioEnum Perfil { get; set; }
    }
}
