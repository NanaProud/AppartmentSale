using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Domain.Data;

namespace Domain.Services
{
    /// <summary>
    /// Сервис для работы с сущностью 
    /// </summary>
    public class AppartmentService : IAppartmentRepository
    {
        /// <summary>
        /// Контекст для работы с БД
        /// </summary>
        private readonly AppartmentContext _appartmentContext;

        /// <summary>
        /// Внедрение зависимости AppartmentContext
        /// </summary>
        /// <param name="appartmentContext"></param>
        public AppartmentService(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        /// <summary>
        /// Добавление квартиры в базу данных
        /// </summary>
        /// <param name="appartment">Квартира</param>
        /// <returns></returns>
        public async Task Add(Appartment appartment)
        {
            _appartmentContext.Appartments.Add(appartment);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление Квартиры по Id
        /// </summary>
        /// <param name="id">Id квартиры</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            Appartment appartment = await _appartmentContext.Appartments.FindAsync(id);
            if (appartment != null)
                _appartmentContext.Appartments.Remove(appartment);

        }

        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Edit(Appartment appartment)
        {
            _appartmentContext.Entry(appartment).State = EntityState.Modified;
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение квартиры по ее Id
        /// </summary>
        /// <param name="id">Id квартиры</param>
        /// <returns>Квартира</returns>
        public async Task<Appartment> Get(int id)
        {
            var appartment = await _appartmentContext.Appartments.FindAsync(id);
            return appartment;
        }

        /// <summary>
        /// Получение списка всех квартир с указанием их владельцев
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Appartment> GetAll()
        {
            return _appartmentContext.Appartments.Include(p => p.Owners);
        }
    }
}
