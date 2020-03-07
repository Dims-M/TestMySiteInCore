using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    /// <summary>
    /// Интерфейс реализует получение услуг
    /// </summary>
    public interface IServiceItemsRepository
    {

        /// <summary>
        /// Получить все тестовые слова (Выборка все полей)
        /// </summary>
        /// <returns></returns>
        IQueryable<ServiceItem> GetTextFields();

        /// <summary>
        /// Получение услуги по Id
        /// </summary>
        /// <param name="id">Уникальный Guid(id)</param>
        /// <returns></returns>
        ServiceItem GetTextFieldById(Guid id);

        /// <summary>
        /// Получение нужной услуги
        /// </summary>
        /// <param name="codeWord">Параметр слово</param>
        /// <returns></returns>
        TextField GetTextFieldByCodeWord(string codeWord);

        /// <summary>
        /// Сохранение или обновление услуги
        /// </summary>
        /// <param name="entity"></param>
        void SaveTextField(ServiceItem entity);

        /// <summary>
        /// Удаление услуги по ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteTextField(Guid id);
    }
}
