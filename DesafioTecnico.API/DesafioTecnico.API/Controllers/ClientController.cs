using DesafioTecnico.Application.InterfaceServices;
using DesafioTecnico.Domain.Dtos.Input.Client;
using DesafioTecnico.Library.Messages.Error;
using DesafioTecnico.Library.ReturnStructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService= clientService;
        }


        [HttpGet]
        public async Task<IActionResult> ListClient(string name, string uf, int? id)
        {
            try
            {
                return Ok(await _clientService.ListClient(name, uf, id));
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

        [HttpGet]
        public async Task<IActionResult> GetClient(int idClient)
        {
            try
            {
                return Ok(await _clientService.GetClient(idClient));
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
        public async Task<IActionResult> InsertClient([FromBody] ClientInputDto clientInputDto)
        {
            try
            {
                return Ok(await _clientService.InsertNewClient(clientInputDto));
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
        public async Task<IActionResult> UpdateClient([FromBody] ClientInputDto clientInputDto)
        {
            try
            {
                return Ok(await _clientService.UpdateClient(clientInputDto));
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
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            try
            {
                return Ok(await _clientService.DeleteClient(idClient));
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
