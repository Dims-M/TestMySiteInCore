using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            Configuration.Bind("Project", new Config());

            //DependencyInjection
            //Добавляем потдержку контролерров и представлений MVC
            services.AddControllersWithViews();

        }

        // метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //если в режиме разработчика. А не (продакшин)
            if (env.IsDevelopment())
            {   // то показываются все ошибки на странице(исключений)
                app.UseDeveloperExceptionPage();
            }

            //маршрутизация по контроллерам(ссылкам)
            app.UseRouting();

            //подклчаем работу со статическийм файлами(css, js и др.)
            app.UseStaticFiles();

            //маршсрутизация по поинтам
            //app.UseEndpoints(endpoints =>
            //{
            // маршрут по умолчанию
            //endpoints.MapGet("/", async context =>
            //{
            //    //пример по умолчанию
            //   await context.Response.WriteAsync("Hello World!");
            //});

            //указываем начальную точку(адрес) по умолчанию.(это контроле Home и экшен(метод)Index
            //если ни каких данных в запросе не приходит. Используются эта настройка
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            
        }
    }
}
