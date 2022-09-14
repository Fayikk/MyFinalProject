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

//A�a��daki yap�lar�n genel olarak ad�-->Autofac,Ninject
//AOP
builder.Services.AddControllers();
//services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductManager>();//Bana arka planda bir referans olu�tur.
builder.Services.AddSingleton<IProductDal, EfProductDal>();//Burada ise anlat�lmak istenen,e�er biri senden IProductDal isterse ona EfProductDal ver anlam�an gelmektedir.
                                                   //Yukar�daki AddSingleton metodu ile yap�lmas� gereken ifadeyi daha anla��l�r ve kolay bir �ekilde inceleyebiliriz.
                                                   //Bu ifade �u anlama gelmektedir.IProductService ile g�nderilen ProductMananger'� arka planda new'le anlam�na gelmektedir.
                                                   //Bu yap� sayesinde ba��ml�l�k'tan kurtar�yoruz


//Category i�lemi i�inde builder yazal�m
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
