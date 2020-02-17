using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    /// <summary>
    /// Интерфейсы для реализации Domain.. обьектов
    /// </summary>
    public interface ITextFieldsRepository
    {
        /// <summary>
    /// Получить все тестовые слова (Выборка все полей)
    /// </summary>
    /// <returns></returns>
        IQueryable<TextField> GetTextFields();

        /// <summary>
        /// Получение слова по Id
        /// </summary>
        /// <param name="id">Уникальный Guid(id)</param>
        /// <returns></returns>
        TextField GetTextFieldById(Guid id);

        /// <summary>
        /// Получение нужного слова
        /// </summary>
        /// <param name="codeWord">Параметр слово</param>
        /// <returns></returns>
        TextField GetTextFieldByCodeWord(string codeWord);

        /// <summary>
        /// Сохранение поле
        /// </summary>
        /// <param name="entity"></param>
        void SaveTextField(TextField entity);

        /// <summary>
        /// Удаление нужного поля по ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteTextField(Guid id);
    }
}
