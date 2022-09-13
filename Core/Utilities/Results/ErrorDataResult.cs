using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResultt<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)//Error hatalı değer döndürme işlemleri için false değer success için false değer döndürüyoruz
        {
            //Yukarıda işlem sonucunu default olarak true atamış olduk.
        }
        public ErrorDataResult(T data) : base(data, false)
        {
            //Hiç mesaj vermek istemeyebiliriz.
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            //İşlemin sonucunda hiçbir şey vermek istemiyorum diyelim.
            //Dolayısıyla Data için default değer döndürüyoruz.

        }

        public ErrorDataResult() : base(default, false)
        {
            //Hem data'ya default değer ataması yapıyoruz.
            //Hemde mesaj göndermiyoruz.
        }
    }
}
