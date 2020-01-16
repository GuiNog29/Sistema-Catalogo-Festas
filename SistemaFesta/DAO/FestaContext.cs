using Microsoft.EntityFrameworkCore;
using SistemaFesta.Models;
using System.Linq;

namespace SistemaFesta.DAO
{
    public class FestaContext : DbContext
    {
        public DbSet<Administrador> Administrador { get; private set; }
        public DbSet<Tema> Temas { get; private set; }
        public DbSet<Fornecedor> Fornecedores { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SistemaFestaDB;Trusted_Connection=true;");
        }

       
    }
}