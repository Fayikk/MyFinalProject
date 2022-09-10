using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Entity Framework kullanımı
    //Yazılan kodlar reFactor edilecektir.(İyileştirilecektir9
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthWindContext>, ICategoryDal
    {
        //Aynı şekilde bu bölgeye ise class'a özgü metodlar yazılmaktadır.
        
    }
}
