using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Data
{
    /// <summary>
    /// Класс для сущности "Район"
    /// </summary>
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название района")]
        public string Ttile { get; set; }

        public virtual IEnumerable<Street> Streets { get; set; }
    }
}
