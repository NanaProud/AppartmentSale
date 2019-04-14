using Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для создания квартиры
    /// </summary>
    public class CreateAppartmentViewModel
    {
        [Required(ErrorMessage = "Необходимо указать улицу, где находится дом")]
        [Display(Name = "Укажите улицу")]
        public int StreetId { get; set; }

        public SelectList Streets { get; set; }

        [Required(ErrorMessage = "Обязательно к заполнению")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Введите число")]
        [Display(Name = "Номер дома")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Обязательно к заполнению")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Введите число")]
        [Display(Name = "Здание")]
        public string Building { get; set; }

        [Required(ErrorMessage = "Обязательно к заполнению")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Введите число")]
        [Display(Name = "Квартира")]
        public int Flat { get; set; }
    }
}