using DesafioTecnico.Application.InterfaceServices;
using DesafioTecnico.Domain.Dtos.Input.City;
using DesafioTecnico.Domain.Dtos.Output.City;
using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Infrastructure.InterfaceRepository;
using DesafioTecnico.Library.Messages.Error;
using DesafioTecnico.Library.Messages.Success;
using DesafioTecnico.Library.ReturnStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioTecnico.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository) 
        {
            _cityRepository = cityRepository;
        }


        public async Task<ReturnStructure> InsertNewCity(CityInputDto newCityInputDto)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false};
            try
            {
                returnStructure = await ValidadeInputDtoCity(newCityInputDto);

                if (!returnStructure.Success) return returnStructure;

                City newCity = (City)newCityInputDto;

                _cityRepository.Salvar(newCity);
                await _cityRepository.CommitAsync();
                returnStructure.Success = true;
                returnStructure.Messages = new List<string>() { SuccesMessages.SuccessInsertCity };
                return await Task.Run(() => { return returnStructure; });
            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructureData<List<CityOutputDto>>> ListCity(string nome, string uf) 
        {
            var returnStructure = new ReturnStructureData<List<CityOutputDto>>();

            try
            {
               
                var query = new List<Expression<Func<City, bool>>>();
                if (!string.IsNullOrWhiteSpace(nome))
                    query.Add(x => x.Name.ToLower().Contains(nome.ToLower()));

                if (!string.IsNullOrWhiteSpace(uf))
                    query.Add(x => x.UF.ToLower().Contains(uf.ToLower()));

                List<City> listCities = _cityRepository.Listar(query, ordenadoPor: (y => y.OrderBy(y => y.UF + y.Name))).ToList();

                returnStructure.Data = CityOutputDto.ConvertForDTO(listCities);
                returnStructure.Success = true;
                returnStructure.Messages = new List<string>() {
                                                                string.IsNullOrWhiteSpace(nome) &&
                                                                string.IsNullOrWhiteSpace(uf) ?
                                                                SuccesMessages.SuccessListCities :
                                                                SuccesMessages.SuccessSearchCities
                                                              };
                return await Task.Run(()=> { return returnStructure; });

            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructure> UpdateCity(CityInputDto updateCityInputDto)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            try
            {
                returnStructure = await ValidadeInputDtoCity(updateCityInputDto);

                if (!returnStructure.Success) return returnStructure;

                City city = _cityRepository.Obter(updateCityInputDto.Id);

                if(city == null)
                {
                    returnStructure.Messages = new List<string>() { ErrorMessages.CityNotFound };
                    return await Task.Run(() => { return returnStructure; });
                }

                city = (City)updateCityInputDto;

                _cityRepository.Atualizar(city);
                await _cityRepository.CommitAsync();

                returnStructure.Messages = new List<string>() { SuccesMessages.SuccessUpdateCity };
                return await Task.Run(() => { return returnStructure; });
            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructure> DeleteCity(int idCity)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            try
            {
                var city = _cityRepository.Obter(idCity, propriedadesIncluidas: "Clients");
                if (city.Clients != null && city.Clients.Count > 0)
                {
                    returnStructure.Success = false;
                    returnStructure.Messages = new List<string>() { ErrorMessages.CityWithClient };
                }
                else
                {
                    _cityRepository.Excluir(idCity);
                    _cityRepository.Commit();
                    returnStructure.Success = true;
                    returnStructure.Messages = new List<string>() { SuccesMessages.SuccessCityDeleted };
                }
                return await Task.Run(()=> { return returnStructure; });
            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        private async  Task<ReturnStructure> ValidadeInputDtoCity(CityInputDto cityInputDto)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            if (cityInputDto == null)
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.NullCityValidate };
                return await Task.Run(() => { return returnStructure; });
            }

            if (string.IsNullOrWhiteSpace(cityInputDto.Name))
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.NullOrEmptyCityNameValidate };
                return await Task.Run(() => { return returnStructure; });
            }

            if (string.IsNullOrWhiteSpace(cityInputDto.UF))
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.NullOrEmptyCityUFValidate };
                return await Task.Run(() => { return returnStructure; });
            }

            if(cityInputDto.UF.Length != 2)
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.UFLengthError };
                return await Task.Run(() => { return returnStructure; });
            }

            if(cityInputDto.Id == 0)
            {
                var city = _cityRepository.Obter(x => x.Name.ToLower().Contains(cityInputDto.Name.ToLower()) && x.UF.ToLower().Contains(cityInputDto.UF.ToLower()));
                if(city != null && city.Id != 0)
                {
                    returnStructure.Messages = new List<string>() { ErrorMessages.CityAlreadyRegistered };
                    return await Task.Run(() => { return returnStructure; });
                }
            }

            returnStructure.Success = true;
            return await Task.Run(() => { return returnStructure; });
        }
    }
}
