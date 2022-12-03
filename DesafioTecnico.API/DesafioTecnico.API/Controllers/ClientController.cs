using DesafioTecnico.Application.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioTecnico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService= clientService;
        }


        [HttpGet]
        public async Task<IActionResult> ListClients()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
