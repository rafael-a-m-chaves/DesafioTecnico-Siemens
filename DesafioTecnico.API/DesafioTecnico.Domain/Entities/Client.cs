using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Domain.Entities
{
    [Table("Client")]
    public class Client : BaseEntity
    {
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
