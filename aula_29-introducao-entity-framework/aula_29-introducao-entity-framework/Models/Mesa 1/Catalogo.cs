using Microsoft.EntityFrameworkCore;
using Models.Mesa_1;

namespace Mesa1.Models
{
    public class Catalogo : DbContext
    {
        public Catalogo(DbContextOptions<Catalogo> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Ator> Atores { get; set; }
    }
}