using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
namespace WebApII1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddControllers();
            //services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();//Bana arka planda bir referans olu�tur.
            services.AddSingleton<IProductDal, EfProductDal>();//Burada ise anlat�lmak istenen,e�er biri senden IProductDal isterse ona EfProductDal ver anlam�an gelmektedir.
            //Yukar�daki AddSingleton metodu ile yap�lmas� gereken ifadeyi daha anla��l�r ve kolay bir �ekilde inceleyebiliriz.
            //Bu ifade �u anlama gelmektedir.IProductService ile g�nderilen ProductMananger'� arka planda new'le anlam�na gelmektedir.
            //Bu yap� sayesinde ba��ml�l�k'tan kurtar�yoruz
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApII1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApII1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
