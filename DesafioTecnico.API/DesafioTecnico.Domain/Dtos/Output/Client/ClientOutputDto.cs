using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTecnico.Domain.Dtos.Output.Client
{
    public class ClientOutputDto
    {
        public static List<ClientOutputDto> ConvertForDTO(List<Entities.Client> v)
        {
            List<ClientOutputDto> listCityOutputDto = v.Select(x => new ClientOutputDto()
            {
                Name = x.Name,
                Localization = $"{x.City.Name} / {x.City.UF}",
                Id = x.Id,
                IdCity = x.IdCity,
                Age = x.Age,
                Gender = x.Gender,
                BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                DateUpdateOrCreate = x.DateUpdate == null ? x.DateCreate.ToString("dd/MM/yyyy HH:mm") :
                                                            x.DateUpdate?.ToString("dd/MM/yyyy HH:mm")
            }).ToList();
            return listCityOutputDto;
        }

        public static explicit operator ClientOutputDto(Entities.Client v)
        {
            return new ClientOutputDto()
            {
                Name = v.Name,
                Localization = $"{v.City.Name} / {v.City.UF}",
                Id = v.Id,
                IdCity = v.IdCity,
                Age = v.Age,
                Gender = v.Gender,
                BirthDate = v.BirthDate.ToString("dd/MM/yyyy"),
                DateUpdateOrCreate = v.DateUpdate == null ? v.DateCreate.ToString("dd/MM/yyyy HH:mm") :
                                                            v.DateUpdate?.ToString("dd/MM/yyyy HH:mm")
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Localization { get; set; }

        public string DateUpdateOrCreate { get; set; }

        public int IdCity { get; set; }

        public int Age { get; set; }

        public string BirthDate { get; set; }

        public string Gender { get; set; }
    }
}
