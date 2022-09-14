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
            services.AddSingleton<IProductService, ProductManager>();//Bana arka planda bir referans oluþtur.
            services.AddSingleton<IProductDal, EfProductDal>();//Burada ise anlatýlmak istenen,eðer biri senden IProductDal isterse ona EfProductDal ver anlamýan gelmektedir.
            //Yukarýdaki AddSingleton metodu ile yapýlmasý gereken ifadeyi daha anlaþýlýr ve kolay bir þekilde inceleyebiliriz.
            //Bu ifade þu anlama gelmektedir.IProductService ile gönderilen ProductMananger'ý arka planda new'le anlamýna gelmektedir.
            //Bu yapý sayesinde baðýmlýlýk'tan kurtarýyoruz
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
