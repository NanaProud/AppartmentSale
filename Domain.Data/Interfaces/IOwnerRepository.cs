using Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с сущностью "Владелец"
    /// </summary>
    public interface IOwnerRepository : IRepository<Owner> { }
}
