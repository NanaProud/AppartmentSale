using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для отображения Квартиры во View
    /// </summary>
    public class AppartmentViewModel
    {
        public int Id { get; set; }

        public virtual Street Street { get; set; }

        public int HouseNumber { get; set; }

        public string Building { get; set; }

        public int Flat { get; set; }

        public IEnumerable<Owner> Owners { get; set; }

    }
}