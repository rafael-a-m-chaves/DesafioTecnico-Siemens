using DesafioTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.Infrastructure.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }


        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<City> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
