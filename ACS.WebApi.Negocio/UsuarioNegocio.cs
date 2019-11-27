using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Enumeradores;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class UsuarioNegocio : Negocio<Usuario>, IUsuarioNegocio
    {

        private readonly ICriptografiaNegocio _criptografiaNegocio;
        private readonly IMapper _mapper;
        public UsuarioNegocio(IUsuarioRepositorio repositorio,
                               ICriptografiaNegocio criptografiaNegocio,
                               IMapper mapper) : base(repositorio)
        {
            _criptografiaNegocio = criptografiaNegocio;
            _mapper = mapper;
        }

        #region PUBLIC
        public async Task<UsuarioSaida> RetornaUsuario(string login)
        {
            return await Task<List<UsuarioSaida>>.Run(
                () =>
                {
                    UsuarioSaida saida = null;
                    var usu = _Repositorio.Query(where: a => a.Login.ToUpper().Trim() == login.ToUpper().Trim()).FirstOrDefault();

                    if (usu != null)
                        saida = _mapper.Map<UsuarioSaida>(usu);
                   
                    return saida;
                });
        }
        public async Task<UsuarioSaida> Insert(UsuarioEntrada obj)
        {
            return await Task<UsuarioSaida>.Run( () =>
           {

               string login = string.Concat(obj.Nome[0], ".");

               var arrayNome = obj.Nome.Split(' ');
               login += arrayNome[arrayNome.Length - 1];
               bool existeLogin = this.VerificaExistenciaLogin(login);

               if (existeLogin)
               {
                   login += (this.RecuperaMaxId() + 1).ToString();
               }
               
               Usuario usuario = new Usuario()
               {
                   Email = obj.Email,
                   Login = login.ToLower(),
                   Nome = obj.Nome,
                   Perfil = obj.Perfil,
                   TipoPessoa = obj.TipoPessoa,
                   Senha = _criptografiaNegocio.Criptografa(obj.Senha)
               };

               _Repositorio.Insert(usuario);
               _Repositorio.Commit();

               return new UsuarioSaida()
               {
                   Email = usuario.Email,
                   Login = usuario.Login,
                   Nome = usuario.Nome,
                   Perfil = usuario.Perfil,
                   TipoPessoa = usuario.TipoPessoa,
                   Id = usuario.Id
               };


           });
        }

        public async Task Update(UsuarioEntrada obj)
        {
            await Task.Run(() =>
            {

                var usu = _Repositorio.Query(where: a => a.Login.ToUpper() == obj.Login.ToUpper()).FirstOrDefault();

                usu.Email = obj.Email;
                usu.Nome = obj.Nome;
                usu.Perfil = obj.Perfil;
                usu.Senha = _criptografiaNegocio.Criptografa(obj.Senha);

                _Repositorio.Update(usu);
                _Repositorio.Commit();
            });
        }


        public async Task<bool> VerificaUsuario(LoginEntrada loginEntrada)
        {
            return await Task<bool>.Run(() =>
            {
                var usu = _Repositorio.Query(where: u => u.Login == loginEntrada.Login
                                                 && loginEntrada.Perfil == u.Perfil
                                            ).FirstOrDefault();
                if (usu != null)
                {
                    return _criptografiaNegocio.ComparaValor(loginEntrada.Senha, usu.Senha);
                }
                else
                    return false;
            });
        }

        #endregion

        /// <summary>
        /// Retorna true se já existe login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool VerificaExistenciaLogin(string login)
        {
            var usu = _Repositorio.Query(where: a => a.Login.ToUpper() == login.ToUpper()).Count();

            return usu != 0;

        }

        private long RecuperaMaxId()
        {
            var max = _Repositorio.Query().Max(a => a.Id);

            return max;
        }


        public async Task<LoginEntrada> RetornaUsuarioLogado(string tokenEntrada)
        {
            return await Task<LoginEntrada>.Run(
           () =>
           {
               LoginEntrada login = new LoginEntrada();

               JwtSecurityToken token = new JwtSecurityToken(jwtEncodedString: tokenEntrada.Replace("Bearer ", string.Empty));
               if (token.Claims.First(c => c.Type == ClaimTypes.Name) != null)
               {
                   login.Login = token.Claims.First(c => c.Type == ClaimTypes.Name).Value;
               }
               if (token.Claims.First(c => c.Type == ClaimTypes.Role) != null)
               {
                   PerfilUsuarioEnum perfil;
                   Enum.TryParse<PerfilUsuarioEnum>(token.Claims.First(c => c.Type == ClaimTypes.Role).Value, out perfil);
                   login.Perfil = perfil;

               }
               return new LoginEntrada();

           });
        }

    }
}
