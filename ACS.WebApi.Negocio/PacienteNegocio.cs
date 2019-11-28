using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class PacienteNegocio : Negocio<Paciente>, IPacienteNegocio
    {
        private readonly IMapper _mapper;
        private IUsuarioNegocio UsuarioNegocio { get; set; }


        public PacienteNegocio(IPacienteRepositorio pacienteRepositorio,
             IUsuarioNegocio usuarioNegocio,
                               IMapper mapper) : base(pacienteRepositorio)
        {
            _mapper = mapper;
            UsuarioNegocio = usuarioNegocio;
        }

        public async Task<PacienteSaida> Insert(PacienteEntrada obj, string token)
        {
            return await Task<PacienteSaida>.Run(async () =>
            {

                Login usuLogado =  await UsuarioNegocio.RetornaUsuarioLogado(token);

                Paciente paciente = _mapper.Map<Paciente>(obj);
                paciente.IdUsuario = usuLogado.iD;
                paciente.IdUsuarioUltimaAtualicao = usuLogado.iD;

                _Repositorio.Insert(paciente);
                _Repositorio.Commit();

                return _mapper.Map<PacienteSaida>(paciente);
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

                var pacientes = _Repositorio.Query(a => a.Nome.ToUpper().Contains(nome.ToUpper()),
                     null,
                    b => b.UsuarioResponsavel).ToList();
                    
                
                if (pacientes != null)
                {
                    saida = new List<PacienteSaida>();

                    pacientes.ForEach(a => saida.Add(new PacienteSaida()
                    {
                        DataNascimento = a.DataNascimento,
                        IdEndereco = a.IdEndereco,
                        Id = a.Id,
                        Nome = a.Nome,
                        Sexo = a.Sexo,
                        Telefone = a.Telefone,
                        NomeResponsavel = a.UsuarioResponsavel.Nome,
                        idResponsavel =a.UsuarioResponsavel.Id
                    }));

                    saida = _mapper.Map<List<PacienteSaida>>(pacientes);
                }
                return saida;
            });

        }

        public async Task<PacienteDetalheSaida> RecuperaPaciente(int idPaciente)
        {
            return await Task<PacienteDetalheSaida>.Run(() => {

                PacienteDetalheSaida saida = null;

                var paciente = _Repositorio.Query(A => A.Id == idPaciente,
                 null,
                b => b.UsuarioResponsavel,
                c => c.Respostas,
                d => d.Endereco,
                e => e.PacienteRemedios).FirstOrDefault();


                if (paciente != null)
                {

                    saida = new PacienteDetalheSaida()
                    {
                        DataNascimento = paciente.DataNascimento,
                        Endereco = new EnderecoSaida()
                        {
                            Id = paciente.IdEndereco,
                            Bairro = paciente.Endereco.Bairro,
                            CEP = paciente.Endereco.CEP,
                            Cidade = paciente.Endereco.Cidade,
                            Descricao = paciente.Endereco.Cidade,
                            GeoLocalizacao = paciente.Endereco.GeoLocalizacao,
                            Numero = paciente.Endereco.Numero
                        },
                        Respostas = new List<RespostaSaida>(),
                        Id = paciente.Id,
                        Nome = paciente.Nome,
                        Sexo = paciente.Sexo,
                        Telefone = paciente.Telefone,
                        Responsavel = new UsuarioSaida()
                        {
                            Nome = paciente.UsuarioResponsavel.Nome,
                            Id = paciente.UsuarioResponsavel.Id,
                            Perfil = paciente.UsuarioResponsavel.Perfil,
                            TipoPessoa = paciente.UsuarioResponsavel.TipoPessoa,
                        }
                    };
                }
                return saida;
            });

        }

        public async Task Update(PacienteEntrada obj)
        {
            await Task.Run(() =>
            {
                var paciente = _Repositorio.Query(where: a => a.Id == obj.IdEndereco).FirstOrDefault();

                paciente.IdEndereco = obj.IdEndereco;
                paciente.Nome = obj.Nome;
                paciente.Sexo = obj.Sexo;
                paciente.DataNascimento = obj.DataNascimento;
                paciente.Telefone = obj.Telefone;

                _Repositorio.Update(paciente);
                _Repositorio.Commit();
            });
        }
    }
}
