using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AppartmentSale.Controllers
{
    public class TypDocumentController : Controller
    {
        private readonly ITypeDocumentRepository typeDocumentRepository;
        private static int _pageSize = 6;

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
    }
}