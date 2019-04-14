using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Data;
using Ninject.Modules;
using Domain.Services;
using AppartmentSale.Domain.Services;

namespace AppartmentSale.Util
{
    /// <summary>
    /// Класс для регистрации зависимостей
    /// </summary>
    public class NinjectRegistration : NinjectModule
    {
        /// <summary>
        /// Инициализация зависимостей
        /// </summary>
        public override void Load()
        {
            Bind<IAppartmentRepository>().To<AppartmentService>();
            Bind<IOwnerRepository>().To<OwnerService>();
            Bind<IStreetRepository>().To<StreetService>();
        }
    }
}