using DesafioTecnico.Application.InterfaceServices;
using DesafioTecnico.Domain.Dtos.Input.Client;
using DesafioTecnico.Domain.Dtos.Output.Client;
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


        public async Task<ReturnStructure> InsertNewClient(ClientInputDto newClientInputDto)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            try
            {
                var dateNow = DateTime.Now;
                newClientInputDto.Age = Convert.ToInt32((dateNow.Year - newClientInputDto.BirthDate.Year));
                
                if (dateNow.Month > newClientInputDto.BirthDate.Month &&
                   dateNow.Day > newClientInputDto.BirthDate.Day)
                    newClientInputDto.Age--;

                returnStructure = await ValidadeInputDtoClient(newClientInputDto);

                if (!returnStructure.Success) return returnStructure;

                Client newClient = (Client)newClientInputDto;
                newClient.City = _cityRepository.Obter(newClientInputDto.IdCity);

                _clientRepository.Salvar(newClient);
                await _clientRepository.CommitAsync();
                returnStructure.Success = true;
                returnStructure.Messages = new List<string>() { SuccesMessages.SuccessInsertClient };
                return await Task.Run(() => { return returnStructure; });
            }
            catch(Exception ex)
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructureData<List<ClientOutputDto>>> ListClient(string nome, int? idCity, int? idClient)
        {
            var returnStructure = new ReturnStructureData<List<ClientOutputDto>>();

            try
            {

                var query = new List<Expression<Func<Client, bool>>>();
                if (!string.IsNullOrWhiteSpace(nome))
                    query.Add(x => x.Name.ToLower().Contains(nome.ToLower()));

                if (idCity != null)
                    query.Add(x => x.IdCity == idCity);

                if (idClient != null && idClient != 0)
                    query.Add(x => x.Id == idClient);

                List<Client> listClients = _clientRepository.Listar(query, 
                                                                    ordenadoPor: (y => y.OrderBy(y => y.City.UF + y.City.Name + y.Name)), 
                                                                    propriedadesIncluidas: "City").ToList();

                returnStructure.Data = ClientOutputDto.ConvertForDTO(listClients);
                returnStructure.Success = true;
                returnStructure.Messages = new List<string>() {
                                                                string.IsNullOrWhiteSpace(nome) &&
                                                                idClient == null && idCity == null?
                                                                SuccesMessages.SuccessListClients :
                                                                SuccesMessages.SuccessSearchClients
                                                              };
                return await Task.Run(() => { return returnStructure; });

            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructure> UpdateClient(ClientInputDto updateClientInputDto)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            try
            {
                var dateNow = DateTime.Now;
                updateClientInputDto.Age = Convert.ToInt32((dateNow.Year - updateClientInputDto.BirthDate.Year));

                if (dateNow.Month >= updateClientInputDto.BirthDate.Month &&
                   dateNow.Day <= updateClientInputDto.BirthDate.Day)
                    updateClientInputDto.Age--;

                returnStructure = await ValidadeInputDtoClient(updateClientInputDto);

                if (!returnStructure.Success) return returnStructure;

                Client client = _clientRepository.Obter(updateClientInputDto.Id);

                if (client == null)
                {
                    returnStructure.Messages = new List<string>() { ErrorMessages.ClientNotFound };
                    return await Task.Run(() => { return returnStructure; });
                }

                client.Name = updateClientInputDto.Name;
                client.Gender = updateClientInputDto.Gender;
                client.IdCity = updateClientInputDto.IdCity;
                client.BirthDate = updateClientInputDto.BirthDate;
                client.City = _cityRepository.Obter(updateClientInputDto.IdCity);
                client.Age = updateClientInputDto.Age;
                client.DateUpdate = DateTime.Now;

                _clientRepository.Atualizar(client);
                await _clientRepository.CommitAsync();

                returnStructure.Messages = new List<string>() { SuccesMessages.SuccessUpdateClient };
                return await Task.Run(() => { return returnStructure; });
            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructure> DeleteClient(int idClient)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            try
            {
                var client = _clientRepository.Obter(idClient);
                _clientRepository.Excluir(client);
                _clientRepository.Commit();
                returnStructure.Success = true;
                returnStructure.Messages = new List<string>() { SuccesMessages.SuccessClientDeleted };
               
                return await Task.Run(() => { return returnStructure; });
            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        public async Task<ReturnStructureData<ClientOutputDto>> GetClient(int idClient)
        {
            ReturnStructureData<ClientOutputDto> returnStructure = new ReturnStructureData<ClientOutputDto>() { Success = false };
            try
            {
                var client = _clientRepository.Obter(idClient, propriedadesIncluidas:"City");
                
                returnStructure.Success = client != null && client.Id != 0;
                returnStructure.Data = client != null && client.Id != 0 ? (ClientOutputDto)client : null;
                returnStructure.Messages = new List<string>() { client != null && client.Id != 0 ? 
                    SuccesMessages.SuccessSearchClients :
                    ErrorMessages.ClientNotFound };

                return await Task.Run(() => { return returnStructure; });
            }
            catch
            {
                returnStructure.Success = false;
                returnStructure.Messages = new List<string>() { ErrorMessages.InternalError };
                return await Task.Run(() => { return returnStructure; });
            }
        }

        private async Task<ReturnStructure> ValidadeInputDtoClient(ClientInputDto clientInputDto)
        {
            ReturnStructure returnStructure = new ReturnStructure() { Success = false };
            if (clientInputDto == null)
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.NullClientValidate };
                return await Task.Run(() => { return returnStructure; });
            }

            if (string.IsNullOrWhiteSpace(clientInputDto.Name))
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.NullOrEmptyClientNameValidate };
                return await Task.Run(() => { return returnStructure; });
            }

            if (string.IsNullOrWhiteSpace(clientInputDto.Gender))
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.NullOrEmptyClientGenderValidate };
                return await Task.Run(() => { return returnStructure; });
            }

            if (clientInputDto.IdCity == 0)
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.CityReferenceError };
                return await Task.Run(() => { return returnStructure; });
            }

            var city = _cityRepository.Obter(clientInputDto.IdCity);

            if (city == null || city.Id == 0)
            {
                returnStructure.Messages = new List<string>() { ErrorMessages.CityNotFound };
                return await Task.Run(() => { return returnStructure; });
            }

            returnStructure.Success = true;
            return await Task.Run(() => { return returnStructure; });
        }
    }
}
