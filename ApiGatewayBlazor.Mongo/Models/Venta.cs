using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiGatewayBlazor.Mongo.Models
{
    public class Venta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("IdProducto")]
        public int IdProducto { get; set; }

        [BsonElement("IdCliente")]
        public int IdCliente { get; set; }

        [BsonElement("Total")]
        public decimal Total { get; set; }

        [BsonElement("Likes")]
        public int Likes { get; set; }

        [BsonElement("Dislikes")]
        public int Dislikes { get; set; }
    }
}
