using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{   
    //İmplementasyonu yada kalıtımı yapılmamış class kalmamalı ana kurallarımızdan birisidir.
    public class Result : IResult
    {
        //C# this demek class'ın kendisi anlamına gelmektedir.
        //Yani bu class altında "this" kullanırsak eğer Result classının kendisini kullanıyoruz anlamına gelmektedir.
        public Result(bool success, string message):this(success)
        {
            Message = message;
           
            //İleti için kullanılan construxtor burasıdır,ancak Result constructor'ı için,
            //Gerekli olan success matık değeri aşağıdaki constrctor tarafından değer ataması yapılmaktadır.
            //Dolayısıyla bu constructor için gerekli olan parametreler'in değeri girildi ve aynı zamanda eşitleme yapmadığımız
            //success property'sini de eğer farkettiyseniz parametre olarak constructor içerisine göndermiş sayılıyoruz.
            //Buradan hareketle constructor'ı sayesinde this bileşeni sayesinde aşağıdaki constructor'ın tetiklenmesini sağlıyoruz.
            //Aslında bir nevi Encapsulation anlamına gelmektedir.(Kapsülleme)
        }
        public Result(bool success)
        {
            Success = success;
            //Burada yapılmak istenen(boolean) olarak gönderilmek istenen değer için herhangi bir
            //Şekilde mesaj gönderilmesi istenmemektedir.Dolayısıyla bu constructor kulllanılacaktır.
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
