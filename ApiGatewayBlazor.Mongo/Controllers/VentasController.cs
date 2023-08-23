using ApiGatewayBlazor.Mongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiGatewayBlazor.Mongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        //Conectar a la base de datos
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;


        //Coleccion = tabla
        private readonly IMongoCollection<Ventas> _collection;
        public VentasController()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("storeMongoDB");
            //Coleccion = tabla
            _collection = _database.GetCollection<Ventas>("Venta");

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarVenta([FromBody] Ventas venta)
        {
            Ventas venta1 = new Ventas();
            venta1.ProductoId = venta.ProductoId;
            venta1.DescripcionProducto = venta.DescripcionProducto;
            venta1.NombreCliente = venta.NombreCliente;
            venta1.ClienteId = venta.ClienteId;

            await _collection.InsertOneAsync(venta);

            return Ok("Venta generada exitosamente.");
        }

        [HttpPost]
        public async Task<IActionResult> GenerarVenta([FromBody] Ventas venta)
        {
            if (venta == null)
                return BadRequest();
            if (venta.DescripcionProducto == string.Empty)
            {
                ModelState.AddModelError("descripcionProducto", "La venta no ha sido encontrada");
            }
            await _collection.InsertOneAsync(venta);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GenerarLike([FromBody] Ventas like)
        {
            Ventas likes = new Ventas();
            likes.Likes = true;

            await _collection.InsertOneAsync(like);

            return Ok("Like generado exitosamente.");
        }

        [HttpPost]
        public async Task<IActionResult> GenerarDislike([FromBody] Ventas dislike)
        {
            Ventas dislikes = new Ventas();
            dislikes.DisLikes = true;

            await _collection.InsertOneAsync(dislike);

            return Ok("Dislike generado exitosamente.");
        }

        private int likeCount = 0;

        private void IncrementLikeCount()
        {
            likeCount++;
        }

        private void DecrementLikeCount()
        {
            likeCount--;
        }
    }
}





