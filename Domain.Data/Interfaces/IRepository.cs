using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Interfaces
{
    /// <summary>
    /// Базовый репозиторий для репозиторий всех сущностей
    /// От этого интерфейса создаются другие интерфейсы-репозитории
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IRepository<Entity> where Entity : class
    {
        void Add(Entity entity);
        void Edit(Entity entity);
        void Delete(int id);
        Task<Entity> Get(int id);
    }
}
