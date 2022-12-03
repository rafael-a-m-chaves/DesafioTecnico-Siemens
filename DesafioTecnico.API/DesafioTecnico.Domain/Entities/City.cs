using DesafioTecnico.Domain.Dtos.Input.City;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Domain.Entities
{
    [Table("City")]
    public class City : BaseEntity
    {
        public static explicit operator City(CityInputDto v)
        {
            var city = new City()
            {
                Id = v.Id,
                Name = v.Name,
                UF = v.UF
            };
            if (city.Id == 0) city.DateCreate = DateTime.Now;
            else city.DateUpdate = DateTime.Now;
            return city;
        }

        [Column("Name")]
        public string Name { get; set; }

        [Column("UF")]
        public string UF { get; set; }

        [InverseProperty(nameof(City))]
        public List<Client> Clients { get; set; }
    }
}
