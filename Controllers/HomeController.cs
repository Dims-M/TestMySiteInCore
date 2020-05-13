using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
    /// <summary>
    /// контроллер по умолчнию.
    /// </summary>
    public class HomeController : Controller
    {
        //для работы с БД
        private readonly DataManager dataManager;

        //Конструктор
        HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        /// <summary>
        /// Экшен по умолчанию
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {   // обращение к бд
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

        public IActionResult Contacts()
        {   // обращение к бд
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
    }
}