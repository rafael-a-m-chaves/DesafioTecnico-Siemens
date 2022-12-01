using DesafioTecnico.Application.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioTecnico.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService) 
        {
            _cityService = cityService;
        }

        
        [HttpGet]
        public async Task<IActionResult> ListCities()
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
