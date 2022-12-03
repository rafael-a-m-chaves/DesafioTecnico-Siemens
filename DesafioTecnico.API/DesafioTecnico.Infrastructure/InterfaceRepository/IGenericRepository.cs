using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioTecnico.Infrastructure.InterfaceRepository
{
    public interface IGenericRepository<T> : IDisposable
       where T : class
    {
        IList<T> Listar(
                    Expression<Func<T, bool>> filtro = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> ordenadoPor = null,
                    string propriedadesIncluidas = "");

        IList<T> Listar(
            IEnumerable<Expression<Func<T, bool>>> filtros = null,
            Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> ordenadoPor = null,
            string propriedadesIncluidas = "");

        IQueryable<T> Selecionar();

        T Obter(int id, string propriedadesIncluidas = "");

        T Obter(Expression<Func<T, bool>> filtro, string propriedadesIncluidas = "");

        void Inserir(T entidade);

        void Excluir(int id);

        void Excluir(T entidade);

        void Atualizar(T entidade);

        void Salvar(T entidade);

        int Commit();

        Task<int> CommitAsync();

    }
}
