using System;
using System.Collections.Generic;
using System.Text;
using Domain.Data.Models;
namespace Domain.Data.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с сущностью Владение
    /// </summary>
    public interface IOwningRepository : IRepository<Owning> { }
}
