using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyCompany.Controllers
{
    /// <summary>
    /// контроллер по умолчнию.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Экшен по умолчанию
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}