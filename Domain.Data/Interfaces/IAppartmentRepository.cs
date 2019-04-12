using Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностью "Квартиры"
    /// </summary>
    public interface IAppartmentRepository : IRepository<Appartment> { }
}
