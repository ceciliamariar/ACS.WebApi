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
    
    public interface IRepositorio<TEntidade>  where TEntidade : EntidadeBase
    {
        int Commit();
        Task<int> CommitAsync();
        void Delete(int id);
        void Insert(TEntidade obj);
        Task<List<TEntidade>> SelectAsync();
        void Update(TEntidade obj);
      
        IQueryable<TEntidade> Query(Expression<Func<TEntidade, bool>> where = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> orderby = null,
                params Expression<Func<TEntidade, object>>[] joins);


        TEntidade SelectId(params object[] iDs);
    }

}
