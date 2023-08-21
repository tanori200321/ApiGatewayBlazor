using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }

        List<Pedidos> Pedido { get; set; }





    }
}
