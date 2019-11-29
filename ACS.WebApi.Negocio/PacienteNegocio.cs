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
        private IUsuarioNegocio _UsuarioNegocio { get; set; }
        private IRemedioRepositorio _RemedioRepositorio { get; set; }
        private IPacienteRemedioRepositorio _PacienteRemedioRepositorio { get; set; }


        public PacienteNegocio(IPacienteRepositorio pacienteRepositorio,
                                IRemedioRepositorio remedioRepositorio,
                                IPacienteRemedioRepositorio pacienteRemedioRepositorio,
             IUsuarioNegocio usuarioNegocio,
                               IMapper mapper) : base(pacienteRepositorio)
        {
            _mapper = mapper;
            _UsuarioNegocio = usuarioNegocio;
            _RemedioRepositorio = remedioRepositorio;
            _PacienteRemedioRepositorio = pacienteRemedioRepositorio;
        }

        public async Task<PacienteSaida> Insert(PacienteEntrada obj, string token)
        {
            return await Task<PacienteSaida>.Run(async () =>
            {

                Login usuLogado = await _UsuarioNegocio.RetornaUsuarioLogado(token);

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
            return await Task<IList<PacienteSaida>>.Run(() =>
            {

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
                        idResponsavel = a.UsuarioResponsavel.Id
                    }));

                    saida = _mapper.Map<List<PacienteSaida>>(pacientes);
                }
                return saida;
            });

        }

        public async Task<PacienteDetalheSaida> RecuperaPaciente(int idPaciente)
        {
            return await Task<PacienteDetalheSaida>.Run(() =>
            {

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

        public async Task<bool> Update(PacienteEntrada obj)
        {
            return await Task.Run(() =>
            {
                var paciente = _Repositorio.SelectId(obj.Id);
                if (paciente == null || paciente.DataCriacao < DateTime.Now.AddHours(-1))
                {
                    return false;
                }
                paciente.IdEndereco = obj.IdEndereco;
                paciente.Nome = obj.Nome;
                paciente.Sexo = obj.Sexo;
                paciente.DataNascimento = obj.DataNascimento;
                paciente.Telefone = obj.Telefone;

                _Repositorio.Update(paciente);
                _Repositorio.Commit();

                return true;
            });
        }

        public async Task<PacienteRemedioSaida> CadastrarRemedio(PacienteRemedioEntrada pacienteRemedioEntrada, string token)
        {

            return await Task.Run(async () =>
            {
                var paciente = _Repositorio.SelectId(pacienteRemedioEntrada.IdPaciente);
                if (paciente == null )
                {
                    return null;
                }
                Login usuLogado = await _UsuarioNegocio.RetornaUsuarioLogado(token);
                
                Remedio remedio = new Remedio();
                remedio.Descricao = pacienteRemedioEntrada.DescricaoRemedio;
                remedio.IdUsuarioUltimaAtualicao = usuLogado.iD;

                _RemedioRepositorio.Insert(remedio);

                Dominio.Entidades.PacienteRemedio pacienteRemedio = new Dominio.Entidades.PacienteRemedio();

                pacienteRemedio.DataInicio = pacienteRemedioEntrada.DataInicio;
                pacienteRemedio.DataVisita = pacienteRemedioEntrada.DataVisita;
                pacienteRemedio.IdRemedio = remedio.Id;
                pacienteRemedio.IdPaciente = pacienteRemedioEntrada.IdPaciente;

                _PacienteRemedioRepositorio.Insert(pacienteRemedio);
                _Repositorio.Commit();

                return new PacienteRemedioSaida()
                {
                    DataInicio = pacienteRemedio.DataInicio,
                    DataVisita = pacienteRemedio.DataVisita,
                    IdRemedio = pacienteRemedio.IdRemedio,
                    IdPaciente = pacienteRemedio.IdPaciente,
                };

            });
        }
    }
}
