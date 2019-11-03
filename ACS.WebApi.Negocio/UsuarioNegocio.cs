using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System.Collections.Generic;
using System.Linq;
namespace ACS.WebApi.Negocio
{
    public class UsuarioNegocio : Negocio<Usuario>, IUsuarioNegocio
    {

        private readonly ICriptografiaNegocio _criptografiaNegocio;
        public UsuarioNegocio(IUsuarioRepositorio repositorio,
                               ICriptografiaNegocio criptografiaNegocio) : base(repositorio)
        {
            _criptografiaNegocio = criptografiaNegocio;
        }

        public IEnumerable<UsuarioSaida> RetornaUsuarios()
        {
            var usu = Select().ToList();

            List<UsuarioSaida> saida = new List<UsuarioSaida>();


            usu.ForEach(a => saida.Add(new UsuarioSaida()
            {
                Email = a.Email,
                Id = a.Id,
                Login = a.Login,
                Nome = a.Nome,
                Perfil = a.Perfil
            }));
            return saida;
        }

        public void Insert(UsuarioEntrada obj)
        {
            Usuario usuario = new Usuario()
            {
                Email = obj.Email,
                Login = obj.Login,
                Nome = obj.Nome,
                Perfil = obj.Perfil,
                Senha = _criptografiaNegocio.Criptografa(obj.Senha)

            };

            base.Insert(usuario);
        }

        public bool VerificaUsuario(LoginEntrada loginEntrada)
        {
            var usu = _Repositorio.Where(u => u.Login == loginEntrada.Login 
                                            && loginEntrada.Perfil == u.Perfil
                                        ).FirstOrDefault(null);
            if (usu != null )
            {
                return _criptografiaNegocio.ComparaValor(loginEntrada.Senha, usu.Senha);
            }
            else
                return false;
        }


    }
}
