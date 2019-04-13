using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    /// <summary>
    /// Интерфейс сервиса, определяющий базовые манипуляции с сущностью "Район"
    /// </summary>
    public interface IAreaRepository : IRepository<Area> { }
}
