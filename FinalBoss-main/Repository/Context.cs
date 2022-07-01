using Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Senha> Senhas { get; set; }

        public DbSet<SenhaTag> SenhaTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Usuario> Usuarios { get; set;}

        // Revisar

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=localhost;User Id=root;Database=encryptme");
    }
}