using ApiGatewayBlazor.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGatewayBlazor.Server.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            List<Producto> lista = new List<Producto>();

            //var clienteMongo = _httpClientFactory.CreateClient("Mongo");
            //var response = await clienteMongo.GetAsync("/WeatherForecast");
            //if (response.IsSuccessStatusCode)
            //{
            //    var contenido = await response.Content.ReadAsStringAsync();
            //    var options = new JsonSerializerOptions()
            //    {
            //        PropertyNameCaseInsensitive = true
            //    };
            //    var resultado = JsonSerializer.Deserialize<List<WeatherForecast>>(contenido, options);
            //    lista.AddRange(resultado!);
            //}

            var clienteSql = _httpClientFactory.CreateClient("Sql");
            var responseSql = await clienteSql.GetAsync("/ProductosController");
            if (responseSql.IsSuccessStatusCode)
            {
                var contenido = await responseSql.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var resultado = JsonSerializer.Deserialize<List<Producto>>(contenido, options);
                lista.AddRange(resultado!);
            }
            return lista;
        }

    }
}
