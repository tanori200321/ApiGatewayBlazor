using ApiGatewayBlazor.SqlServer.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace TuProyecto.Controllers
{
    public class StoreController
    {
        private readonly ApplicationDbContext _dbContext;

        public StoreController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _dbContext.Productos.ToListAsync();
        }

        public async Task<Cliente> GetCliente(int clienteId)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == clienteId);
        }

        public async Task<List<Pedidos>> GetPedidos()
        {
            return await _dbContext.Pedido.ToListAsync();
        }

        public async Task RealizarCompra(CarritoCompras carrito)
        {
            var producto = await _dbContext.Productos.FindAsync(carrito.IdProducto);

            if (producto == null || producto.CantidadStock < carrito.Cantidad)
            {
                // Manejo de error si el producto no existe o no hay suficiente stock
                return;
            }

            var pedido = new Pedidos
            {
                IdCliente = carrito.IdCliente,
                IdProducto = carrito.IdProducto,
                Cantidad = carrito.Cantidad,
                Total = producto.Precio * carrito.Cantidad,
                Fecha = DateTime.UtcNow
            };

            producto.CantidadStock -= carrito.Cantidad;
            _dbContext.Pedido.Add(pedido);
            await _dbContext.SaveChangesAsync();
        }
    }
}
