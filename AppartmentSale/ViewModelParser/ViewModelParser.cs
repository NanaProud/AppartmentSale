using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Data;
using AppartmentSale.ViewModels;

namespace AppartmentSale.ViewModelParser
{
    /// <summary>
    /// Класс для парсинга ViewModel к Model
    /// </summary>
    public class ViewModelParser
    {
        public Appartment ParseCreateAppartmentViewModel(CreateAppartmentViewModel appartmentViewModel)
        {
            return new Appartment()
            {
                StreetId = appartmentViewModel.StreetId,
                HouseNumber = appartmentViewModel.HouseNumber,
                Building = appartmentViewModel.Building,
                Flat = appartmentViewModel.Flat
            };
        }
    }
}