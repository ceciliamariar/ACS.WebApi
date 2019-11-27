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
        public EnderecoNegocio(IEnderecoRepositorio enderecoRepositorio) : base(enderecoRepositorio)
        {
        }

        public async Task<EnderecoSaida> Insert(EnderecoEntrada obj)
        {
            return await Task<EnderecoSaida>.Run(() => {

                EnderecoSaida saida = null;
                var endereco = new Endereco();

                endereco.Numero = obj.Numero;
                endereco.Bairro = obj.Bairro;
                endereco.CEP = obj.CEP;
                endereco.Cidade = obj.Cidade;
                endereco.Descricao = obj.Descricao;
                endereco.GeoLocalizacao = obj.GeoLocalizacao;

                _Repositorio.Insert(endereco);
                _Repositorio.Commit();

                return saida;
            });

        }
        
        public async Task Update(EnderecoEntrada obj)
        {
            await Task.Run(() =>
            {
                var endereco = _Repositorio.Query(where: a => a.Id == obj.Id).FirstOrDefault();

                endereco.Numero = obj.Numero;
                endereco.Bairro = obj.Bairro;
                endereco.CEP = obj.CEP;
                endereco.Cidade = obj.Cidade;
                endereco.Descricao = obj.Descricao;
                endereco.GeoLocalizacao = obj.GeoLocalizacao;

                _Repositorio.Update(endereco);
                _Repositorio.Commit();
            });
        }

    }
}
