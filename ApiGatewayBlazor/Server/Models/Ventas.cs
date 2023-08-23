
namespace ApiGatewayBlazor.Mongo.Models
{
    public class Ventas
    {

        public int Id { get; set; }

        public int ProductoId { get; set; }

        public string DescripcionProducto { get; set; } = string.Empty;

        public int ClienteId { get; set; }


        public string NombreCliente { get; set; } = string.Empty;

        public bool Likes { get; set; }
        public bool DisLikes { get; set; }

    }
}
