using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Column("Date_Create")]
        public DateTime DateCreate { get; set; }

        [Column("Date_Update")]
        public DateTime DateUpdate { get; set; }
    }
}
