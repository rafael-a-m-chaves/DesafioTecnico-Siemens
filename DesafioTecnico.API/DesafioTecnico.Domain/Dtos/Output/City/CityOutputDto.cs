using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTecnico.Domain.Dtos.Output.City
{
    public class CityOutputDto
    {
        public static  List<CityOutputDto> ConvertForDTO(List<Entities.City> v)
        {
            List<CityOutputDto> listCityOutputDto = v.Select(x => new CityOutputDto() {
                                                                                           Name = x.Name,
                                                                                           UF = x.UF,
                                                                                           Id = x.Id,
                                                                                           DateUpdateOrCreate = x.DateUpdate == null ? 
                                                                                           x.DateCreate.ToString("dd/MM/yyyy HH:mm") : 
                                                                                           x.DateUpdate?.ToString("dd/MM/yyyy HH:mm")
                                                                                      }).ToList();
            return listCityOutputDto;
            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string UF { get; set; }

        public string DateUpdateOrCreate { get; set; }
    }
}
