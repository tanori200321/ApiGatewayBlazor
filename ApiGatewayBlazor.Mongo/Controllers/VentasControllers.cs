using ApiGatewayBlazor.Mongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGatewayBlazor.Mongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IMongoCollection<Ventas> _ventasCollection;

        public VentasController(IMongoDatabase database)
        {
            _ventasCollection = database.GetCollection<Ventas>("Ventas");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            var ventas = await _ventasCollection.Find(Builders<Ventas>.Filter.Empty).ToListAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ventas>> GetVenta(string id)
        {
            var venta = await _ventasCollection.Find(Builders<Ventas>.Filter.Eq("_id", id)).FirstOrDefaultAsync();

            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVenta(Ventas venta)
        {
            await _ventasCollection.InsertOneAsync(venta);
            return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(string id)
        {
            var deleteResult = await _ventasCollection.DeleteOneAsync(Builders<Ventas>.Filter.Eq("_id", id));

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{id}/Like")]
        public async Task<IActionResult> PostLike(string id)
        {
            var updateResult = await _ventasCollection.UpdateOneAsync(
                Builders<Ventas>.Filter.Eq("_id", id),
                Builders<Ventas>.Update.Inc(x => x.Valor, 1).Set(x => x.Movimiento, "like"));

            if (updateResult.ModifiedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{id}/Dislike")]
        public async Task<IActionResult> PostDislike(string id)
        {
            var updateResult = await _ventasCollection.UpdateOneAsync(
                Builders<Ventas>.Filter.Eq("_id", id),
                Builders<Ventas>.Update.Inc(x => x.Valor, -1000).Set(x => x.Movimiento, "dislike"));

            if (updateResult.ModifiedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
