using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для названия полей
    /// </summary>
    public class CreateStreetViewModel
    {
        [Required]
        [Display(Name = "Название улицы")]
        public string Title { get; set; }

        [Display(Name = "Выберите район")]
        public SelectList Areas { get; set; }
    }
}