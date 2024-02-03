using Microsoft.EntityFrameworkCore;
using MED.Domain.Entities;
using System.Reflection;

namespace MED.Data.Contexts
{
    public class MedContexts : DbContext
    {
        public MedContexts(DbContextOptions options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            AddCreatedAt();
            AddUpdatedAt();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddCreatedAt() =>
            ChangeTracker.Entries().Where(p => p.Entity is Entity && p.State.Equals(EntityState.Added)).ToList()
                .ForEach(p => ((Entity)p.Entity).CreatedAt = DateTime.UtcNow);

        private void AddUpdatedAt() =>
            ChangeTracker.Entries().Where(p => p.Entity is Entity && p.State.Equals(EntityState.Modified)).ToList()
                .ForEach(p => ((Entity)p.Entity).UpdatedAt = DateTime.UtcNow);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
