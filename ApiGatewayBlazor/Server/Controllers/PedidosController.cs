using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApiGatewayBlazor.SqlServer.Models.Entities;

namespace ApiGatewayBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PedidosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pedidos pedido)
        {
            var clienteSql = _httpClientFactory.CreateClient("Sql");

            var pedidoJson = JsonSerializer.Serialize(pedido);
            var content = new StringContent(pedidoJson, Encoding.UTF8, "application/json");

            var responseSql = await clienteSql.PostAsync("/api/Pedidos", content);

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
