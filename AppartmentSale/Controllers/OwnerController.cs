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
using static AppartmentSale.ViewModelParser.ViewModelParser;

namespace AppartmentSale.Controllers
{
    public class OwnerController : Controller
    {
        private static int _pagesize = 6;
        private readonly IOwnerRepository ownerRepository;
        private readonly ITypeDocumentRepository typeDocumentRepository;
        /// <summary>
        /// Список полов, для создания владельца
        /// </summary>
        IDictionary<int, string> sexDictionary = new Dictionary<int, string>()
        {
            [1] = "Мужской",
            [2] = "Женский"
        };

        /// <summary>
        /// Внедрение зависимостей
        /// </summary>
        /// <param name="ownerRepository"></param>
        public OwnerController(IOwnerRepository ownerRepository, ITypeDocumentRepository typeDocumentRepository)
        {
            this.ownerRepository = ownerRepository;
            this.typeDocumentRepository = typeDocumentRepository;
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
            CreateOwnerViewModel createOwnerViewModel = this.GenerateCreateOwnerViewModel();
            return View(createOwnerViewModel);
        }

        /// <summary>
        /// Генерация Модели
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private CreateOwnerViewModel GenerateCreateOwnerViewModel()
        {
            var sexList = this.InitSexList();
            IEnumerable<TypeDocument> typeDocuments = typeDocumentRepository.GetAll().ToList();
            CreateOwnerViewModel createOwnerViewModel = new CreateOwnerViewModel()
            {
                Gender = sexList,
                DocumentType = new SelectList(typeDocuments, "Id", "Name"),
                BirthDay = DateTime.Now
            };
            return createOwnerViewModel;
        }

        /// <summary>
        /// POST-запрос на создание владельца
        /// </summary>
        /// <param name="model">Модель с параметрами инициализации владельца</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateOwner(CreateOwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Owner owner = ParseCreateOwnerModelToOwner(model);
                await ownerRepository.Add(owner);
                return RedirectToAction("Index", "Owner");
            }
            var sexList = this.InitSexList().Select(e => new { Id = e.Value, Title = e.Text }).ToList();
            model.Gender = new SelectList(sexList, "Id", "Title", model.GenderId);
            IEnumerable<TypeDocument> typeDocuments = typeDocumentRepository.GetAll().ToList();
            model.DocumentType = new SelectList(typeDocuments, "Id", "Name", model.DocumentId);
            return View(model);
        }

        /// <summary>
        /// Инициализация списка полов
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private SelectList InitSexList()
        {
            var sexForDisplay = sexDictionary.Select(p => new
            {
                Id = p.Key,
                Title = p.Value
            });
            SelectList sexList = new SelectList(sexForDisplay, "Id", "Title");
            return sexList;
        }

        /// <summary>
        /// Get-Запрос на редактирование владельца
        /// </summary>
        /// <param name="id">Id владельца</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EditOwner(int? id)
        {
            if (id is null)
                return HttpNotFound();
            var owner = await ownerRepository.Get((int)id);
            var sexList = this.InitSexList().Select(s => new { Id = s.Value, Title = s.Text }).ToList();
            var documentList = typeDocumentRepository.GetAll();
            var editOwnerModel = new EditOwnerViewModel()
            {
                Id = owner.Id,
                BirthDay = owner.BirthDay,
                DocumentNumber = owner.DocumentNumber,
                DocumentSerial = owner.DocumentSerial,
                Name = owner.Name,
                Surname = owner.Surname,
                MiddleName = owner.MiddleName,
                Gender = new SelectList(sexList, "Id", "Title",owner.Gender),
                DocumentType = new SelectList(documentList, "Id", "Name", owner.DocumentId)
            };
            return View(editOwnerModel);
        }

        /// <summary>
        /// POST-запрос на редактирование владельца
        /// </summary>
        /// <param name="editOwnerViewModel">Модель с редактируемыми данными</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EditOwner(EditOwnerViewModel editOwnerViewModel)
        {
            if (ModelState.IsValid)
            {
                var editOwner = ParseEditOwnerModel(editOwnerViewModel);
                await ownerRepository.Edit(editOwner);
                return RedirectToAction("Index", "Owner");
            }
            return View(editOwnerViewModel);
        }

        /// <summary>
        /// Удаление владельца квартир
        /// </summary>
        /// <param name="id">Id владельца</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteOwner(int? id)
        {
            if (id is null)
                throw new NullReferenceException(nameof(id));
            await ownerRepository.Delete((int)id);
            return RedirectToAction("Index", "Owner");
        }
    }
}