using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApiGatewayBlazor.Client.Models.Entidad;

namespace ApiGatewayBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoComprasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarritoComprasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarritoCompra carritoCompra)
        {
            var clienteSql = _httpClientFactory.CreateClient("Sql");

            var carritoCompraJson = JsonSerializer.Serialize(carritoCompra);
            var content = new StringContent(carritoCompraJson, Encoding.UTF8, "application/json");

            var responseSql = await clienteSql.PostAsync("/api/CarritoCompras", content);

            if (responseSql.IsSuccessStatusCode)
            {
                return Ok(); // Successfully inserted
            }
            else
            {
                return StatusCode((int)responseSql.StatusCode, responseSql.ReasonPhrase);
            }
        }
    }
}
