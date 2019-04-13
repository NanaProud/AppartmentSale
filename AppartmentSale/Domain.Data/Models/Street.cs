using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Data
{
    /// <summary>
    /// Класс для описания сущности Улица
    /// </summary>
    public class Street
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
    }
}
