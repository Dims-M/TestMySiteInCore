using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntiryFramework;
using MyCompany.Service;

namespace MyCompany
{
    public class Startup
    {
        //интерфейс для подключения файл конфигурации appsettings.json
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // Mетод для добавления служб в контейнер
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключение и загрузка файла конфигурации Апп appsettings.json в 
            Configuration.Bind("Project", new Config()); //сопоставляем файл с настройками и заполняем из статического класса

            //Подключаем наш "самопистный" функционал приложения, в качестве сервисов!!!! 
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); //связываем интерфейс. С конректным класом реализации
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>(); //внедряем в систему

            //добавление контекста. Для работы с БД
            services.AddDbContext<AppDbContext>(x=> x.UseSqlServer(Config.ConnectionString)); //указываем что используем SqlServer. Параметор строка подключения указывается к конфиге Config.ConnectionString

            //настраиваем identity систему 
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true; //потвердить емайл
                opts.Password.RequiredLength = 6;  //мин длина пароля
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false; //обязательно верх регист
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false; //цифры в пароле
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth"; //название куки
                options.Cookie.HttpOnly = true; //достпупность на клиенской стороне
                options.LoginPath = "/account/login"; //путь для авторизациив панеле админа
                options.AccessDeniedPath = "/account/accessdenied"; 
                options.SlidingExpiration = true;
            });

            //сервис авторизации администратора
            //настраиваем политику авторизации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });

            });

            //DependencyInjection
            //Добавляем потдержку контролерров и представлений MVC
            services.AddControllersWithViews(x =>
            {
                //проверка контролера для аторизации админа.(1 параметр область, 2 политика(берется из сервиса AddAuthorization)
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            //выставляем совместимость с asp.net core 3.0
                

        }



        // метод для настройки конвейера HTTP-запросов. middleware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //если в режиме разработчика. А не (продакшин)
            if (env.IsDevelopment())
            {   // то показываются все ошибки на странице(исключений)
                app.UseDeveloperExceptionPage();
            }

            //маршрутизация по контроллерам(ссылкам)
            app.UseRouting();

            //подключаем работу со статическийм файлами(css, js и др.)
            app.UseStaticFiles();

            //подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            //маршрутизация по поинтам
            //если ни каких данных в запросе не приходит. Используются эта настройка
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            
        }
    }
}
