using ApiGatewayBlazor.SqlServer.Models;
using ApiGatewayBlazor.SqlServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }



    }
}
