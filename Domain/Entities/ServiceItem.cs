using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    /// <summary>
    /// Класс оgисывающий услуги. Переопределяем базовые методы калсса 
    /// </summary>
    public class ServiceItem :EntityBase
    {
        [Required(ErrorMessage ="Заполните назввание услуги ")]
        [Display(Name = "Название Услуги")]
        public override string Title { get; set; }

        [Display(Name = "Крадкое описание услуги")]
        public override string Subtitle { get; set; } = "Информационная страница";
      
        [Display(Name = "Название Услуги (заголовок)")]
        public override string Text { get; set; }

    }
}
