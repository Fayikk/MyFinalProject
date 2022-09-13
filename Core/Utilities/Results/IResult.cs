using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel void yapıları için başlangıç

    public interface IResult
    {
        //İçerisinde bir işlem sonucu

        bool Success { get; }   //Sadece okunabilir anlamına gelmektedir.
        string Message { get; } //Buda sadece okunabilir.Set edilemez anlamına gelmektedir.
        
        //işlem bunu gerçekleştirecektir.Yapılan işlem başarılı(True)
        //Yada yapılan işlem başarısız(False) değer döndürmeye yarayacaktır.

        //Birde kullanıcıyı bilgilendirmek üzere bir mesaj olsun.
    }
}
