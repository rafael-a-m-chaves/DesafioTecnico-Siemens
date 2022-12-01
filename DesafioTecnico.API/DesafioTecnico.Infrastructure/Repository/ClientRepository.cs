using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Infrastructure.Context;
using DesafioTecnico.Infrastructure.InterfaceRepository;

namespace DesafioTecnico.Infrastructure.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(APIContext context)
            : base(context) { }
    }
}
