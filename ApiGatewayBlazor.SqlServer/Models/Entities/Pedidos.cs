using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        List<Cliente> Cliente { get; set; }
        List<Producto> Productos { get; set; }



    }
}
