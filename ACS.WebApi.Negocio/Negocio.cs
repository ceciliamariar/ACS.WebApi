using ACS.WebApi.BaseDados.Repositorios;
using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WebApi.Negocio
{
    public class Negocio<TEntidade> : INegocio<TEntidade>  where TEntidade : EntidadeBase
    {
        public IRepositorio<TEntidade> _Repositorio { get; set; }

        public Negocio(IRepositorio<TEntidade> repositorio)
        {
            _Repositorio = repositorio;
        }

        public virtual void Insert(TEntidade obj)
        {
            _Repositorio.Insert(obj);
            _Repositorio.Commit();
        }
        public virtual void Update(TEntidade obj)
        {
            _Repositorio.Update(obj);
        }
        public IQueryable<TEntidade> Select()
        {
            return _Repositorio.Select();
        }
        public async Task<List<TEntidade>> SelectAsync()
        {
            return await _Repositorio.SelectAsync();
        }
        public IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> where)
        {
            return _Repositorio.Where(where);
        }

        public IQueryable<TEntidade> Join(IQueryable<TEntidade> query,  Expression<Func<TEntidade, IProperty>> tabela)
        {
            return _Repositorio.Join(query, tabela);
        }
        public virtual void Delete(int id)
        {
            _Repositorio.Delete(id);
        }
        public async Task<int> CommitAsync()
        {
            return await _Repositorio.CommitAsync();
        }
        public int Commit()
        {
            return _Repositorio.Commit();
        }
        public void Dispose()
        {
            _Repositorio.Dispose();
        }

    }
}