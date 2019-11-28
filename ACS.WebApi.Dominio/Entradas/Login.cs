using ACS.WebApi.Dominio.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Entradas
{
    public class Login : LoginEntrada
    {
        public int iD { get; set; }
    }
}
