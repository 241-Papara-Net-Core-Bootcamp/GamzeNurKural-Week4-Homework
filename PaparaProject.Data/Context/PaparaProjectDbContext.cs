using Microsoft.EntityFrameworkCore;
using PaparaProject.Data.Configurations;
using PaparaProject.Domain.Entities;

namespace PaparaProject.Data.Context
{
    public class PaparaProjectDbContext : DbContext
    {
        public PaparaProjectDbContext(DbContextOptions<PaparaProjectDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        }

        DbSet<Worker> Workers { get; set; }
    }
}
