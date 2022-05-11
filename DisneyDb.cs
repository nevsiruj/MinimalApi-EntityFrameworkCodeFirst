using Microsoft.EntityFrameworkCore;

namespace ApiC03.Context
{
    public class DisneyDb : DbContext
    {
        public DisneyDb(DbContextOptions<DisneyDb> options)
            : base(options) { }

        public DbSet<Personaje> Personajes => Set<Personaje>();
    }
}
