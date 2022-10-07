using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.NewFolder.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Concrete
{   //Trying
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)//Entity manager kendinden başka Dal'ı enjekte edemez
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }
        //[LogAspect]//bu ifade aşağıdaki Add metodunu log'la anlamına gelmektedi.
        //Bu ifadeye AOP denir.
        //[Validate]//Bunu doğrula anlamına gelmektedir.


        //Bu bölge attribute için ayrılmıştır
        //[SecuredOperation("admin,operatör")]  Korunan opereasyon anlamına gelmektedir. Bu operatör admin yada editör yetkisine sahiptir diyebiliriz.
        [ValidationAspect(typeof(ProductValidator))]//Add metodunu doğrula ProductValidator'ı kullnarak anlamına gelmektedir.s
        //[SecuredOperation("deneme,product.add")]
        [CacheRemoveAspect("IProductService.Get")]//IProductService'teki bütün Get'leri  sil anlamına gelmektedir.Herhangi bir değişiklik durumunda uygula anlamına gelmektedir

        public IResult Add(Product product)
        {
            //Aynı isimde ürün eklenemez
            IResult result = BusinesRules.Run(ChechkIfProductCountCategoryCorrect(product.CategoryId),
                 CheckIfNameExists(product.ProductName));
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            //Loglama yapılan işlemlerin kaydını tutarlar.Kim,ne zaman,nerede,ne yaptı gibi sorular yöneltilebilir.

            //business codes =iş gereksinimlerine uygunluk.Ejliyet alacaksınız ve o kişiye ehliyet verecekmisiniz.Örneğin direksiyon sınavına giriş için,yazılı sınavda geçtinizmi.
            //validation codes birbirine karıştırılmamalı
            //_productDal.Add(product);
            //return new SuccessResult(Messages.ProductAdded);//Burada mesaj döndürebilir yada boolean değer döndürmesi yapabilmektedir.
            //2 Parametreli ifadede hem mesaj değeri döndürürken aynı zamanda bool ifade değer döndürmektedir.
            //1 Parametreli ifadede ise sadece bool değer döndürmesi gerçekleştirilecektir.
            //yukarıdaki gibi bir değer döndürme işlemini gerçekleştirebilmemiz için
            //metodumuzun değer döndürdüğü sınıf'ın bir yapıcı metoda ihtiyacı vardır.
            //Yapıcı metodlar tetiklenme işlemlerini gerçekleştirirler.Dolayısıyla
            //ve yukarıdaki ifadeyi kullanabilmemizin yolu'da sııf için constructor'lardan geçmektedir.
        }

        [CacheAspect] //Key,value pair ile tutulmaktadır
        public IDataResult<List<Product>> GetAll()
        {
            //Varsa iş kodlarımızı buraya yazıyoruz.
            //Bir iş sınıfı başka sınıfları new'lemez
            //Yetkisi varmı?
            //if (DateTime.Now.Hour == 1)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);//Data döndürmüyorum
            //}
            Thread.Sleep(3000);


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.Success);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
            //Burada ise filtreleme işlemlerimizi gerçekleştirmmiş oluyoruz.
            //Filtremizi verirken diyoruzki olurda p için categoryId'miz,eğer ıd'ye eşit oluyorsa.
            //bunu döndürelim.
        }

        [CacheAspect] //Key,value pair ile tutulmaktadır
        [PerformanceAspect(1)]//Burada denilen bu metodun çalışması 5sn'yi geçerse eğer uyar!
        public IDataResult<Product> GetBtId(int productId)
        {
            return new DataResultt<Product>(_productDal.Get(p => p.ProductId == productId), true, Messages.Success);//Delegasyon yöntemi
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //Burada 2 fiyat aralığında olan data'yı bize getirme işlemini  gerçekleştirecektir.
            return new DataResultt<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), false, "Error");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintanceTime);//Data döndürmüyorum
            }
            return new DataResultt<List<ProductDetailDto>>(_productDal.GetProductDetails(), true, "Success");
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult(Messages.Success);
        }

        private IResult ChechkIfProductCountCategoryCorrect(int categoyId)
        {
            //Bir kategoride en fazla 10 ürün olabilir.
            var result = _productDal.GetAll(p => p.CategoryId == categoyId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategory);
            }

            return new SuccessResult();
        }


        private IResult CheckIfNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }


        //MikroService uygulamaları aşağıdaki yapı sayesinde çalıştırılır.
        //Başka bir manager'dan yetkilendirme alınmaz ancak mikroservis olarak o manager'ın mşkroservis yapısı kullanılabilmektedir.

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.OverloadingCategory);
            }
            return new SuccessResult(Messages.Success);
        }
        [TransactionScopeAspect] //Senkronizasyon işlemlerini gerçekleştiri.
        public IResult AddTransactionalTest(Product product)
        {
           
            Add(product);
            if (product.UnitPrice<10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }
}
