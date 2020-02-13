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
        // M���� ��� ���������� ����� � ���������
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //DependencyInjection
            //��������� ��������� ������������ � ������������� MVC
            services.AddControllersWithViews();

        }

        // ����� ��� ��������� ��������� HTTP-��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //���� � ������ ������������. � �� (���������)
            if (env.IsDevelopment())
            {   // �� ������������ ��� ������ �� ��������(����������)
                app.UseDeveloperExceptionPage();
            }

            //������������� �� ������������(�������)
            app.UseRouting();

            //��������� ������ �� ������������ �������(css, js � ��.)
            app.UseStaticFiles();

            //�������������� �� �������
            //app.UseEndpoints(endpoints =>
            //{
            // ������� �� ���������
            //endpoints.MapGet("/", async context =>
            //{
            //    //������ �� ���������
            //   await context.Response.WriteAsync("Hello World!");
            //});

            //��������� ��������� �����(�����) �� ���������.(��� �������� Home � �����(�����)Index
            //��� �� ����� ������ � ������� �� ��������. ������������ ��� ���������
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            
        }
    }
}
