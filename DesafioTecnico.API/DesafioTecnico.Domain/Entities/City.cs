using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Domain.Entities
{
    [Table("City")]
    public class City : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("UF")]
        public string UF { get; set; }

        [InverseProperty(nameof(City))]
        public List<Client> Clients { get; set; }
    }
}
