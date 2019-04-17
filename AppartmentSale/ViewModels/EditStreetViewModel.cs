using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для загрузки редактируемых данных для сущности Улицы
    /// </summary>
    public class EditStreetViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название улицы")]
        public string Title { get; set; }

        public int CurrentAreaId { get; set; }

        [Display(Name = "Выберите район")]
        public SelectList Areas { get; set; }
    }
}