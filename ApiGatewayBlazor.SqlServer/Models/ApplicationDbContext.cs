using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace ApiGatewayBlazor.SqlServer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedidos> Pedido { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CarritoCompras> CarritoCompra { get; set; }



    }
}
