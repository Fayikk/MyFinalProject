using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// Unused usings removed.

namespace WebAPI1
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
            //services.AddRazorPages();
            services.AddControllers();
            services.AddSingleton<IProductService,ProductManager>();//Bana arka planda bir referans oluştur.
            services.AddSingleton<IProductDal, EfProductDal>();//Burada ise anlatılmak istenen,eğer biri senden IProductDal isterse ona EfProductDal ver anlamıan gelmektedir.
            //Yukarıdaki AddSingleton metodu ile yapılması gereken ifadeyi daha anlaşılır ve kolay bir şekilde inceleyebiliriz.
            //Bu ifade şu anlama gelmektedir.IProductService ile gönderilen ProductMananger'ı arka planda new'le anlamına gelmektedir.
            //Bu yapı sayesinde bağımlılık'tan kurtarıyoruz
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}