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
    public interface INegocio<TEntidade>  where TEntidade : EntidadeBase
    {
       
        void Insert(TEntidade obj);

         void Update(TEntidade obj);
        IQueryable<TEntidade> Select();

        Task<List<TEntidade>> SelectAsync();
        IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> where);

        IQueryable<TEntidade> Join(IQueryable<TEntidade> query, Expression<Func<TEntidade, IProperty>> tabela);
        void Delete(int id);

        Task<int> CommitAsync();

        int Commit();

        void Dispose();

    }
}