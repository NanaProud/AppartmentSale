using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppartmentSale.ViewModels;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;

namespace AppartmentSale.Controllers
{
    public class OwnerController : Controller
    {
        private static int _pagesize = 6;
        private readonly IOwnerRepository ownerRepository;
        IDictionary<int, string> sexDictionary = new Dictionary<int, string>()
        {
            [1] = "Мужской",
            [2] = "Женский"
        };

        /// <summary>
        /// Внедрение зависимостей
        /// </summary>
        /// <param name="ownerRepository"></param>
        public OwnerController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        /// <summary>
        /// Загрузка списка владельцев
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var owners = ownerRepository.GetAll().Select(p => new OwnerViewModel()
            {
                Id = p.Id,
                BirthDay = p.BirthDay,
                DocumentNumber = p.DocumentNumber,
                DocumentSerial = p.DocumentSerial,
                FullName = String.Join(" ", p.Name, p.Surname, p.MiddleName),
                Sex = p.Id == 1 ? "Мужсккой" : "Женский",
                TypeDocument = p.DocumentType
            }).ToPagedList(pageNumber, _pagesize);
            return View(owners);
        }

        /// <summary>
        /// GET-запрос на создание владельца
        /// Инициализация формы с созданием владельца
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateOwner()
        {
            var sexForDisplay = sexDictionary.Select(p => new
            {
                Id = p.Key,
                Title = p.Value
            });
            SelectList sexList = new SelectList(sexForDisplay, "Id", "Title");
            CreateOwnerViewModel createOwnerViewModel = new CreateOwnerViewModel() { Gender = sexList };
            return View(createOwnerViewModel);
        }

        /// <summary>
        /// POST-запрос на создание владельца
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateOwner(CreateOwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
               
            }
            return View(model);
        }
    }
}