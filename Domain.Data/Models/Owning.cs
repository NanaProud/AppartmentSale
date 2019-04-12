using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Data.Models
{
    /// <summary>
    /// Класс для описания сущности "Владение"
    /// </summary>
    [Table("OwningsTable")]
    public class Owning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

    }
}
