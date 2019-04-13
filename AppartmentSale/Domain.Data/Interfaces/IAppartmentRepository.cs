using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностью "Квартиры"
    /// </summary>
    public interface IAppartmentRepository : IRepository<Appartment> { }
}
