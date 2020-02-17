using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    /// <summary>
    /// Класс помошник. Для работы с контекстом БД
    /// </summary>
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get;set; }
        public IServiceItemsRepository ServiceItems { get;set; }

        //Rjycnhernjh
        public DataManager(ITextFieldsRepository textFields, IServiceItemsRepository serviceItems)
        {
            TextFields = textFields;
            ServiceItems = serviceItems;
        }


    }
}
