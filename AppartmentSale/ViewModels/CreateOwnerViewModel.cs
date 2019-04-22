using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppartmentSale.ViewModels
{
    public class CreateOwnerViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }

        public SelectList Gender { get; set; }

        [Display(Name = "Пол")]
        public int GenderId { get; set; }

        public SelectList DocumentType { get; set; }

        [Required]
        [Display(Name = "Тип документа")]
        public int DocumentId { get; set; }

        [Required]
        [Display(Name = "Серия документа")]
        public string DocumentSerial { get; set; }

        [Required]
        [Display(Name = "Номер документа")]
        public string DocumentNumber { get; set; }

    }
}