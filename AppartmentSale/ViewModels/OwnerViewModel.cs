using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для отображения списка владельцев
    /// </summary>
    public class OwnerViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Sex { get; set; }

        public TypeDocument TypeDocument { get; set; }

        public string DocumentSerial { get; set; }

        public string DocumentNumber { get; set; }


    }
}