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
        //��������� ��� ����������� ���� ������������ appsettings.json
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // M���� ��� ���������� ����� � ���������
        public void ConfigureServices(IServiceCollection services)
        {
            //����������� � �������� ����� ������������ ��� appsettings.json � 
            Configuration.Bind("Project", new Config());

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
            //���� �� ����� ������ � ������� �� ��������. ������������ ��� ���������
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            
        }
    }
}
