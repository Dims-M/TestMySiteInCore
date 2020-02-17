﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    /// <summary>
    /// Связь с базой данных
    /// Наследуетсся от IdentityDbContext. Для работы с пользователями БД
    /// Используется стандартный пользователь IdentityUser
    /// </summary>
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //коструктор
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Описывающие таблицы в БД. 
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        /// <summary>
        /// Метод создает роли(Админ, пользователи) и заполняет модели(БД) данными.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //создание роли
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            //создание самих пользователей.
            //проверка идет по Id. Если такого пользователя нет. То создается новый
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"), //пароль в хеше
                SecurityStamp = string.Empty
            });

            //промежуточная, системная таблица. Для хранения ролей.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            //СОздание самих страниц. Класс Текстовые поля.
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    
    }    
}
