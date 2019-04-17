using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Domain.Data;
using AppartmentSale.ViewModels;
using System.Threading.Tasks;
using AppartmentSale.ViewModelParser;
using static AppartmentSale.ViewModelParser.ViewModelParser;

namespace AppartmentSale.Controllers
{
    /// <summary>
    /// Класс-контроллер для обработки
    /// </summary>
    public class AppartmentController : Controller
    {
        private static int _pageSize = 6;
        private readonly IAppartmentRepository appartmentRepository;
        private readonly IStreetRepository streetRepository;

        /// <summary>
        /// Внедрение зависимостей для контроллера
        /// </summary>
        /// <param name="appartmentRepository"></param>
        /// <param name="viewModelParser"></param>
        /// <param name="streetRepository"></param>
        public AppartmentController(IAppartmentRepository appartmentRepository, IStreetRepository streetRepository)
        {
            this.appartmentRepository = appartmentRepository;
            this.streetRepository = streetRepository;
        }

        /// <summary>
        /// Загрузка индексной страницы для оп
        /// </summary>
        /// <param name="page">Номер страницы с пагинацией</param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var appartmentPagedList = appartmentRepository.GetAll().Select(a => new AppartmentViewModel()
            {
                Id = a.Id,
                Street = a.Street,
                HouseNumber = a.HouseNumber,
                Building = a.Building,
                Flat = a.Flat,
                Owners = a.Owners.Select(p => p.Owner)
            }).ToPagedList(pageNumber, _pageSize);
            return View(appartmentPagedList);
        }

        /// <summary>
        /// Генерация страницы с созданием квартиры
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAppartment()
        {
            CreateAppartmentViewModel model = new CreateAppartmentViewModel();
            var listStreets = streetRepository.GetAll();
            model.Streets = new SelectList(listStreets, "Id", "Title");
            return View(model);
        }

        /// <summary>
        /// POST-запрос на создание квартиры
        /// </summary>
        /// <param name="model">Модель с созданными параметрами</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAppartment(CreateAppartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appartment = ParseCreateAppartmentViewModel(model);
                await appartmentRepository.Add(appartment);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}