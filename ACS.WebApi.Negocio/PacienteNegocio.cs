using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class PacienteNegocio : Negocio<Paciente>, IPacienteNegocio
    {
        public PacienteNegocio(IPacienteRepositorio pacienteRepositorio) : base(pacienteRepositorio)
        {

        }

        public async Task<PacienteSaida> Insert(PacienteEntrada obj)
        {
            return await Task<PacienteSaida>.Run(() =>
            {

                Paciente usuario = new Paciente()
                {
                    Nome = obj.Nome,
                    Sexo = obj.Sexo,
                    IdEndereco = obj.IdEndereco,
                    Telefone = obj.Telefone,
                    IdUsuario = (int)1, // recupera da requisição
                    IdUsuarioUltimaAtualicao = (int)1, // recuperar da requisição
                    DataNascimento = obj.DataNascimento
                };

                _Repositorio.Insert(usuario);
                _Repositorio.Commit();

                return new PacienteSaida()
                {
                    Nome = usuario.Nome,
                    Sexo = usuario.Sexo,
                    IdEndereco = usuario.IdEndereco,
                    Telefone = usuario.Telefone,
                    DataNascimento = usuario.DataNascimento
                };
            });


        }

        public async Task<IList<PacienteSaida>> RecuperaPacientesPorNome(string nome)
        {
            return await Task<IList<PacienteSaida>>.Run(() => {

                List<PacienteSaida> saida = null;
                if (nome.Count() < 3)
                {
                    throw new Exception("informe mais letras");
                }

                var pacientes = _Repositorio.Join(_Repositorio.Join(_Repositorio.Where(a => a.Nome.ToUpper().Contains(nome.ToUpper())), a=>a.Endereco), a=>a.UsuarioResponsavel).ToList();
                
                if (pacientes != null)
                {
                    saida = new List<PacienteSaida>();

                    pacientes.ForEach(a => saida.Add(new PacienteSaida()
                    {
                        DataNascimento = a.DataNascimento,
                        DescricaoEndereco = string.Concat(a.Endereco.Descricao, ", Nº", a.Endereco.Numero, " - ", a.Endereco.Bairro, " - ", a.Endereco.Cidade, " - CEP" , a.Endereco.CEP ),
                        IdEndereco = a.IdEndereco,
                        Id = a.Id,
                        Nome = a.Nome,
                        Sexo = a.Sexo,
                        Telefone = a.Telefone,
                        Responsavel = a.UsuarioResponsavel.Nome

                    }));
                }
                return saida;
            });

        }
        
    }
}
