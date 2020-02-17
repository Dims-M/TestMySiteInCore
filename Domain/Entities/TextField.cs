using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    /// <summary>
    /// Класс оаысывает страницы на Сатйе. Переопрееляет методы базового класса EntityBase 
    /// </summary>
    public class TextField : EntityBase 
    {
        [Required]
        public virtual string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; }
    }
}
