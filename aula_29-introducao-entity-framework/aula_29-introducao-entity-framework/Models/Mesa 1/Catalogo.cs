using Microsoft.EntityFrameworkCore;

namespace Mesa1.Models
{
    public class Catalogo : DbContext
    {
        public Catalogo(DbContextOptions<Catalogo> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Filme> Ator { get; set; }
    }
}