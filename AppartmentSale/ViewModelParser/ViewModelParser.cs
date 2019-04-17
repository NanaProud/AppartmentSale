﻿using System;
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
    public static class ViewModelParser
    {
        /// <summary>
        /// Преобразование из класса CreaViewModel в объект таблицы "Квартира"
        /// </summary>
        /// <param name="appartmentViewModel">Модель с параметрами на создание объекта "Квартира"</param>
        /// <returns>Объект "Квартира"</returns>
        public static Appartment ParseCreateAppartmentViewModel(CreateAppartmentViewModel appartmentViewModel)
        {
            return new Appartment()
            {
                StreetId = appartmentViewModel.StreetId,
                HouseNumber = appartmentViewModel.HouseNumber,
                Building = appartmentViewModel.Building,
                Flat = appartmentViewModel.Flat
            };
        }

        /// <summary>
        /// Прербразование редактируемой модели улицы в объект сущности "Улица"
        /// </summary>
        /// <param name="model">Редактируемая модель</param>
        /// <returns></returns>
        public static Street ParseEditStreetViewModel(EditStreetViewModel model)
        {
            return new Street()
            {
                Id = model.Id,
                AreaId = (int)model.Areas.SelectedValue,
                Title = model.Title
            };
        }
    }
}