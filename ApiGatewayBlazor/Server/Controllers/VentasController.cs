using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ApiGatewayBlazor.Mongo.Models;

namespace ApiGatewayBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VentasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            try
            {
                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync("URL_DEL_MICROSERVICIO_DE_VENTAS");
                response.EnsureSuccessStatusCode();
                var ventas = await response.Content.ReadFromJsonAsync<List<Ventas>>();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id)
        {
            try
            {
                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync($"URL_DEL_MICROSERVICIO_DE_VENTAS/{id}");
                response.EnsureSuccessStatusCode();
                var venta = await response.Content.ReadFromJsonAsync<Ventas>();
                if (venta == null)
                {
                    return NotFound();
                }
                return Ok(venta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<IActionResult> PostVenta(Ventas venta)
        {
            try
            {
                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.PostAsJsonAsync("URL_DEL_MICROSERVICIO_DE_VENTAS", venta);
                response.EnsureSuccessStatusCode();
                return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
