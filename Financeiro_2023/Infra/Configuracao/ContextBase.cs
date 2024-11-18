using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base()
        {
        }

        public DbSet<SistemaFinanceiro> SistemaFinanceiros { get; set; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiros { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Despesa> Despesa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating (ModelBuilder Builder)
        {
            Builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(Builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=DESKTOP-R0C51AN;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True";
        }
    }
}
