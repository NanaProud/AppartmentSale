using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppartmentSale.ViewModels;
using Domain.Data;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using static AppartmentSale.ViewModelParser.ViewModelParser;

namespace AppartmentSale.Controllers
{
    /// <summary>
    /// Контроллер для работы с сущностью "Улица"
    /// </summary>
    public class StreetController : Controller
    {
        #region Private Members
        private static int _pageSize = 6;
        private readonly IStreetRepository streetRepository;
        private readonly IAreaRepository areaRepository;
        #endregion

        public StreetController(IStreetRepository streetRepository, IAreaRepository areaRepository)
        {
            this.streetRepository = streetRepository;
            this.areaRepository = areaRepository;
        }

        /// <summary>
        /// Генерация индексной страницы с улицей
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var listAreas = streetRepository.GetAll()
                .Select(p => new StreetViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    AreaName = p.Area.Title
                })
                .ToPagedList(pageNumber, _pageSize);
            return View(listAreas);
        }

        /// <summary>
        /// GET-запрос на редактирование Улицы
        /// </summary>
        /// <param name="id">Id улицы</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EditStreet(int? id)
        {
            if (id is null)
                return HttpNotFound();
            var selectedStreet = await streetRepository.Get((int)id);
            var areas = areaRepository.GetAll();
            var selectedViewModel = new EditStreetViewModel()
            {
                Id = selectedStreet.Id,
                Title = selectedStreet.Title,
                CurrentAreaId = selectedStreet.AreaId,
                Areas = new SelectList(areas, "Id", "Title", selectedStreet.Id)
            };
            return View(selectedViewModel);
        }

        /// <summary>
        /// POST-запрос на редактирование улицы
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStreet(EditStreetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editStreet = ParseEditStreetViewModel(model);
                await streetRepository.Edit(editStreet);
                return RedirectToAction("Index", "Street");
            }
            var areas = areaRepository.GetAll();
            model.Areas = new SelectList(areas, "Id", "Title", model.CurrentAreaId);
            return View(model);
        }

        /// <summary>
        /// POST-запрос на удаление улицы
        /// </summary>
        /// <param name="id">Id улицы</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> DeleteStreet(int? id)
        {
            if (id is null)
                throw new NullReferenceException(nameof(id));
            await streetRepository.Delete((int)id);
            return Request.UrlReferrer.ToString();
        }

        /// <summary>
        /// GET-запрос на создание улицы 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateStreet()
        {
            var areas = areaRepository.GetAll();
            var createStreetModel = new CreateStreetViewModel()
            {
                Title = string.Empty,
                Areas = new SelectList(areas, "Id", "Title")
            };
            ViewBag.Areas = createStreetModel.Areas;
            return View(createStreetModel);
        }

        /// <summary>
        /// POST-запрос на создание улицы в базе
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStreet(CreateStreetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var street = ParseCreateStreetViewModel(model);
                await streetRepository.Add(street);
                return RedirectToAction("Index", "Street");
            }
            var areas = areaRepository.GetAll();
            model.Areas = new SelectList(areas, "Id", "Title", model.AreaId);
            return View(model);
        }
    }
}