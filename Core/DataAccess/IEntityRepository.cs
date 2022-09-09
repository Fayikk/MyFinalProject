using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

//Entity framework;geliştiriciyi karmaşık sql sorgularından kurtaran bir nevi ORM(Object Relational Mapping) anlamına gelen bir yöntemdir.

namespace Core.DataAccess
{   //Repository'mizi oluşturduk.(Depomuzdaki verileimiz bunlardır.İşlemlerimizi bu ifadeler üzerinde gerçekleştirebiliriz)
    //Generic Constraint(Generiz kısıt anlamına gelmektedir)
    //Koşul ifadesindeki class=referans tip anlamına gelmektedir.
    public interface IEntityRepository<T> where T:class,IEntity,new() //"T" ile çalışılacak tipin belirlenmesi gerekmektedir.Ancak tip bağımlılığından kurtarılmaktadır.
    {   //Where koşul ifadesinden hemen sonra gelen ifademiz için kullanılan yapılar şu anlama gelmektedir.
        //IEntityRepository<T> hem class ibaresi sayesinde referans tip olmalı,aynı zamanda bir IEntity olmalıdır.Yani IEntity interface'ini bir şekilde kullanıyor olmalıdır.
        //Ve new() ile newlenebilir olması gerekmektedir.Dolayısıya IEntity interface olduğu için IEntity kabul edilmeyecektir.
        //GetAll() metodu "Hepsini getir" anlamına gelmektedir.
        //Buradaki Product farklı bir katmandan gelecektir.
        //Unutmayın! 2 katman birbirini referans edemez.
        //Buna circular dependency(kısır döngü sayılabilir) denmektedir.
        T Get(Expression<Func<T, bool>> Filter);
        List<T> GetAll(Expression<Func<T,bool>> Filter=null);
        //Burada filter=NULL ifadesinde,eğer istersen filtre vermeyebilirsinde anlamına gelmektedir.
        //Yani şunu söyleyebiliriz eğer filtre vermemişse tüm data'yı istiyor anlamına gelmektedir.
        //Expression ifadeleri sayesinde,Normal durumlarda GetAll() komutu ile getirilen tüm ifadeleri bir filtrelemeye tabi tutmaktayız.
        //Bu filtreler Expression ile gelmektedir.Yalnızca GetAll() komutu kullanılmayacak,GetAll komutu ile birlikte gerekli filtrelemelerde uygulanacaktır.
        //Bu yapılara delege(Delegasyon denmektedir.)

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
