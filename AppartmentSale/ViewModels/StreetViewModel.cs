using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для отображения Улицы
    /// </summary>
    public class StreetViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string AreaName { get; set; }
    }
}