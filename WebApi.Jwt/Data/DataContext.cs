using Microsoft.EntityFrameworkCore;
using WebApi.Jwt.Models;

namespace WebApi.Jwt.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoas> Pessoas { get; set; }
    }
}
