using api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => base.OnConfiguring(optionsBuilder.UseSqlite("DataSource=arquivo.db; Cache=Shared"));
    }
}
