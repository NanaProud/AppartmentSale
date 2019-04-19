using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppartmentSale.ViewModels
{
    /// <summary>
    /// Класс для отображение редактируемой модели владельца
    /// </summary>
    public class EditOwnerViewModel : CreateOwnerViewModel
    {
        public int Id { get; set; }
    }
}