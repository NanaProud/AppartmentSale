using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    /// <summary>
    /// Базовый репозиторий для репозиторий всех сущностей
    /// От этого интерфейса создаются другие интерфейсы-репозитории
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IRepository<Entity> where Entity : class
    {
        Task Add(Entity entity);
        Task Edit(Entity entity);
        Task Delete(int id);
        Task<Entity> Get(int id);
        IEnumerable<Entity> GetAll();
    }
}
