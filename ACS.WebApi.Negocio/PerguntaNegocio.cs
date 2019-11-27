using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class PerguntaNegocio : Negocio<Pergunta>, IPerguntaNegocio
    {
        public PerguntaNegocio(IPerguntaRepositorio perguntaRepositorio) : base(perguntaRepositorio) { }

        public async Task<PerguntaSaida> Insert(PerguntaEntrada obj)
        {
            return await Task<PerguntaSaida>.Run(() =>
            {
                PerguntaSaida saida = null;
                var pergunta = new Pergunta();

                pergunta.Descricao = obj.Descricao;

                _Repositorio.Insert(pergunta);
                _Repositorio.Commit();


                saida.Id = pergunta.Id;
                saida.Descricao = pergunta.Descricao;

                return saida;
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() =>
            {
                var endereco = _Repositorio.Query(where: a => a.Id == id, orderby: null, joins: a=> a.Respostas).FirstOrDefault();
                if (endereco != null && endereco.Respostas.Count == 0)
                {
                    _Repositorio.Delete(id);
                    _Repositorio.Commit();
                }
            });
        }
    }
}
