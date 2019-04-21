using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Domain.Data;
using System.Threading.Tasks;

namespace AppartmentSale.Controllers
{
    /// <summary>
    /// Контроллер для операций с сущностью "Район"
    /// </summary>
    public class AreaController : Controller
    {
        private readonly IAreaRepository areaRepository;
        private static int _pageSize = 6;

        public AreaController(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        /// <summary>
        /// Индексная страница со списком Районов
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var listAreas = areaRepository.GetAll().ToList().ToPagedList(pageNumber, _pageSize);
            return View(listAreas);
        }

        /// <summary>
        /// Генерация страницы с созданием района
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateArea() => View();

        /// <summary>
        /// POST-зарос на создание района
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateArea(Area area)
        {
            if (ModelState.IsValid)
            {
                await areaRepository.Add(area);
                return RedirectToAction("Index", "Area");
            }
            return View(area);
        }

        /// <summary>
        /// Редактирование района
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EditArea(int id)
        {
            var area = await areaRepository.Get(id);
            return View(area);
        }

        /// <summary>
        /// POST-запрос на редактирование района
        /// </summary>
        /// <param name="area">Район</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditArea(Area area)
        {
            if (ModelState.IsValid)
            {
                await areaRepository.Edit(area);
                return RedirectToAction("Index", "Area");
            }
            return View(area);
        }

        /// <summary>
        /// POST-запрос на редактирование
        /// </summary>
        /// <param name="id">id Района</param>
        /// <returns>Куда перенаправлять в случае успешного удаления</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteArea(int id)
        {
            await areaRepository.Delete(id);
            return Request.UrlReferrer.ToString();
        }
    }
}