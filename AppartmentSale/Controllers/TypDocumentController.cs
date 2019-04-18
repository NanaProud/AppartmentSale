using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;

namespace AppartmentSale.Controllers
{
    /// <summary>
    /// Контроллер для обработки запросов с сущностью "Тип документа"
    /// </summary>
    public class TypDocumentController : Controller
    {
        private readonly ITypeDocumentRepository typeDocumentRepository;
        private static int _pageSize = 6;

        /// <summary>
        /// Внедрение зависимостей
        /// </summary>
        /// <param name="typeDocumentRepository"></param>
        public TypDocumentController(ITypeDocumentRepository typeDocumentRepository)
        {
            this.typeDocumentRepository = typeDocumentRepository;
        }

        /// <summary>
        /// Индексная страница со списком Районов
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var listTypes = typeDocumentRepository.GetAll().ToList().ToPagedList(pageNumber, _pageSize);
            return View(listTypes);
        }

        /// <summary>
        /// GET-запрос на редактирование Типа документа
        /// </summary>
        /// <param name="id">Id улицы</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EditTypeDocument(int? id)
        {
            if (id is null)
                return HttpNotFound();
            var typeDocument = await typeDocumentRepository.Get((int)id);
            return View(typeDocument);
        }

        /// <summary>
        /// Генерация страницы с созданием типа документа
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateTypDocument() => View();

        /// <summary>
        /// POST-зарос на создание типа-документа
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTypDocument(TypeDocument typeDocument)
        {
            if (ModelState.IsValid)
            {
                await typeDocumentRepository.Add(typeDocument);
                return RedirectToAction("Index", "TypeDocument");
            }
            return View(typeDocument);
        }

        /// <summary>
        /// Редактирование района
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EditTypeDocument(int id)
        {
            var typeDocument = await typeDocumentRepository.Get(id);
            return View(typeDocument);
        }


        /// <summary>
        /// POST-запрос на редактирование типа-документа
        /// </summary>
        /// <param name="typeDocument">Тип документа</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTypeDocument(TypeDocument typeDocument)
        {
            if (ModelState.IsValid)
            {
                await typeDocumentRepository.Edit(typeDocument);
                return RedirectToAction("Index", "TypeDocument");
            }
            return View(typeDocument);
        }

        /// <summary>
        /// POST-запрос на редактирование
        /// </summary>
        /// <param name="id">id типа-документа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeleteTypeDocument(int id)
        {
            await typeDocumentRepository.Delete(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}