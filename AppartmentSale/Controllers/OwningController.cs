using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Data;
using AppartmentSale.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace AppartmentSale.Controllers
{
    /// <summary>
    /// Контроллер для обработки POST и GET запросов
    /// </summary>
    public class OwningController : Controller
    {
        private const int _pagesize = 6;
        private readonly IOwningRepository owningRepository;
        private readonly IOwnerRepository ownerRepository;

        /// <summary>
        /// Внедрение зависимостей
        /// </summary>
        /// <param name="owningRepository">Репозиторий для работы с таблицей о владении</param>
        public OwningController(IOwningRepository owningRepository, IOwnerRepository ownerRepository)
        {
            this.owningRepository = owningRepository;
            this.ownerRepository = ownerRepository;
        }

        /// <summary>
        /// Генерация индексной страницы со списком Квартира-Владельцы
        /// </summary>
        /// <param name="page">Номер страницы пагинации</param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            var owningList = owningRepository.GetAll().GroupBy(p => p.Appartment).Select(p => new OwningViewModel()
            {
                Appartment = p.Key,
                Owners = p.Key.Owners.SelectMany(x => ownerRepository.GetAll().Where(z => z.Id == x.OwnerId)).ToList()
            });
            return View(owningList);
        }
    }
}