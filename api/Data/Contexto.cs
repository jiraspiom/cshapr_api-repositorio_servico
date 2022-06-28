using api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class Contexto : DbContext
    {
        // Primeiro 
        public DbSet<Usuario> Usuarios { get; set; }

        // Segundo - Many para Many
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        // Terceiro - 1 pra muitos
        public DbSet<Curso> Cursos{ get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => base.OnConfiguring(optionsBuilder.UseSqlite("DataSource=arquivo.db; Cache=Shared"));

        // Segundo - Para adicionar o relacionamento de muitos para muitos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(x => new { x.BookId, x.AuthorId });
        }
    }
}
