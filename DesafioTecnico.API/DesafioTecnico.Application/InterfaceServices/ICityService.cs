using DesafioTecnico.Domain.Dtos.Input.City;
using DesafioTecnico.Domain.Dtos.Output.City;
using DesafioTecnico.Library.ReturnStructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Application.InterfaceServices
{
    public interface ICityService
    {
        Task<ReturnStructure> InsertNewCity(CityInputDto newCityInputDto);

        Task<ReturnStructure> UpdateCity(CityInputDto updateCityInputDto);

        Task<ReturnStructureData<List<CityOutputDto>>> ListCity(string nome, string uf);

        Task<ReturnStructure> DeleteCity(int idCity);
    }
}
