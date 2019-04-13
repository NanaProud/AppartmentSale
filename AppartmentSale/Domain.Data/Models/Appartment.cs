using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Data
{
    /// <summary>
    /// Класс для описания сущности
    /// </summary>
    public class Appartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StreetId { get; set; }
        public virtual Street Street { get; set; }

        public int HouseNumber { get; set; }

        public string Building { get; set; }

        public int Flat { get; set; }

        public virtual ICollection<Owning> Owners { get; set; }
    }
}
