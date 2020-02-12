using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyCompany
{
    public class Startup
    {
        // Mетод для добавления служб в контейнер
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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

            //маршсрутизация по поинтам
            app.UseEndpoints(endpoints =>
            {
                // маршрут по умолчанию
                //endpoints.MapGet("/", async context =>
                //{
                //    //пример по умолчанию
                //   await context.Response.WriteAsync("Hello World!");
                //});

                app.UseEndpoints(endpoints =>
                { 
                endpoints.MapAreaControllerRoute("default", )
                });

            });
        }
    }
}
