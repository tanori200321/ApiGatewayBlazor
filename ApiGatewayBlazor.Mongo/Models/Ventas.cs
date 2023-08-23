using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiGatewayBlazor.Mongo.Models
{
    public class Ventas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        //DATOS PARA LA VENTA:

        [BsonElement("productoID")]
        public int ProductoId { get; set; }

        [BsonElement("descripcionProducto")]
        public string DescripcionProducto { get; set; } = string.Empty;

        [BsonElement("clienteID")]
        public int ClienteId { get; set; }

        [BsonElement("nombreCliente")]
        public string NombreCliente { get; set; } = string.Empty;

        [BsonElement("movimiento")]
        public string Movimiento { get; set; } = string.Empty;

        [BsonElement("valor")]
        public int Valor { get; set; }

    }
}
