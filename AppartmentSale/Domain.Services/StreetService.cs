using System;
using System.Collections.Generic;
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

        public StreetService(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        public Task Add(Street entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Street entity)
        {
            throw new NotImplementedException();
        }

        public Task<Street> Get(int id)
        {
            throw new NotImplementedException();
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