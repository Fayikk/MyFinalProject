using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Umbraco.Core.Composing.CompositionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Aþaðýdaki yapýlarýn genel olarak adý-->Autofac,Ninject
//AOP
builder.Services.AddControllers();
//services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductManager>();//Bana arka planda bir referans oluþtur.
builder.Services.AddSingleton<IProductDal, EfProductDal>();//Burada ise anlatýlmak istenen,eðer biri senden IProductDal isterse ona EfProductDal ver anlamýan gelmektedir.
                                                   //Yukarýdaki AddSingleton metodu ile yapýlmasý gereken ifadeyi daha anlaþýlýr ve kolay bir þekilde inceleyebiliriz.
                                                   //Bu ifade þu anlama gelmektedir.IProductService ile gönderilen ProductMananger'ý arka planda new'le anlamýna gelmektedir.
                                                   //Bu yapý sayesinde baðýmlýlýk'tan kurtarýyoruz


//Category iþlemi içinde builder yazalým
builder.Services.AddControllers();
builder.Services.AddSingleton<ICategoryService,CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
