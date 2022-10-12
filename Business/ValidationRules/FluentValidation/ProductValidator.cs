using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>//Bu product için bir validator'dır
    {
        public ProductValidator()
        {
            //RuleFor(p => p.ProductName).NotEmpty();//productname boş olamaz anlamına gelmektedir.
            //RuleFor(p => p.ProductName).MinimumLength(2);//Burada predicate uygulaması yapıyoruz.
            ////Anlamı ise p'nin productname'in minimum lenght'i 2 karakter olmalıdır.
            //RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);//p'nin unitprice'ı 0'dan büyük olmalıdır.
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            ////Yukarıdaki ifadenin anlamı ise;Unit price 10'dan büyük eşit olmalıdır.Ancak categoryıd'si "1" ise bu kural geçerli olacaktır.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adı 'A' ile başlamalıdır");//Kendi yazdığımız kurala uymalıdır.

        }

        private bool StartWithA(string arg)//Burada ise metodlarımzı ve validator'larımızı biz oluşturuyoruz.
        {
            return arg.StartsWith("A");//Değer true dönecektir.Eğer false dönerse yukarıdaki validator patlayacaktır.
        }
    }
}
