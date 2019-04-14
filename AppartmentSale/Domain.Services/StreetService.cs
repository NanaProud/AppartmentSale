using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Domain.Data;

namespace AppartmentSale.Domain.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Улица
    /// </summary>
    public class StreetService : IStreetRepository
    {
        private readonly AppartmentContext _appartmentContext;

        /// <summary>
        /// Добавление зависимости
        /// </summary>
        /// <param name="appartmentContext"></param>
        public StreetService(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        /// <summary>
        /// Добавление Улицы в базу
        /// </summary>
        /// <param name="entity">Сущность для добавления</param>
        /// <returns></returns>
        public async Task Add(Street entity)
        {
            _appartmentContext.Streets.Add(entity);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление улицы по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var deleteStreet = await _appartmentContext.Streets.FindAsync(id);
            if (deleteStreet != null)
                _appartmentContext.Streets.Remove(deleteStreet);
        }

        /// <summary>
        /// Редактирование улицы
        /// </summary>
        /// <param name="entity">Сущность для редактирования</param>
        /// <returns></returns>
        public async Task Edit(Street entity)
        {
            _appartmentContext.Entry(entity).State = EntityState.Modified;
            await _appartmentContext.SaveChangesAsync();
        }

        public async Task<Street> Get(int id)
        {
            var street = await _appartmentContext.Streets.FindAsync(id);
            return street;
        }

        /// <summary>
        /// Получение списка всех улиц
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Street> GetAll()
        {
            return _appartmentContext.Streets;
        }
    }
}