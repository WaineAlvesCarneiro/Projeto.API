using Microsoft.EntityFrameworkCore;
using WebApi.CopiaCriptografa.Models;

namespace WebApi.CopiaCriptografa.Data
{
    public class DbContextLancCripto : DbContext
    {
        public DbContextLancCripto(DbContextOptions<DbContextLancCripto> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lancamento>(builder =>
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Texto)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                builder.ToTable("Lancamentos");
            });

            builder.Entity<TudoLancado>(builder =>
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.IdTexto)
                    .HasColumnType("int");

                builder.Property(p => p.TextoCrypt)
                    .IsRequired()
                    .HasColumnType("varchar(600)");

                builder.ToTable("TudoLancados");
            });
        }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<TudoLancado> TudoLancados { get; set; }
    }
}
