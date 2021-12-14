using Microsoft.EntityFrameworkCore;
using WebApi.EnvioEmail.Models;

namespace WebApi.EnvioEmail.Data
{
    public class DbContextEmail : DbContext
    {
        public DbContextEmail(DbContextOptions<DbContextEmail> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmailRemetente>(builder =>
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.RemetenteEmail)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                builder.Property(p => p.NameEmpresa)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                builder.Property(p => p.Password)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                builder.Property(p => p.Host)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                builder.Property(p => p.Port)
                    .IsRequired()
                    .HasColumnType("int");

                builder.Property(p => p.Assunto)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                builder.Property(p => p.Corpo)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                builder.ToTable("EmailRemetente");
            });

            builder.Entity<Pessoa>(builder =>
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                builder.ToTable("Pessoa");
            });
        }

        public DbSet<EmailRemetente> EmailRemetente { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
