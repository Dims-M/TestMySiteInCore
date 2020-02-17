using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntiryFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

       /// <summary>
       /// Получаем список всех услуг
       /// </summary>
       /// <returns></returns>
        public IQueryable<ServiceItem> GetTextFields()
        {
            return context.ServiceItems;
        }

        /// <summary>
        /// Получаем услугу по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceItem GetTextFieldById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Сохраняем новую услугу или модифицируем старую
        /// </summary>
        /// <param name="entity"></param>
        public void SaveTextField(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges(); //сохранение или обновление услуги
        }
        
        //удаление по id
        public void DeleteTextField(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }

        //29/46
        TextField IServiceItemsRepository.GetTextFieldByCodeWord(string codeWord)
        {
            throw new NotImplementedException();
        }


    }
}
