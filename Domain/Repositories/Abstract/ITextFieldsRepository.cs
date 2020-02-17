using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    /// <summary>
    /// Интерфейсы для реализации Doma.. обьектов
    /// </summary>
    public interface ITextFieldsRepository
    {
        /// <summary>
    /// Gjkexbnm(Выборка все полей)
    /// </summary>
    /// <returns></returns>
       
        IQueryable<TextField> GetTextFields(); 
        TextField GetTextFieldById(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
