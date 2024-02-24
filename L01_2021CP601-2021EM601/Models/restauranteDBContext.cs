using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2021CP601_2021EM601.Models
{
    public class restauranteDBContext : DbContext
    {
        public restauranteDBContext(DbContextOptions<restauranteDBContext> options) : base(options)
        {

        }

        public DbSet<clientes> clientes { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<motoristas> motoristas { get; set; }

    }
}
