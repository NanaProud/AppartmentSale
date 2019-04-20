using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Data;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для отображения списка
    /// </summary>
    public class OwningViewModel
    {
        public Appartment Appartment { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
    }
}