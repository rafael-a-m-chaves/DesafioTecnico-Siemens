using System;

namespace DesafioTecnico.Domain.Dtos.Input.Client
{
    public class ClientInputDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int IdCity { get; set; }
    }
}
