using ChMaster.Blockchain.Domain.Entities;
using System.Linq.Expressions;

namespace MED.Data.Repositories.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task AtualizarLista(IEnumerable<TEntity> entities);
        Task AdicionarLista(IEnumerable<TEntity> entities);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountByBusiness(Expression<Func<TEntity, bool>> predicate);
        Task<int> Count();
        Task<int> SaveChanges();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
