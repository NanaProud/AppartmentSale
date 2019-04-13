using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Data
{
    /// <summary>
    /// Класс для описания сущности "Владелец"
    /// </summary>
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Определение пола. 0-мужчина, 1-женщина
        /// </summary>
        public int Gender { get; set; }

        public int DocumentId { get; set; }

        [ForeignKey("DocumentId")]
        public virtual TypeDocument DocumentType { get; set; }

        [Required]
        public string DocumentSerial { get; set; }

        [Required]
        public string DocumentNumber { get; set; }
    }
}
