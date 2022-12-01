using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Infrastructure.Context;
using DesafioTecnico.Infrastructure.InterfaceRepository;

namespace DesafioTecnico.Infrastructure.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(APIContext context)
            : base(context) { }
    }
}
