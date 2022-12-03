using DesafioTecnico.Domain.Dtos.Input.Client;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Domain.Entities
{
    [Table("Client")]
    public class Client : BaseEntity
    {
        public static explicit operator Client(ClientInputDto v)
        {
            var client = new Client() {
                Id = v.Id,
                Name = v.Name,
                IdCity = v.IdCity,
                Age = v.Age,
                Gender = v.Gender,
                BirthDate = v.BirthDate 
            };

            if (client.Id == 0)
                client.DateCreate = DateTime.Now;
            else
                client.DateUpdate = DateTime.Now;

            return client;
        }
        [Column("Name")]
        public string Name { get; set; }

        [Column("Birth_Date")]
        public DateTime BirthDate { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }

        [Column("Id_City")]
        public int IdCity { get; set; }

        [ForeignKey(nameof(IdCity))]
        public City City { get; set; }

    }
}
