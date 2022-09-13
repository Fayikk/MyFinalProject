using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //Yapılan işlemin başarılı olduğunu belirlemek adına bu class'ı kuruyoruz.7
        //Aşağıdaki yapı ile eğer farkındaysanız constructor'ın hemen yanında base gönderiyoruz
        //Bu gönderilen base "true" anlamına gelmektedir.Yani bu class'ı biz eğer true değer döndürüyorsak döndürelim anlamına gelmektedir.
        //Birde bu class'ın success olmayan meodu yazılacaktır.
        //Base-->Kalıtım ile alınan sınıf ile iletişim kurmak için kullanılacaktır.
        public SuccessResult( string message) : base(true)
        {

        }

        //Mesaj vermek istemiyor olabilir.
        public SuccessResult():base(true)//Farkettiyseniz tek parametrelidir.
        {
            //True değerini default olarak atamasını yapmış oluyoruz.

        }
    }
}
