namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class CarritoCompras
    {

        public int Id { get; set; } 
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        List<Producto> Productos { get; set; }
        List<Cliente> Clientes { get; set; }

    }
}
