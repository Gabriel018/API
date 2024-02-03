using ChMaster.Blockchain.Data.Contexts;
using ChMaster.Blockchain.Domain.Entities;
using MED.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChMaster.Blockchain.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ChMasterDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(ChMasterDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }


        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task AdicionarLista(IEnumerable<TEntity> entities)
        {
            
             DbSet.AddRange(entities);
            await SaveChanges();
        }
        public virtual async Task Atualizar(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual async Task AtualizarLista(IEnumerable<TEntity>entities)
        {
            DbSet.UpdateRange(entities);
            await SaveChanges();
        }
        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<int> CountByBusiness(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.CountAsync(predicate);
        }

        public async Task<int> Count()
        {
            return await DbSet.CountAsync();
        }
        public void Dispose()
        {
            Db?.DisposeAsync();
        }
    }
}
