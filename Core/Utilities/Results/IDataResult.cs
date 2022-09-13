using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //İnterface içerisinde data ve mesaj tutulması gerekmektedir.
        //Ancak mesaj ifadesi için gerekli olan yapıları IResult interface'ini kalıtım ile alarak 
        //Gereksiz kod bloklarından kaçınıyoruz.
        T Data { get; }//Buradaki 'get' ifadesi sadece değeri döndürülebilir anlamına gelmektedir.
        //değer değiştirilemez.

    }
}
