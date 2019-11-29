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
    public class MedicaoNegocio : Negocio<Medicao>, IMedicaoNegocio
    {

        private readonly IMapper _mapper;
        private readonly IPacienteRepositorio _PacienteRepositorio;
        private readonly IUsuarioNegocio _UsuarioNegocio;

        public MedicaoNegocio(IMedicaoRepositorio medicaoRepositorio,
            IPacienteRepositorio pacienteRepositorio,
            IUsuarioNegocio usuarioNegocio,
                               IMapper mapper) : base(medicaoRepositorio)
        {
            _PacienteRepositorio = pacienteRepositorio;
            _UsuarioNegocio = usuarioNegocio;
        }

        public async Task<MedicaoSaida> Insert(MedicaoEntrada obj, string token)
        {
            return await Task<MedicaoSaida>.Run(async () =>
            {

                Login usuLogado = await _UsuarioNegocio.RetornaUsuarioLogado(token);
                int responsavelPaciente = _PacienteRepositorio.SelectId(obj.IdPaciente).IdUsuario;

                var medicao = new Medicao();

                medicao = _mapper.Map<Medicao>(obj);
                medicao.Validado = responsavelPaciente == usuLogado.iD;

                _Repositorio.Insert(medicao);
                _Repositorio.Commit();

                return _mapper.Map<MedicaoSaida>(medicao);

            });

        }

        public async Task<IList<MedicaoSaida>> RecuperaPorPaciente(int idPaciente)
        {
            return await Task<IList<MedicaoSaida>>.Run(() =>
            {

                List<MedicaoSaida> saida = null;
                var medicoes = _Repositorio.Query(a => a.IdPaciente == idPaciente,
                                                       a => a.OrderBy(b=>b.DataCriacao), 
                                                       a => a.UsuarioResponsavelCadastro,
                                                          a => a.Paciente).ToList();

                if (medicoes != null)
                {
                    saida = new List<MedicaoSaida>();
                    saida = _mapper.Map<List<MedicaoSaida>>(medicoes);
                }
                return saida;
            });

        }

        public async Task<bool> Update(MedicaoEntrada obj)
        {
          return  await Task.Run(() =>
            {
                var medicao = _Repositorio.Query(where: a => a.Id == obj.Id && a.IdPaciente == obj.IdPaciente).FirstOrDefault();
                if (medicao == null || medicao.DataCriacao < DateTime.Now.AddHours(-1))
                {
                    return false;      
                }


                medicao.PAdist = obj.PAdist;
                medicao.PAsist = obj.PAsist;
                medicao.Rotina = obj.Rotina;
                medicao.Pedido = obj.Pedido;
                medicao.Comentario = obj.Comentario;
                medicao.FC = obj.FC;

                _Repositorio.Update(medicao);
                _Repositorio.Commit();
                return true;
            });
        }

        public async Task<IList<MedicaoSaida>> RecuperaPendentesValidacao(string token)
        {
            return await Task<IList<MedicaoSaida>>.Run(async () =>
            {
                Login usuLogado = await _UsuarioNegocio.RetornaUsuarioLogado(token);

                List<MedicaoSaida> saida = null;
            var medicoes = _Repositorio.Query(a => (!a.Validado) &&
                                                (a.IdResponsavelCadastro == usuLogado.iD
                                                || a.Paciente.IdUsuario == usuLogado.iD
                                                || a.Paciente.UsuarioResponsavel.IdUsuarioResponsavel == usuLogado.iD),
                                                a => a.OrderBy(b => b.DataCriacao),
                                                a => a.Paciente,
                                                a => a.Paciente.UsuarioResponsavel,
                                                a => a.UsuarioResponsavelCadastro).ToList();
                if (medicoes != null)
                {
                    saida = new List<MedicaoSaida>();
                    saida = _mapper.Map<List<MedicaoSaida>>(medicoes);
                }
                return saida;
            });

        }

        public async Task<bool> ValidarMedicao(int idMedicao, string comentario, string token)
        {
            return await Task.Run(async () =>
            {
                var medicao = _Repositorio.SelectId(idMedicao);
                if (medicao == null)
                {
                    return false;
                }
                Login usuLogado = await _UsuarioNegocio.RetornaUsuarioLogado(token);

                medicao.Validado = true;
                medicao.Comentario += medicao.Comentario + $"   Validado em {DateTime.Now.ToString("dd/MM/YYYY HH:mm")}.    " + comentario;
                medicao.IdUsuarioUltimaAtualicao = usuLogado.iD;



                _Repositorio.Update(medicao);
                _Repositorio.Commit();
                return true;
            });
        }
    }
}
