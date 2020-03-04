using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => InternalOnModelCreating(modelBuilder);

        // Unit testable because we can now inject a ModelBuilder
        internal void InternalOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlabConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}