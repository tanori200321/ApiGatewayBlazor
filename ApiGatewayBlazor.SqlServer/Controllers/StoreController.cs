using ApiGatewayBlazor.SqlServer.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoComprasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarritoComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoCompras>>> GetCarritosCompras()
        {
            var carritos = await _context.CarritoCompra.ToListAsync();
            return Ok(carritos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoCompras>> GetCarritoCompras(int id)
        {
            var carrito = await _context.CarritoCompra.FindAsync(id);

            if (carrito == null)
            {
                return NotFound();
            }

            return Ok(carrito);
        }

        [HttpPost]
        public async Task<ActionResult<CarritoCompras>> PostCarritoCompras([FromBody] CarritoCompras carrito)
        {
            _context.CarritoCompra.Add(carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarritoCompras", new { id = carrito.Id }, carrito);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarritoCompras(int id, CarritoCompras carrito)
        {
            if (id != carrito.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoComprasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoCompras(int id)
        {
            var carrito = await _context.CarritoCompra.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.CarritoCompra.Remove(carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarritoComprasExists(int id)
        {
            return _context.CarritoCompra.Any(e => e.Id == id);
        }
    }
}
