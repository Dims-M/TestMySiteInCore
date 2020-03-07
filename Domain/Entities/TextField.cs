using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    /// <summary>
    /// Класс опысывает страницы на Сайте. Переопрееляет методы базового класса EntityBase 
    /// </summary>
    public class TextField : EntityBase 
    {
        /// <summary>
        /// Ключевое слова. Для работы на сайте.
        /// </summary>
        [Required(ErrorMessage = "Не должно быть пустыл")]
        public virtual string CodeWord { get; set; }
        [Required(ErrorMessage ="Название страницы")]
        [Display(Name = "Название страницы (заголовок)")]
       
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Название страницы (заголовок)")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
