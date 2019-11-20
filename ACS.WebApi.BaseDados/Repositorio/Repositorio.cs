using ACS.WebApi.Dominio.Entidades;
using ACS.WebApi.Dominio.Repositorios.Interfaces;
using ACS.WebApi.BaseDados;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public IQueryable<TEntidade> Select()
        {
            return BdEntidade.AsNoTracking().AsQueryable();
        }
        public async Task<List<TEntidade>> SelectAsync()
        {
            return await BdEntidade.ToListAsync();
        }
        public IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> where)
        {
            return BdEntidade.AsNoTracking().Where(where);
        }
        
        public virtual IQueryable<TEntidade> Join(IQueryable<TEntidade> query, Expression<Func<TEntidade, object>> tabela)
        {
            return query.Include(tabela).AsQueryable();
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
    }

}
