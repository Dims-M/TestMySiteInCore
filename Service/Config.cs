using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service
{
    /// <summary>
    /// Класс реализыует работу с настройками appsettings.json. 
    /// Для загрузки его при старте приложения в Startup
    /// </summary>
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyPhone { get; set; }
        public static string CompanyPhoneShort { get; set; }
        public static string CompanyEmail { get; set; }


    }
}
