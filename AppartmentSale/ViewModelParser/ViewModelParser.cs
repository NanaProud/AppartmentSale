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

        /// <summary>
        /// Парсинг создаваемой улицы
        /// </summary>
        /// <param name="model">Создаваемая модель</param>
        /// <returns></returns>
        public static Street ParseCreateStreetViewModel(CreateStreetViewModel model)
        {
            return new Street()
            {
                AreaId = model.AreaId,
                Title = model.Title
            };
        }

        /// <summary>
        /// Парсинг создаваемого владельца
        /// </summary>
        /// <param name="owner">Модель владельца</param>
        /// <returns></returns>
        public static Owner ParseCreateOwnerModelToOwner(CreateOwnerViewModel owner)
        {
            return new Owner()
            {
                Name = owner.Name,
                Surname = owner.Surname,
                MiddleName = owner.MiddleName,
                BirthDay = owner.BirthDay,
                DocumentId = (int)owner.DocumentType.SelectedValue,
                DocumentSerial = owner.DocumentSerial,
                Gender = (int)owner.Gender.SelectedValue
            };
        }

        public static Owner ParseEditOwnerModel(EditOwnerViewModel editOwnerViewModel)
        {
            var owner = ParseCreateOwnerModelToOwner(editOwnerViewModel);
            owner.Id = editOwnerViewModel.Id;
            return owner;
        }

    }
}