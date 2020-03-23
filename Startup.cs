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
        //��������� ��� ����������� ���� ������������ appsettings.json
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // M���� ��� ���������� ����� � ���������
        public void ConfigureServices(IServiceCollection services)
        {
            //����������� � �������� ����� ������������ ��� appsettings.json � 
            Configuration.Bind("Project", new Config()); //������������ ���� � ����������� � ��������� �� ������������ ������

            //���������� ��� "�����������" ���������� ����������, � �������� ��������!!!! 
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); //��������� ���������. � ���������� ������ ����������
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>(); //�������� � �������

            //���������� ���������. ��� ������ � ��
            services.AddDbContext<AppDbContext>(x=> x.UseSqlServer(Config.ConnectionString)); //��������� ��� ���������� SqlServer. ��������� ������ ����������� ����������� � ������� Config.ConnectionString

            //����������� identity ������� 
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true; //���������� �����
                opts.Password.RequiredLength = 6;  //��� ����� ������
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false; //����������� ���� ������
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false; //����� � ������
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //����������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth"; //�������� ����
                options.Cookie.HttpOnly = true; //������������ �� ��������� �������
                options.LoginPath = "/account/login"; //���� ��� ������������ ������ ������
                options.AccessDeniedPath = "/account/accessdenied"; 
                options.SlidingExpiration = true;
            });

            //������ ����������� ��������������
            //����������� �������� ����������� ��� Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });

            });

            //DependencyInjection
            //��������� ��������� ������������ � ������������� MVC
            services.AddControllersWithViews(x =>
            {
                //�������� ���������� ��� ���������� ������.(1 �������� �������, 2 ��������(������� �� ������� AddAuthorization)
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            //���������� ������������� � asp.net core 3.0
                

        }



        // ����� ��� ��������� ��������� HTTP-��������. middleware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //���� � ������ ������������. � �� (���������)
            if (env.IsDevelopment())
            {   // �� ������������ ��� ������ �� ��������(����������)
                app.UseDeveloperExceptionPage();
            }

            //������������� �� ������������(�������)
            app.UseRouting();

            //���������� ������ �� ������������ �������(css, js � ��.)
            app.UseStaticFiles();

            //���������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            //������������� �� �������
            //���� �� ����� ������ � ������� �� ��������. ������������ ��� ���������
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            
        }
    }
}
