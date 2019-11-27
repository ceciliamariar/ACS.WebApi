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
    public class MedicaoNegocio : Negocio<Medicao> , IMedicaoNegocio
    {
        public MedicaoNegocio(IMedicaoRepositorio medicaoRepositorio) : base(medicaoRepositorio)
        {
        }

        public async Task<MedicaoSaida> Insert(MedicaoEntrada obj)
        {
            return await Task<MedicaoSaida>.Run(() => {

                MedicaoSaida saida = null;
                var medicao = new Medicao();

                medicao.PAdist = obj.PAdist;
                medicao.PAsist = obj.PAsist;
                medicao.Rotina = obj.Rotina;
                medicao.Pedido = obj.Pedido;
                medicao.Comentario = obj.Comentario;
                medicao.FC = obj.FC;

                _Repositorio.Insert(medicao);
                _Repositorio.Commit();

                saida.Id = medicao.Id;
                saida.PAdist = medicao.PAdist;
                saida.PAsist = medicao.PAsist;
                saida.Rotina = medicao.Rotina;
                saida.Pedido = medicao.Pedido;
                saida.Comentario = medicao.Comentario;
                saida.FC = obj.FC;

                return saida;
            });

        }

        public async Task<IList<MedicaoSaida>> RecuperaPorPaciente(int idPaciente)
        {
            return await Task<IList<MedicaoSaida>>.Run(() => {

                List<MedicaoSaida> saida = null; 
                var medicoes = _Repositorio.Query(a => a.IdPaciente == idPaciente ).ToList();
                
                if (medicoes != null)
                {
                    saida = new List<MedicaoSaida>();

                    medicoes.ForEach(a => saida.Add(new MedicaoSaida()
                    {
                        IdPaciente = a.IdPaciente,
                        Comentario = a.Comentario,
                        DataHora = a.DataHora,
                        PAdist = a.PAdist,
                        PAsist = a.PAsist,
                        Pedido = a.Pedido,
                        Rotina = a.Rotina,
                        FC = a.FC
                    }));
                }
                return saida;
            });

        }
        
        public async Task Update(MedicaoEntrada obj)
        {
            await Task.Run(() =>
            {
                var paciente = _Repositorio.Query(where: a => a.Id == obj.Id && a.IdPaciente == obj.IdPaciente ).FirstOrDefault();

                paciente.PAdist = obj.PAdist;
                paciente.PAsist = obj.PAsist;
                paciente.Rotina = obj.Rotina;
                paciente.Pedido = obj.Pedido;
                paciente.Comentario = obj.Comentario;
                paciente.FC = obj.FC;
             
                _Repositorio.Update(paciente);
                _Repositorio.Commit();
            });
        }

    }
}
