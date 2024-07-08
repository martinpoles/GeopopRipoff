using GeopopRipoff.Models;
using Microsoft.EntityFrameworkCore;

namespace GeopopRipoff.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Argomenti> Argomenti { get; set; }
        public DbSet<Articoli> Articoli { get; set; }
        public DbSet<Autori> Autori { get; set; }
        public DbSet<Argomenti_Articoli> Argomenti_Articoli { get; set; }
        public DbSet<Articoli_Autori> Articoli_Autori { get; set; }

    }
}
