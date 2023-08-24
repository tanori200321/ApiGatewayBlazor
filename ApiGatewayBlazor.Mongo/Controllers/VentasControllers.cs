using ApiGatewayBlazor.Mongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<VentasController> _logger;

        private int _likeValue = 1;
        private int _dislikeValue = -1000;

        public VentasController(IMongoDatabase database, ILogger<VentasController> logger)
        {
            _ventasCollection = database.GetCollection<Ventas>("Ventas");
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            try
            {
                List<Ventas> ventas = await _ventasCollection.Find(venta => true).ToListAsync();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las ventas");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("venta")]
        public async Task<IActionResult> CreateVenta([FromBody] Ventas venta)
        {
            try
            {

                venta.Movimiento = venta.Valor > 0 ? "like" : "dislike";
                venta.Valor = venta.Movimiento == "like" ? _likeValue : _dislikeValue;


                await _ventasCollection.InsertOneAsync(venta);

                return CreatedAtAction(nameof(GetVentas), new { id = venta.Id }, venta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la venta");
                return StatusCode(500, "Error interno del servidor");
            }
        }

    }

    [ApiController]
    [Route("api/[controller]")]
    public class ReaccionController : ControllerBase
    {
        private int _likeValue = 1;
        private int _dislikeValue = -1000;

        [HttpPost]
        public IActionResult ProcesarReaccion([FromBody] string movimiento)
        {
            try
            {
                var valor = movimiento == "like" ? _likeValue : _dislikeValue;

                if (movimiento == "like")
                {
                    _likeValue++;
                }
                else if (movimiento == "dislike")
                {
                    _dislikeValue--;
                }

                return Ok(valor);
            }
            catch (Exception ex)
            {
  
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
