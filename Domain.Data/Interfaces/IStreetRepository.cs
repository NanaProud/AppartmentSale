using Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для операций с сущностью "Улица"
    /// </summary>
    public interface IStreetRepository : IRepository<Street> { }
}
