using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{   //İsmindeki dal onun hhangi katmana karşılık geldiğini anlatmaktadır.
    public interface IProductDal
    {   //GetAll() metodu "Hepsini getir" anlamına gelmektedir.
        //Buradaki Product farklı bir katmandan gelecektir.
        //Unutmayın! 2 katman birbirini referans edemez.
        //Buna circular dependency(kısır döngü sayılabilir) denmektedir.
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GettAllByCatefory(int categoryId);

    }
}
