using System.ComponentModel.DataAnnotations;

namespace ACS.WebApi.Dominio.Entradas
{
    public class EnderecoEntrada
    {
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

    }
}
