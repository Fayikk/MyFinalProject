using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResultt<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            //Yukarıda işlem sonucunu default olarak true atamış olduk.
        }
        public SuccessDataResult(T data):base(data,true)
        {
            //Hiç mesaj vermek istemeyebiliriz.
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
           //İşlemin sonucunda hiçbir şey vermek istemiyorum diyelim.
           //Dolayısıyla Data için default değer döndürüyoruz.

        }

        public SuccessDataResult():base(default,true)
        {
            //Hem data'ya default değer ataması yapıyoruz.
            //Hemde mesaj göndermiyoruz.
        }


    
    }
}
