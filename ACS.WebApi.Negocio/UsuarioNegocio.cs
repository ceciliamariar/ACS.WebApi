﻿using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.Dominio.Saidas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        #region PUBLIC
        public async Task<UsuarioSaida> RetornaUsuario(string login)
        {
            return await Task<List<UsuarioSaida>>.Run(
                () =>
                {
                    UsuarioSaida saida = null;
                    var usu = _Repositorio.Where(a => a.Login.ToUpper().Trim() == login.ToUpper().Trim()).FirstOrDefault(); ;

                    if (usu != null)
                        saida = new UsuarioSaida()
                        {
                            Email = usu.Email,
                            Id = usu.Id,
                            Login = usu.Login,
                            Nome = usu.Nome,
                            Perfil = usu.Perfil
                        };

                    return saida;
                });
        }
        public async Task<UsuarioSaida> Insert(UsuarioEntrada obj)
        {
            return await Task<UsuarioSaida>.Run(
           () =>
           {

               string login = string.Concat(obj.Nome[0], ".");
               if (!string.IsNullOrWhiteSpace(obj.Login))
               {
                   login = obj.Login;

                   var arrayNome = obj.Nome.Split(' ');
                   login += arrayNome[arrayNome.Length - 1];

                   if (VerificaExistenciaLogin(login))
                   {
                       login += (RecuperaMaxId() + 1).ToString();
                   }
               }

               Usuario usuario = new Usuario()
               {
                   Email = obj.Email,
                   Login = login,
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

                var usu = _Repositorio.Where(a => a.Login.ToUpper() == obj.Login.ToUpper()).FirstOrDefault();

                usu.Email = obj.Email;
                usu.Nome = obj.Nome;
                usu.Perfil = obj.Perfil;
                usu.Senha = _criptografiaNegocio.Criptografa(obj.Senha);

                _Repositorio.Update(usu);
                _Repositorio.Commit();
            });
        }


        public Task<bool> VerificaUsuario(LoginEntrada loginEntrada)
        {
            return Task<bool>.Run(() =>
            {
                var usu = _Repositorio.Where(u => u.Login == loginEntrada.Login
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
            var usu = _Repositorio.Where(a => a.Login.ToUpper() == login.ToUpper()).Count();

            return usu != 0;
        }

        private long RecuperaMaxId()
        {
            var max = _Repositorio.Select().Max(a => a.Id);

            return max;
        }



    }
}
