using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false,message)
        {
            //Burada hem message hemde matıksal bir ifade döndürmesi gerekecektir.
            //Burada 2 operatörün  birden kullanımı görmekteyiz.
        }
        public ErrorResult():base(false)
        {
            //Burada ise tek parametreli kullanımı görelim
            //Tek parametreli kullanım'da sadece bool ifadelerin
            //Kullanımını göreceğiz.
        }
    }
}
