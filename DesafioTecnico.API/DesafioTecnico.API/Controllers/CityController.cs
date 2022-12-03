using DesafioTecnico.Application.InterfaceServices;
using DesafioTecnico.Domain.Dtos.Input.City;
using DesafioTecnico.Library.Messages.Error;
using DesafioTecnico.Library.ReturnStructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService) 
        {
            _cityService = cityService;
        }

        
        [HttpGet]
        public async Task<IActionResult> ListCities(string name, string uf)
        {
            try
            {
                return Ok(await _cityService.ListCity(name,uf));
            }
            catch
            {
                return BadRequest(new ReturnStructure() 
                    { 
                        Messages = new List<string>() { ErrorMessages.InternalError },
                        Success = false 
                    }
                 );
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertCity([FromBody] CityInputDto cityInputDto)
        {
            try
            {
                return Ok(await _cityService.InsertNewCity(cityInputDto));
            }
            catch
            {
                return BadRequest(new ReturnStructure()
                    {
                        Messages = new List<string>() { ErrorMessages.InternalError },
                        Success = false
                    }
                );
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity([FromBody] CityInputDto cityInputDto)
        {
            try
            {
                return Ok(await _cityService.UpdateCity(cityInputDto));
            }
            catch
            {
                return BadRequest(new ReturnStructure()
                {
                    Messages = new List<string>() { ErrorMessages.InternalError },
                    Success = false
                }
                );
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int idCity)
        {
            try
            {
                return Ok(await _cityService.DeleteCity(idCity));
            }
            catch
            {
                return BadRequest(new ReturnStructure()
                {
                    Messages = new List<string>() { ErrorMessages.InternalError },
                    Success = false
                }
                );
            }
        }
    }
}
