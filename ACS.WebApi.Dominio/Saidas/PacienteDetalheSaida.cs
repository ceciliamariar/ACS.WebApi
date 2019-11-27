using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.WebApi.Dominio.Saidas
{
    public class PacienteDetalheSaida
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }
        
        public string Telefone { get; set; }

        public char Sexo { get; set; }
        
        public EnderecoSaida Endereco { get; set; }
        
        public UsuarioSaida Responsavel { get; set; }

        public List<MedicaoSaida> Medicoes { get; set; }

        public List<RespostaSaida> Respostas { get; set; }

    }

}
