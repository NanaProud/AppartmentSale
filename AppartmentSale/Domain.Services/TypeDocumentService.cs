using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Domain.Data;

namespace AppartmentSale.Domain.Services
{
    public class TypeDocumentService : ITypeDocumentRepository
    {
        private readonly AppartmentContext _appartmentContext;

        public TypeDocumentService(AppartmentContext appartmentContext)
        {
            _appartmentContext = appartmentContext;
        }

        /// <summary>
        /// Добавление типа документа в базу
        /// </summary>
        /// <param name="entity">Тип документа</param>
        /// <returns></returns>
        public async Task Add(TypeDocument entity)
        {
            _appartmentContext.TypeDocuments.Add(entity);
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление "Типа документа" из базы
        /// </summary>
        /// <param name="id">Номер типа-документа</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var deleteTypeDocument = await _appartmentContext.TypeDocuments.FindAsync(id);
            if (deleteTypeDocument != null)
            {
                _appartmentContext.TypeDocuments.Remove(deleteTypeDocument);
                await _appartmentContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Редактирование типа документа
        /// </summary>
        /// <param name="entity">Сущность "тип-документа"</param>
        /// <returns></returns>
        public async Task Edit(TypeDocument entity)
        {
            _appartmentContext.Entry(entity).State = EntityState.Modified;
            await _appartmentContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение типа документа по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TypeDocument> Get(int id)
        {
            var typeDocument = await _appartmentContext.TypeDocuments.FindAsync(id);
            return typeDocument;
        }
        
        /// <summary>
        /// Получение списка типов-документов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeDocument> GetAll()
        {
            return _appartmentContext.TypeDocuments;
        }
    }
}