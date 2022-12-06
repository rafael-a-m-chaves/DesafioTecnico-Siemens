using DesafioTecnico.Domain.Dtos.Input.Client;
using DesafioTecnico.Domain.Dtos.Output.Client;
using DesafioTecnico.Library.ReturnStructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Application.InterfaceServices
{
    public interface IClientService
    {
        Task<ReturnStructure> InsertNewClient(ClientInputDto newClientInputDto);

        Task<ReturnStructureData<List<ClientOutputDto>>> ListClient(string nome, int? idCity, int? idClient);

        Task<ReturnStructure> UpdateClient(ClientInputDto updateClientInputDto);

        Task<ReturnStructure> DeleteClient(int idClient);

        Task<ReturnStructureData<ClientOutputDto>> GetClient(int idClient);
    }
}
