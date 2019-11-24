using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACS.WebApi.BaseDados.Repositorios
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        protected Contexto BdContexto;
        protected DbSet<TEntidade> BdEntidade;
        protected Repositorio(Contexto context)
        {
            BdContexto = context;
            BdEntidade = BdContexto.Set<TEntidade>();
        }
        public void Insert(TEntidade obj)
        {
            obj.DataCriacao = DateTime.Now;
            obj.DataUltimaAtulizacao = DateTime.Now;
            BdEntidade.Add(obj);
        }
        public void Update(TEntidade obj)
        {
            obj.DataUltimaAtulizacao = DateTime.Now;

            BdEntidade.Update(obj);
        }
      
        public async Task<List<TEntidade>> SelectAsync()
        {
            return await BdEntidade.ToListAsync();
        }
        
        public void Delete(int id)
        {
            BdEntidade.Remove(BdEntidade.Find(id));
        }
        public async Task<int> CommitAsync()
        {
            return await BdContexto.SaveChangesAsync();
        }
        public int Commit()
        {
            return BdContexto.SaveChanges();
        }
        public void Dispose()
        {
            BdContexto.Dispose();
        }



        public IQueryable<TEntidade> Query(Expression<Func<TEntidade, bool>> where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderby = null,
                params Expression<Func<TEntidade, object>>[] joins)
        {

            IQueryable<TEntidade> queryable = BdContexto.Set<TEntidade>();

            if (where != null)
                queryable = queryable.Where(where);

            foreach (var item in joins)
                queryable = queryable.Include(item);

            if (orderby != null)
                queryable = orderby(queryable);

            return queryable;
        }

    }

}
