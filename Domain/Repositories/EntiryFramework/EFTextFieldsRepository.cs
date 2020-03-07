using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntiryFramework
{
    /// <summary>
    /// Класс для работы с ОRM 
    /// </summary>
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        //конструктор. Контекст работы с бд. Получаем и сохраняем в Бд
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields; //получаем все записи
        }

        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id); //получаем из БД данные по ID
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord); //получаем из БД данные по ID
        }

        /// <summary>
        /// Сохраняем по ID
        /// </summary>
        /// <param name="entity"></param>
        public void SaveTextField(TextField entity) //обьект для сохранения данных
        {
            if (entity.Id == default) // если такого id нет.  енити его добавит
                context.Entry(entity).State = EntityState.Added; //Флаг обьекта. Для добвление в бд Сущность отслеживается контекстом, но еще не существует в базе данных.

            else
                context.Entry(entity).State = EntityState.Modified; // Флаг обьекта изменен, значит такой id уже существует в Бд. И он изменился. Что то добавилось или убавилось. Заголовой, текст и т.д.
            context.SaveChanges(); // сохранение изменений в БД
        }

        /// <summary>
        /// удаляем по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTextField(Guid id)
        {
            //обращаемся через контекст к таблице БД и по id удаляем обьект
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }

}

