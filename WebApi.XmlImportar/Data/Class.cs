using Microsoft.EntityFrameworkCore;
using WebApi.XmlImportar.Models;

namespace WebApi.XmlImportar.Data
{
    public class DbContextXml : DbContext
    {
        public DbContextXml(DbContextOptions<DbContextXml> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(builder =>
            {
                builder.Property(p => p.Id)
                    .HasColumnType("int");

                builder.Property(p => p.Name)
                    .HasColumnType("varchar(50)");

                builder.Property(p => p.Occupation)
                    .HasColumnType("varchar(50)");

                builder.ToTable("Users");
            });

            builder.Entity<Cidades>(builder =>
            {
                builder.Property(p => p.Capital)
                    .HasColumnType("varchar(50)");

                builder.Property(p => p.Population)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                builder.HasKey("Capital");

                builder.ToTable("Cidades");
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cidades> Cidades { get; set; }
    }
}
