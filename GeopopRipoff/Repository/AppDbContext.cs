using GeopopRipoff.Models;
using Microsoft.EntityFrameworkCore;

namespace GeopopRipoff.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Contenuto> Contenuto { get; set; }
        public DbSet<Argomento> Argomenti { get; set; }
        public DbSet<Formato> Formato { get; set; }
        public DbSet<Autore> Autore { get; set; }
        public DbSet<ContenutoAutore> ContenutoAutore { get; set; }
        public DbSet<ContenutoFormato> ContenutoFormato { get; set; }
        public DbSet<ContenutoArgomento> ContenutoArgomento { get; set; }

    }
}
