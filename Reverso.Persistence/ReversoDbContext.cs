using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Reverso.Domain;
using Reverso.Persistence.Configuration;

namespace Reverso.Persistence
{
    public class ReversoDbContext : DbContext
    {
        public ReversoDbContext(string connectionString) : base(GetOptions(connectionString)) { }
        public ReversoDbContext(DbContextOptions options) : base(options)
        {
            if (Database.ProviderName == "Microsoft.EntityCoreFramework.InMemory")
            {
                return;
            }
        }
        public DbSet<Phrase> ReversedPhrases { get; set; }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReversedPhraseConfiguration());
        }
    }
}