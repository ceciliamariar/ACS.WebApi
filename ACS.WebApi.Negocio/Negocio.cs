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
        public IRepositorio<TEntidade> Repositorio { get; set; }

        public virtual void Insert(TEntidade obj)
        {
            Repositorio.Insert(obj);
            Repositorio.Commit();
        }
        public virtual void Update(TEntidade obj)
        {
            Repositorio.Update(obj);
        }
        public IQueryable<TEntidade> Select()
        {
            return Repositorio.Select();
        }
        public async Task<List<TEntidade>> SelectAsync()
        {
            return await Repositorio.SelectAsync();
        }
        public IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> where)
        {
            return Repositorio.Where(where);
        }

        public IQueryable<TEntidade> Join(IQueryable<TEntidade> query,  Expression<Func<TEntidade, IProperty>> tabela)
        {
            return Repositorio.Join(query, tabela);
        }
        public virtual void Delete(int id)
        {
            Repositorio.Delete(id);
        }
        public async Task<int> CommitAsync()
        {
            return await Repositorio.CommitAsync();
        }
        public int Commit()
        {
            return Repositorio.Commit();
        }
        public void Dispose()
        {
            Repositorio.Dispose();
        }

    }
}