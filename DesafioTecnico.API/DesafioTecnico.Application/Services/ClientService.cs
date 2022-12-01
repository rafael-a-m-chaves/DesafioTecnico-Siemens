using DesafioTecnico.Application.InterfaceServices;
using DesafioTecnico.Infrastructure.InterfaceRepository;

namespace DesafioTecnico.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICityRepository _cityRepository;
        public ClientService(
            IClientRepository clientRepository,
            ICityRepository cityRepository)
        {
            _clientRepository = clientRepository;
            _cityRepository = cityRepository;
        }
    }
}
