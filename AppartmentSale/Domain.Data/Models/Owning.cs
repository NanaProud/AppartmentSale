using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Data
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

        /// <summary>
        /// Id Владельца
        /// </summary>
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public int AppartmentId { get; set; }
        [ForeignKey("AppartmentId")]
        public Appartment Appartment { get; set; }

        public DateTime DateStartOwning { get; set; }

        public DateTime? DateFinishOwning { get; set; }

        /// <summary>
        /// Доля владения
        /// </summary>
        public float ShareOwning { get; set; }

    }
}
