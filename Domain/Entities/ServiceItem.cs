using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    /// <summary>
    /// Класс оисывающий услуги.
    /// </summary>
    public class ServiceItem
    {
        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }


    }
}
