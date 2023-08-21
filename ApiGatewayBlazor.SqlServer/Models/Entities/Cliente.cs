using System.ComponentModel.DataAnnotations;

namespace ApiGatewayBlazor.SqlServer.Models.Entities
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        List<Pedidos> Pedido { get; set; }
        List<CarritoCompras> CarritoCompra { get; set; }




    }
}
