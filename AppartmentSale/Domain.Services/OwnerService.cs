using Domain.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Services
{
    public class OwnerService : IOwnerRepository
    {
        private readonly AppartmentContext _appartmentContext;

        public OwnerService(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        /// <summary>
        /// Добавление владельца
        /// </summary>
        /// <param name="entity">Владелец</param>
        /// <returns></returns>
        public async Task Add(Owner entity)
        {
            _appartmentContext.Owners.Add(entity);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление владельца по Id
        /// </summary>
        /// <param name="id">Id Владельца</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            Owner owner = await _appartmentContext.Owners.FindAsync(id);
            if (owner != null)
                _appartmentContext.Owners.Remove(owner);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление владельца
        /// </summary>
        /// <param name="entity">Владелец</param>
        /// <returns></returns>
        public async Task Edit(Owner entity)
        {
            _appartmentContext.Entry(entity).State = EntityState.Modified;
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение Владельца по Id
        /// </summary>
        /// <param name="id">Id Владельца</param>
        /// <returns></returns>
        public async Task<Owner> Get(int id)
        {
            var owner = await _appartmentContext.Owners.FindAsync(id);
            return owner;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _appartmentContext.Owners;
        }
    }
}
