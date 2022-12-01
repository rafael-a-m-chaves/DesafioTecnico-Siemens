using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Infrastructure.Context;
using DesafioTecnico.Infrastructure.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioTecnico.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
       where T : BaseEntity
    {

        protected APIContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(APIContext context)
        {
            if (context == null)
                return;

            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IList<T> Listar(
                    IEnumerable<Expression<Func<T, bool>>> filtros = null,
                    Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> ordenadoPor = null,
                    string propriedadesIncluidas = "")
        {
            IQueryable<T> query = dbSet;
            if (filtros != null)
            {
                foreach (var filtro in filtros)
                    query = query.Where(filtro);
            }
            foreach (var includeProperty in propriedadesIncluidas.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty.Trim());

            IList<T> resultado;


            if (ordenadoPor != null)
                resultado = ordenadoPor.Compile()(query).ToList();
            else
                resultado = query.ToList();

            return resultado;
        }

        public virtual IQueryable<T> Selecionar()
        {
            return dbSet;
        }

        public virtual IList<T> Listar(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> ordenadoPor = null,
            string propriedadesIncluidas = "")
        {
            IList<T> resultado = ListarEntity(filtro, ordenadoPor, propriedadesIncluidas);
            return resultado;
        }

        public IList<T> ListarEntity(Expression<Func<T, bool>> filtro, Func<IQueryable<T>, IOrderedQueryable<T>> ordenadoPor, string propriedadesIncluidas)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
                query = query.Where(filtro);

            foreach (var includeProperty in propriedadesIncluidas.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty.Trim());

            IList<T> resultado;

            if (ordenadoPor != null)
                resultado = ordenadoPor(query).ToList();
            else
                resultado = query?.ToList();

            return resultado;
        }

        public virtual T Obter(int id, string propriedadesIncluidas = "")
        {
            return ObterEntity(e => e.Id == id, propriedadesIncluidas: propriedadesIncluidas);
        }

        public virtual T Obter(Expression<Func<T, bool>> filtro, string propriedadesIncluidas = "")
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
                query = query.Where(filtro);

            if (!string.IsNullOrWhiteSpace(propriedadesIncluidas))
            {
                foreach (var includeProperty in propriedadesIncluidas.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty.Trim());
            }

            return query.FirstOrDefault();
        }

        private T ObterEntity(Expression<Func<T, bool>> filtro, string propriedadesIncluidas)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
                query = query.Where(filtro);

            if (!string.IsNullOrWhiteSpace(propriedadesIncluidas))
            {
                foreach (var includeProperty in propriedadesIncluidas.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty.Trim());
            }

            return query.FirstOrDefault();
        }

        public virtual void Salvar(T entidade)
        {
            if (entidade.Id == 0)
                Inserir(entidade);
            else
                Atualizar(entidade);
        }

        public virtual void Inserir(T entidade)
        {
            dbSet.Add(entidade);
        }

        public virtual void Atualizar(T entidade)
        {
            if (context.Entry(entidade).State == EntityState.Detached)
            {
                T dbEntidade = dbSet.Find(entidade.Id);
                context.Entry(dbEntidade).CurrentValues.SetValues(entidade);
            }
            else if (context.Entry(entidade).State == EntityState.Unchanged)
                context.Entry(entidade).State = EntityState.Modified;
        }

        public virtual void Excluir(T entidade)
        {
            this.Excluir(entidade.Id);
        }
        public virtual void Excluir(int id)
        {
            T entidade = dbSet.Find(id);
            this.ExcluirEntidade(entidade);
        }

        private void ExcluirEntidade(T dbEntidade)
        {
            if (context.Entry(dbEntidade).State == EntityState.Detached)
                dbSet.Attach(dbEntidade);
            dbSet.Remove(dbEntidade);
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}