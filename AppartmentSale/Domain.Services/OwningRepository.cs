using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Domain.Data;
using System.Data.Entity;

namespace AppartmentSale.Domain.Services
{
    /// <summary>
    /// Сервис для работы с записями - "Владение"
    /// </summary>
    public class OwningRepository : IOwningRepository
    {
        private readonly AppartmentContext _appartmentContext;
        public OwningRepository(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        /// <summary>
        /// Добавление записи о владении
        /// </summary>
        /// <param name="entity">Запись владении</param>
        /// <returns></returns>
        public async Task Add(Owning entity)
        {
            _appartmentContext.Ownings.Add(entity);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление записи о владении
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var deletingOwningRecord = await _appartmentContext.Ownings.FindAsync(id);
            if (deletingOwningRecord != null)
            {
                _appartmentContext.Entry(deletingOwningRecord).State = EntityState.Deleted;
                await _appartmentContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Редактирование записи о владении
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Edit(Owning entity)
        {
            _appartmentContext.Entry(entity).State = EntityState.Modified;
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение сведений о записи о владении
        /// </summary>
        /// <param name="id">Id записи о владении</param>
        /// <returns></returns>
        public async Task<Owning> Get(int id)
        {
            var record = await _appartmentContext.Ownings.FindAsync(id);
            return record;
        }

        /// <summary>
        /// Список владений
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Owning> GetAll()
        {
            return _appartmentContext.Ownings;
        }
    }
}