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
    /// Сервис для работы с сущностью "Район"
    /// </summary>
    public class AreaService : IAreaRepository
    {
        private readonly AppartmentContext _appartmentContext;

        /// <summary>
        /// Добавление зависимости
        /// </summary>
        /// <param name="appartmentContext"></param>
        public AreaService(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        /// <summary>
        /// Добавление сущности "Район"
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Add(Area entity)
        {
            _appartmentContext.Areas.Add(entity);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление района по Id
        /// </summary>
        /// <param name="id">Id района</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var deleteArea = await _appartmentContext.Areas.FindAsync(id);
            if (deleteArea != null)
            {
                _appartmentContext.Areas.Remove(deleteArea);
                await _appartmentContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Редактирование сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Edit(Area entity)
        {
            _appartmentContext.Entry(entity).State = EntityState.Modified;
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение Района по Id
        /// </summary>
        /// <param name="id">Id района</param>
        /// <returns></returns>
        public async Task<Area> Get(int id)
        {
            var area = await _appartmentContext.Areas.FindAsync(id);
            return area;
        }

        /// <summary>
        /// Получение списка районов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Area> GetAll()
        {
            return _appartmentContext.Areas;
        }
    }
}