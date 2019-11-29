using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class EnderecoNegocio : Negocio<Endereco>, IEnderecoNegocio
    {
        private  IUsuarioNegocio UsuarioNegocio { get; set; }

        public EnderecoNegocio(IEnderecoRepositorio enderecoRepositorio, IUsuarioNegocio usuarioNegocio) : base(enderecoRepositorio)
        {
            UsuarioNegocio = usuarioNegocio;
        }

        public async Task<EnderecoSaida> Insert(EnderecoEntrada obj, string token)
        {
            return await Task<EnderecoSaida>.Run(async () => {


                Login usuLogado = await UsuarioNegocio.RetornaUsuarioLogado(token);

                EnderecoSaida saida = null;
                var endereco = new Endereco();

                endereco.Numero = obj.Numero;
                endereco.Bairro = obj.Bairro;
                endereco.CEP = obj.CEP;
                endereco.Cidade = obj.Cidade;
                endereco.Descricao = obj.Descricao;
                endereco.GeoLocalizacao = obj.GeoLocalizacao;
                endereco.IdUsuarioUltimaAtualicao = usuLogado.iD;
                endereco.GeoLocalizacao = obj.GeoLocalizacao;

                _Repositorio.Insert(endereco);
                _Repositorio.Commit();

                return saida;
            });

        }
        
        public async Task<bool> Update(EnderecoEntrada obj, string token)
        {
           return await Task.Run(() =>
            {
                var endereco = _Repositorio.Query(where: a => a.Id == obj.Id).FirstOrDefault();

                if (endereco == null || endereco.DataCriacao < DateTime.Now.AddHours(-1))
                {
                    return false;
                }

                endereco.Numero = obj.Numero;
                endereco.Bairro = obj.Bairro;
                endereco.CEP = obj.CEP;
                endereco.Cidade = obj.Cidade;
                endereco.Descricao = obj.Descricao;
                endereco.GeoLocalizacao = obj.GeoLocalizacao;

                _Repositorio.Update(endereco);
                _Repositorio.Commit();
                return true;
            });
        }

    }
}
