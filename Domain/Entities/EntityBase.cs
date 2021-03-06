﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    /// <summary>
    /// Абстрактный базовый класс для остальных сущностей, описывающий таблицы в БД
    /// </summary>
    public abstract class EntityBase
    {
        // защищенный конструктор. При каждом создании оьекта. Будет создоватся и записоватся  время его создания 
        protected EntityBase() => DateAdded = DateTime.Now;// UtcNow; // время с стандарте Utc

        [Required] //является обязательным реквезитом для заполнения.
        public Guid Id { get; set; }

        [Required]
        [Display (Name = "Название (заголовок)")]
        public virtual  string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Тутульная картинка ")]
        public virtual string TitleInagePath { get; set; }

        [Display(Name = "SEO метатег Title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public virtual string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        [Required]
        public DateTime DateAdded { get; set; }

    }
}
