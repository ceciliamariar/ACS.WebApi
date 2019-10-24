using ACS.WebApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WebApi.Dominio.Repositorios.Interfaces
{
    
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : EntidadeBase
    {
        int Commit();
        Task<int> CommitAsync();
        void Delete(int id);
        void Insert(TEntidade obj);
        IQueryable<TEntidade> Join(IQueryable<TEntidade> query, Expression<Func<TEntidade, IProperty>> tabela);
        IQueryable<TEntidade> Select();
        Task<List<TEntidade>> SelectAsync();
        void Update(TEntidade obj);
        IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> where);
    }

}
