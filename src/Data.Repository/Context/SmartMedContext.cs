namespace Data.Repository.Context
{
    using Data.Model;
    using Microsoft.EntityFrameworkCore;

    public class SmartMedContext : DbContext
    {
        public SmartMedContext(DbContextOptions<SmartMedContext> options)
            : base(options)
        {
        }

        public DbSet<Medication> Medication { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}